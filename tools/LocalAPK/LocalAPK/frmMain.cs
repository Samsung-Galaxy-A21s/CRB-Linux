using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using LocalAPK.Data;
using LocalAPK.DA;
using System.Web;
using System.Threading.Tasks;
using System.Collections;
using LocalAPK.SharedResources;

namespace LocalAPK
{
    public partial class frmMain : Form
    {
        private List<string> _folders;
        private HashSet<string> _hashes;
        private bool _groupResults;
        private bool _newGroupSub;
        private List<ApkCommand> _apkCommands;
        
        private int _countInfoDownloaded;
        private int _countInfoMax;

        public delegate void AppendGroupsDelegate(HashSet<string> groupnames);
        private void AppendGroups(HashSet<string> groupnames)
        {
            foreach (var groupname in groupnames)
            {
                lvMain.Groups.Add(groupname, groupname);
            }
        }

        public delegate void AppendResultDelegate(ListViewItem item);
        private void AppendResult(ListViewItem item)
        {
            lvMain.Items.Add(item);
            if (_groupResults)
            {
                var apkFile = (ApkFile)item.Tag;
                if (_newGroupSub == false)
                {
                    foreach (var dir in clsUtils.GetParentDirectories(apkFile.LongFileName))
                    {
                        if (_folders.Contains(dir))
                        {
                            item.Group = lvMain.Groups[dir];
                            return;
                        }
                    }
                }
                else
                {
                    var filePath = apkFile.DirectoryName;
                    item.Group = lvMain.Groups[filePath];
                }
            }
        }

        private void SetColorsForListViewItem(ListViewItem lvi)
        {
            var apkFile = (ApkFile) lvi.Tag;
            if (string.IsNullOrWhiteSpace(apkFile.LocalVersion) || apkFile.LatestVersion == "Unknown") return;

            lvi.UseItemStyleForSubItems = false;

            if (apkFile.LocalVersion == apkFile.LatestVersion)
            {
                lvi.SubItems[(int)ApkColumn.LocalVersion].BackColor = Color.LightGreen;
            }
            else
            {
                if (apkFile.LatestVersion == "Varies with device")
                {
                    lvi.SubItems[(int)ApkColumn.LocalVersion].BackColor = Color.Orange;
                }
                else
                {
                    lvi.SubItems[(int)ApkColumn.LocalVersion].BackColor = Color.PaleVioletRed;
                }
            }
        }

        public delegate void AppendOtherInfoDelegate(string packageName, string latestVersion, string googlePlayName, string price, string category, DateTime lastGooglePlayFetch);
        private void AppendOtherInfo(string packageName, string latestVersion, string googlePlayName, string price, string category, DateTime lastGooglePlayFetch)
        {
            //Update database
            var apkFileToUpdate = new ApkFile
            {
                PackageName = packageName,
                LatestVersion = latestVersion,
                GooglePlayName = googlePlayName,
                Price = price,
                Category = category,
                LastGooglePlayFetch = lastGooglePlayFetch,
                GooglePlayFetchFail = false
            };
            SqliteConnector.UpdateApkFile(apkFileToUpdate);

            foreach (ListViewItem lvi in lvMain.Items)
            {
                var apkFile = (ApkFile) lvi.Tag;
                if (apkFile.PackageName == packageName)
                {
                    lvi.SubItems[(int)ApkColumn.LatestVersion].Text = latestVersion;
                    apkFile.LatestVersion = latestVersion;
                    lvi.SubItems[(int)ApkColumn.GooglePlayName].Text = googlePlayName;
                    apkFile.GooglePlayName = googlePlayName;
                    lvi.SubItems[(int)ApkColumn.Price].Text = price;
                    apkFile.Price = price;
                    lvi.SubItems[(int)ApkColumn.Category].Text = category;
                    apkFile.Category = category;
                    lvi.SubItems[(int)ApkColumn.RefreshDate].Text = lastGooglePlayFetch.ToRelativeTimeString();
                    apkFile.LastGooglePlayFetch = lastGooglePlayFetch;

                    SetColorsForListViewItem(lvi);
                }
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void InsertCommandsInContextMenu()
        {
            //Check ofdat er al een zoek uitklapmenu aanwezig is
            var commandIndex = -1;
            for(var i = 0; i < cmsMain.Items.Count; i++)
            {
                if (cmsMain.Items[i].Text == "Commands")
                {
                    commandIndex = i;
                }
            }
            if (commandIndex != -1)
            {
                cmsMain.Items.RemoveAt(commandIndex);
            }
            
            //Toevoegen
            if(_apkCommands.Count > 0){
                var tsmiCommands = new ToolStripMenuItem("Commands");
                tsmiCommands.Image = Shared.Run;
                foreach (var cd in _apkCommands)
                {
                    var tsmiCommandItem = new ToolStripMenuItem
                    {
                        Text = cd.Title,
                        Tag = cd
                    };
                    tsmiCommandItem.Click += tsmiCommandItem_Click;

                    tsmiCommands.DropDownItems.Add(tsmiCommandItem);
                }
                cmsMain.Items.Insert(1, tsmiCommands);
            }
        }

        void tsmiCommandItem_Click(object sender, EventArgs e)
        {
            //Selection Info
	        var apkFile = (ApkFile) lvMain.SelectedItems[0].Tag;

            var fileName = apkFile.ShortFileName;
	        var longFileName = apkFile.LongFileName;
			var packageName = apkFile.PackageName;
			var appName = apkFile.InternalName;
			var playName = apkFile.GooglePlayName;
			var category = apkFile.Category;
			var localVersion = apkFile.LocalVersion;
			var latestVersion = apkFile.LatestVersion;

            var cd = (ApkCommand)((ToolStripMenuItem)sender).Tag;

            var command = cd.Command;
            command = command.Replace("{filename}", fileName);
            command = command.Replace("{longfilename}", longFileName);
            command = command.Replace("{packagename}", packageName);
            command = command.Replace("{appname}", appName);
			command = command.Replace("{playname}", playName);
	        command = command.Replace("{category}", category);
            command = command.Replace("{localversion}", localVersion);
            command = command.Replace("{latestversion}", latestVersion);

            try
            {
                clsUtils.RunCommand(command);
            }
            catch(Exception ex)
            {
                MessageBox.Show("The command could not be parsed.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartSearch()
        {
            lvMain.Items.Clear();
            lvMain_ItemSelectionChanged(this, null);
            btnRefresh.Enabled = false;
            btnRefreshGooglePlay.Enabled = false;
            btnExport.Enabled = false;
            btnMassRename.Enabled = false;
            btnMassRemove.Enabled = false;
            SetProgressVisiblity(true);

            //Check if grouping enabled
            if (_groupResults)
            {
                lvMain.ShowGroups = true;
            }
            else{
                lvMain.ShowGroups = false;
            }

            Task.Factory.StartNew(LoadBasicInfo).ContinueWith((t) => { LoadExtendedInfo(); });
        }

        private void FinishSearch()
        {
            Invoke((MethodInvoker) delegate {
                btnMassRename.Enabled = true;
                btnMassRemove.Enabled = true;
                btnRefresh.Enabled = true;
                btnRefreshGooglePlay.Enabled = true;
                btnExport.Enabled = true;
                SetProgressVisiblity(false);
            });
        }

        private void LoadBasicInfo()
        {
            _hashes = new HashSet<string>();

            //Scanfolders ophalen
            _folders = SqliteConnector.GetScanFolders();
            var files = new HashSet<string>();
            var listViewGroups = new HashSet<string>();

            foreach (var folder in _folders)
            {
                if (Directory.Exists(folder))
                {
                    if (_groupResults)
                    {
                        listViewGroups.Add(folder);
                    }

                    var filesInFolder = Directory.GetFiles(folder, "*.apk", SearchOption.AllDirectories);

                    foreach (var file in filesInFolder)
                    {
                        files.Add(file);
                        if (_groupResults && _newGroupSub)
                        {
                            listViewGroups.Add(Path.GetDirectoryName(file));
                        }
                    }
                }
            }

            if (_groupResults)
            {
                lvMain.Invoke(new AppendGroupsDelegate(AppendGroups), listViewGroups);
            }

#if (DEBUG)
            foreach (var apk in files)
#endif
#if (!DEBUG)
            Parallel.ForEach(files, (apk) =>
#endif
            {
                var apkFile = new ApkFile {LongFileName = apk};
                var lvi = new ListViewItem(apkFile.ShortFileName);

                //Read APK
                apkFile = SqliteConnector.ReadApkFile(apkFile);

                //Add hash to hashset
                _hashes.Add(apkFile.Md5Hash);

                //Package
                lvi.SubItems.Add(apkFile.PackageName);

                //Name
                lvi.SubItems.Add(apkFile.InternalName);

                //Google Play Name (Loaded from Google Play Page)
                lvi.SubItems.Add(apkFile.GooglePlayName);

                //Category (Loaded from Google Play Page)
                lvi.SubItems.Add(apkFile.Category);

                //Local Version
                lvi.SubItems.Add(apkFile.LocalVersion);

                //Latest Version (Loaded from Google Play Page)
                lvi.SubItems.Add(apkFile.LatestVersion);

                //Price (Loaded from Google Play Page)
                lvi.SubItems.Add(apkFile.Price);

                //Refresh date
                if (apkFile.LastGooglePlayFetch.HasValue)
                {
                    lvi.SubItems.Add(apkFile.LastGooglePlayFetch.Value.ToRelativeTimeString());
                }
                else
                {
                    lvi.SubItems.Add("never");
                }

                //Refresh
                //lvi.UseItemStyleForSubItems = false;
                lvi.SubItems.Add(string.Empty);

                //Set ListViewItem Tag to ApkFile object
                lvi.Tag = apkFile;

                SetColorsForListViewItem(lvi);

                //Add listitem
                lvMain.Invoke(new AppendResultDelegate(AppendResult), lvi);
#if (DEBUG)
            }
#endif
#if (!DEBUG)
            });
#endif
        }

        private void LoadExtendedInfo()
        {
            if (Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.AutoFetchGooglePlay)))
            {
                var packageNames = SqliteConnector.GetNewPackageNamesFromHashes(_hashes);
                RefreshPackages(packageNames);
            }
            else
            {
                FinishSearch();
            }
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var googlePlayPage = new HtmlAgilityPack.HtmlDocument();
            try
            {
                googlePlayPage.LoadHtml(e.Result);

                //Current Version
                string currentVersion = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//div[.='Current Version']")?.Count >= 1)
                {
                    var currentVersionNode = googlePlayPage.DocumentNode.SelectNodes("//div[.='Current Version']").First();
                    var nextNodeAfterCurrentVersionNode = currentVersionNode.NextSibling;
                    if (!string.IsNullOrWhiteSpace(nextNodeAfterCurrentVersionNode?.InnerText))
                    {
                        currentVersion = nextNodeAfterCurrentVersionNode.InnerText;
                    }
                }

                //Genre
                string genre = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//a[@itemprop='genre']")?.Count >= 1)
                {
                    genre = googlePlayPage.DocumentNode.SelectNodes("//a[@itemprop='genre']").First().InnerText;
                }
                
                //Name
                string name = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//h1[@itemprop='name']")?.Count >= 1)
                {
                    var nameNode = googlePlayPage.DocumentNode.SelectNodes("//h1[@itemprop='name']").First();
                    var innerNameNode = nameNode.FirstChild;
                    if (innerNameNode != null && !string.IsNullOrWhiteSpace(innerNameNode.InnerText))
                    {
                        name = innerNameNode.InnerText;
                    }
                }

                //Price
                string price = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//meta[@itemprop='price']")?.Count >= 1)
                {
                    var priceNode = googlePlayPage.DocumentNode.SelectNodes("//meta[@itemprop='price']").First();
                    if (priceNode.Attributes.Contains("content") && !string.IsNullOrWhiteSpace(priceNode.Attributes["content"].Value))
                    {
                        price = priceNode.Attributes["content"].Value;
                    }
                }

                if (!string.IsNullOrWhiteSpace(currentVersion) && !string.IsNullOrWhiteSpace(genre) && !string.IsNullOrWhiteSpace(name))
                {
                    //HtmlDecode
                    currentVersion = WebUtility.HtmlDecode(currentVersion);
                    genre = WebUtility.HtmlDecode(genre);
                    name = WebUtility.HtmlDecode(name);


                    var lastGooglePlayFetch = DateTime.Now;

                    string fixedPrice;
                    if (string.IsNullOrWhiteSpace(price) || price.Trim() == "0")
                    {
                        fixedPrice = "Free";
                    }
                    else
                    {
                        fixedPrice = price;
                    }
                    
                    lvMain.Invoke(new AppendOtherInfoDelegate(AppendOtherInfo), e.UserState, currentVersion,
                        name, fixedPrice, genre, lastGooglePlayFetch);
                }
                else
                {
                    SqliteConnector.SetGooglePlayFetchFail(Convert.ToString(e.UserState));
                }
            }
            catch
            {
                SqliteConnector.SetGooglePlayFetchFail(Convert.ToString(e.UserState));
            }
            finally
            {
                _countInfoDownloaded++;

                if (_countInfoDownloaded == _countInfoMax)
                {
                    FinishSearch();
                }
            }
        }

        private void CheckNewGroupSub()
        {
            if (Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.SubdirGroup)))
            {
                _newGroupSub = true;
            }
            else
            {
                _newGroupSub = false;
            }
        }

        private void lvMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvMain.SelectedItems.Count == 1)
                {
                    cmsMain.Show((ListView)sender, e.X, e.Y);
                }

                if (lvMain.SelectedItems.Count > 1)
                {
                    cmsMainMulti.Show((ListView)sender, e.X, e.Y);
                }
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFolderClicked();            
        }

        private void OpenFolderClicked()
        {
	        var apkFile = (ApkFile) lvMain.SelectedItems[0].Tag;
            if (File.Exists(apkFile.LongFileName))
            {
                var argument = @"/select, " + apkFile.LongFileName;
                Process.Start("explorer.exe", argument);
            }
        }

	    private void OpenGooglePlayClicked()
	    {
			var apkFile = (ApkFile)lvMain.SelectedItems[0].Tag;
			Process.Start(apkFile.GooglePlayUrl);
	    }

        private void openMarketPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
	        OpenGooglePlayClicked();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameSelectedItemClicked();
        }

        private void RenameSelectedItemClicked()
        {
	        var apkFile = (ApkFile) lvMain.SelectedItems[0].Tag;
            var directory = Path.GetDirectoryName(apkFile.LongFileName);

            var renameForm = new frmRename(apkFile.ShortFileName);
            renameForm.ShowDialog();
	        if (renameForm.OkPressed)
	        {
				var newShortFilename = renameForm.ResultText;

				if ((newShortFilename != apkFile.ShortFileName) && (newShortFilename != string.Empty))
				{
					var newLongFilename = directory + "\\" + newShortFilename;
					try
					{
						File.Move(apkFile.LongFileName, newLongFilename);
						apkFile.LongFileName = newLongFilename;
						lvMain.SelectedItems[0].SubItems[(int)ApkColumn.FileName].Text = newShortFilename;
						lblFilenameValue.Text = newShortFilename;
					}
					catch
					{
						MessageBox.Show(string.Format("An error has occured while trying to rename {0}.", apkFile.ShortFileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
	        }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedItemClicked();
        }

        private void lvMain_KeyUp(object sender, KeyEventArgs e)
        {
            //Verwijder APK(s)
            if (e.KeyCode == Keys.Delete)
            {
                if (lvMain.SelectedItems.Count == 1)
                {
                    RemoveSelectedItemClicked();
                }
                if (lvMain.SelectedItems.Count > 1)
                {
                    RemoveSelectionClicked();
                }
            }

            //Open explorer voor geselecteerde APK
            if (e.Control && e.KeyCode == Keys.O)
            {
                if (lvMain.SelectedItems.Count == 1)
                {
                    OpenFolderClicked();
                }
            }

            //Hernoem APK(s)
            if (e.KeyCode == Keys.F2)
            {
                if (lvMain.SelectedItems.Count == 1)
                {
                    RenameSelectedItemClicked();
                }
                if (lvMain.SelectedItems.Count > 1)
                {
                    RenameSelectionClicked();
                }
            }

            //Refresh lijst
            if (e.KeyCode == Keys.F5)
            {
                if (btnRefresh.Enabled)
                {
                    StartSearch();
                }
            }

            //Select All
            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem lvi in lvMain.Items)
                {
                    lvi.Selected = true;
                }
            }
        }

        private void RemoveSelectedItemClicked()
        {
			var apkFile = (ApkFile) lvMain.SelectedItems[0].Tag;
			try
			{
				clsUtils.SendFileToRecycleBin(apkFile.LongFileName);

				//Remove item from main listview
				var removeIndex = lvMain.SelectedItems[0].Index;
				lvMain.Items.RemoveAt(removeIndex);
			}
			catch(Exception e)
			{
				if (e is OperationCanceledException)
				{
					//Canceled => Do nothing
				}
				else
				{
					//Something else is wrong
					MessageBox.Show(string.Format("An error has occured while trying to remove {0}. {1}", apkFile.ShortFileName, e.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Check directories & files
            clsUtils.CheckDirectories();

            //Restore window position/size
            var windowInfo = clsSettings.GetMainWindowInfo();
	        if (windowInfo != null)
	        {
				if (windowInfo.Maximized)
				{
					Location = windowInfo.Location;
					Size = windowInfo.Size;
					WindowState = FormWindowState.Maximized;
				}
				else if (windowInfo.Minimized)
				{
					Location = windowInfo.Location;
					Size = windowInfo.Size;
					WindowState = FormWindowState.Minimized;
				}
				else
				{
					Location = windowInfo.Location;
					Size = windowInfo.Size;
				}
	        }

            //Restore bottom panel height
            var bottomPanelHeight = SqliteConnector.GetSettingValue(SettingEnum.BottomPanelHeight);
            if (!string.IsNullOrWhiteSpace(bottomPanelHeight))
            {
                scMain.SplitterDistance = scMain.Height - Convert.ToInt32(bottomPanelHeight);
            }

            //Restore column widths
            var columnWidthFilename = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthFilename);
            if (!string.IsNullOrWhiteSpace(columnWidthFilename))
            {
                lvMain.Columns[(int) ApkColumn.FileName].Width = Convert.ToInt32(columnWidthFilename);
            }
            var columnWidthPackage = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthPackage);
            if (!string.IsNullOrWhiteSpace(columnWidthPackage))
            {
                lvMain.Columns[(int) ApkColumn.PackageName].Width = Convert.ToInt32(columnWidthPackage);
            }
            var columnWidthInternalname = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthInternalname);
            if (!string.IsNullOrWhiteSpace(columnWidthInternalname))
            {
                lvMain.Columns[(int) ApkColumn.InternalName].Width = Convert.ToInt32(columnWidthInternalname);
            }
            var columnWidthGoogleplayname = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthGoogleplayname);
            if (!string.IsNullOrWhiteSpace(columnWidthGoogleplayname))
            {
                lvMain.Columns[(int) ApkColumn.GooglePlayName].Width = Convert.ToInt32(columnWidthGoogleplayname);
            }
            var columnWidthCategory = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthCategory);
            if (!string.IsNullOrWhiteSpace(columnWidthCategory))
            {
                lvMain.Columns[(int) ApkColumn.Category].Width = Convert.ToInt32(columnWidthCategory);
            }
            var columnWidthLocalversion = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthLocalversion);
            if (!string.IsNullOrWhiteSpace(columnWidthLocalversion))
            {
                lvMain.Columns[(int) ApkColumn.LocalVersion].Width = Convert.ToInt32(columnWidthLocalversion);
            }
            var columnWidthLatestversion = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthLatestversion);
            if (!string.IsNullOrWhiteSpace(columnWidthLatestversion))
            {
                lvMain.Columns[(int) ApkColumn.LatestVersion].Width = Convert.ToInt32(columnWidthLatestversion);
            }
            var columnWidthPrice = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthPrice);
            if (!string.IsNullOrWhiteSpace(columnWidthPrice))
            {
                lvMain.Columns[(int) ApkColumn.Price].Width = Convert.ToInt32(columnWidthPrice);
            }
            var columnWidthGoogleplayfetch = SqliteConnector.GetSettingValue(SettingEnum.ColumnWidthGoogleplayfetch);
            if (!string.IsNullOrWhiteSpace(columnWidthGoogleplayfetch))
            {
                lvMain.Columns[(int) ApkColumn.RefreshDate].Width = Convert.ToInt32(columnWidthGoogleplayfetch);
            }

            //Sort column
            var columnSortIndex = SqliteConnector.GetSettingValue(SettingEnum.ColumnSortIndex);
            if (!string.IsNullOrWhiteSpace(columnSortIndex))
            {
                lvMain.EmulateColumnClick(Convert.ToInt32(columnSortIndex));
            }
            else
            {
                lvMain.EmulateColumnClick(0);
            }

            //Change permissions/features backcolors
            txtFeaturesValue.BackColor = SystemColors.Window;
			txtPermissionsValue.BackColor = SystemColors.Window;
            
            //Load Commands
			_apkCommands = SqliteConnector.GetCommands();
            InsertCommandsInContextMenu();

            //Group Results
            CheckGroupResults();

            //New group for each subfolder
            CheckNewGroupSub();

            //Search in background
            if (Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.StartupRefresh)))
            {
                StartSearch();
            }
        }

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Save window position/size
			switch (this.WindowState)
			{
				case FormWindowState.Maximized:
					clsSettings.SaveMainWindowInfo(new WindowInfo()
					{
						Location = RestoreBounds.Location,
						Size = RestoreBounds.Size,
						Maximized = true,
						Minimized = false
					});
					break;
				case FormWindowState.Normal:
					clsSettings.SaveMainWindowInfo(new WindowInfo()
					{
						Location = Location,
						Size = Size,
						Maximized = false,
						Minimized = false
					});
					break;
				default:
					clsSettings.SaveMainWindowInfo(new WindowInfo()
					{
						Location = RestoreBounds.Location,
						Size = RestoreBounds.Size,
						Maximized = false,
						Minimized = true
					});
					break;
			}

            //Save bottom panel height
		    var bottomPanelHeight = scMain.Height - scMain.SplitterDistance;
            SqliteConnector.SetSettingValue(SettingEnum.BottomPanelHeight, Convert.ToString(bottomPanelHeight));

            //Save column widths
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthFilename, Convert.ToString(lvMain.Columns[(int) ApkColumn.FileName].Width));
		    SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthPackage, Convert.ToString(lvMain.Columns[(int) ApkColumn.PackageName].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthInternalname, Convert.ToString(lvMain.Columns[(int)ApkColumn.InternalName].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthGoogleplayname, Convert.ToString(lvMain.Columns[(int)ApkColumn.GooglePlayName].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthCategory, Convert.ToString(lvMain.Columns[(int)ApkColumn.Category].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthLocalversion, Convert.ToString(lvMain.Columns[(int)ApkColumn.LocalVersion].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthLatestversion, Convert.ToString(lvMain.Columns[(int)ApkColumn.LatestVersion].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthPrice, Convert.ToString(lvMain.Columns[(int)ApkColumn.Price].Width));
            SqliteConnector.SetSettingValue(SettingEnum.ColumnWidthGoogleplayfetch, Convert.ToString(lvMain.Columns[(int)ApkColumn.RefreshDate].Width));

            //Save column sort index
            SqliteConnector.SetSettingValue(SettingEnum.ColumnSortIndex, Convert.ToString(lvMain.LvwColumnSorter.SortColumn));
        }

	    private void CheckGroupResults()
        {
            if (Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.GroupResults)))
            {
                _groupResults = true;
            }
            else
            {
                _groupResults = false;
            }
        }

        private void renameSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameSelectionClicked();
        }

        private void RenameSelectionClicked()
        {
            var massRenameForm = new frmMassRename(lvMain, lblFilenameValue, true);
            massRenameForm.ShowDialog();
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectionClicked();
        }

        private void RemoveSelectionClicked()
        {
			var selectedItems = lvMain.SelectedItems;
			var apkFiles = (from ListViewItem i in selectedItems select (ApkFile) i.Tag).ToList();
	        var fileNames = apkFiles.Select(apkFile => apkFile.LongFileName).ToArray();

	        try
			{
				clsUtils.SendFilesToRecycleBin(fileNames);

				foreach (ListViewItem lvi in selectedItems)
				{
					var removeIndex = lvi.Index;
					lvMain.Items.RemoveAt(removeIndex);
				}
			}
			catch (Exception e)
			{
				if (e is OperationCanceledException)
				{
					//Canceled => Do nothing
				}
				else
				{
					//Something else is wrong
					MessageBox.Show("An error has occured while trying to remove files. " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }

        private void SendToDeviceClicked()
	    {
			var apkFile = (ApkFile)lvMain.SelectedItems[0].Tag;
			var sendToPhoneForm = new frmQRDownload(apkFile.LongFileName);
			sendToPhoneForm.ShowDialog();
	    }

        private void sendToDeviceQrToolStripMenuItem_Click(object sender, EventArgs e)
        {
	        SendToDeviceClicked();
        }

		private void btnRefresh_Click(object sender, EventArgs e)
		{
            StartSearch();
		}

	    private void MassRenameClicked()
	    {
			var massRenameForm = new frmMassRename(lvMain, lblFilenameValue, false);
			massRenameForm.ShowDialog();
	    }

		private void btnMassRename_Click(object sender, EventArgs e)
		{
			MassRenameClicked();
		}

	    private void MassRemoveClicked()
	    {
			var massRemoveForm = new frmMassRemove(lvMain);
			massRemoveForm.ShowDialog();
	    }

		private void btnMassRemove_Click(object sender, EventArgs e)
		{
			MassRemoveClicked();
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			var oSettings = new frmSettings();
			oSettings.ShowDialog();

			//Reload Search providers
			_apkCommands = SqliteConnector.GetCommands();
			InsertCommandsInContextMenu();

			//Check again if grouping is enabled
			CheckGroupResults();

			//Check if grouping for subfolder is enabled
			CheckNewGroupSub();

			//Search again if needed
			if (oSettings.SettingsChanged)
			{
				if (MessageBox.Show("It appears the settings have been changed. Do you want to refresh results?", "Settings Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
                    StartSearch();
				}
			}
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
            var aboutForm = new frmAbout();
            aboutForm.ShowDialog();
        }

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lvMain_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (lvMain.SelectedItems.Count == 0)
			{
				btnRenameSingle.Visible = false;
				btnRemoveSingle.Visible = false;
				btnCommands.Visible = false;
				btnOpenFolder.Visible = false;
				btnOpenGooglePlay.Visible = false;
				btnSendToDeviceQr.Visible = false;
				tssSingleSelection.Visible = false;

				btnRenameMulti.Visible = false;
				btnRemoveMulti.Visible = false;
				tssMultiSelection.Visible = false;

			    ResetDetailPanel();

			}
			else if (lvMain.SelectedItems.Count == 1)
			{
		        UpdateDetailPanel();
				
				btnRenameSingle.Visible = true;
				btnRemoveSingle.Visible = true;
				if (_apkCommands.Count > 0)
				{
					btnCommands.Visible = true;					
				}
				btnOpenFolder.Visible = true;
				btnOpenGooglePlay.Visible = true;
				btnSendToDeviceQr.Visible = true;
				tssSingleSelection.Visible = true;

				btnRenameMulti.Visible = false;
				btnRemoveMulti.Visible = false;
				tssMultiSelection.Visible = false;
			}
			else if(lvMain.SelectedItems.Count > 1)
			{
				btnRenameSingle.Visible = false;
				btnRemoveSingle.Visible = false;
				btnCommands.Visible = false;
				btnOpenFolder.Visible = false;
				btnOpenGooglePlay.Visible = false;
				btnSendToDeviceQr.Visible = false;
				tssSingleSelection.Visible = false;

				btnRenameMulti.Visible = true;
				btnRemoveMulti.Visible = true;
				tssMultiSelection.Visible = true;

                ResetDetailPanel();
            }
		}

        private void ResetDetailPanel()
        {
            lblFilenameValue.Text = "<filename>";
            lblPackageNameValue.Text = "<packagename>";
            lblInternalNameValue.Text = "<internalname>";
            lblGooglePlayNameValue.Text = "<googleplayname>";
            lblCategoryValue.Text = "<category>";
            lblLocalVersionValue.Text = "<localversion>";
            lblLatestVersionValue.Text = "<latestversion>";
            lblPriceValue.Text = "<price>";
            lblVersionCodeValue.Text = "<versioncode>";
            lblMinSdkVersionValue.Text = "<minsdkversion>";
            lblTargetSdkVersionValue.Text = "<targetsdkversion>";
            lblScreenSizesValue.Text = string.Empty;
            lblScreenDensitiesValue.Text = string.Empty;
            txtPermissionsValue.Text = string.Empty;
            txtFeaturesValue.Text = string.Empty;
            picIcon.Image = null;
        }

        private void UpdateDetailPanel()
	    {
			var apkFile = (ApkFile)lvMain.SelectedItems[0].Tag;

		    lblFilenameValue.Text = apkFile.ShortFileName;
		    lblPackageNameValue.Text = apkFile.PackageName;
		    lblInternalNameValue.Text = apkFile.InternalName;
		    lblGooglePlayNameValue.Text = apkFile.GooglePlayName;
		    lblCategoryValue.Text = apkFile.Category;
		    lblLocalVersionValue.Text = apkFile.LocalVersion;
		    lblLatestVersionValue.Text = apkFile.LatestVersion;
		    lblPriceValue.Text = apkFile.Price;
			lblVersionCodeValue.Text = apkFile.VersionCode;
			lblMinSdkVersionValue.Text = clsUtils.TranslateSdkVersion(apkFile.MinimumSdkVersion);
			lblTargetSdkVersionValue.Text = clsUtils.TranslateSdkVersion(apkFile.TargetSdkVersion);
			if (apkFile.ScreenSizes.Count > 0)
			{
				lblScreenSizesValue.Text = string.Empty;
				foreach (var screenSize in apkFile.ScreenSizes)
				{
					lblScreenSizesValue.Text += string.Format("{0}, ", screenSize);
				}
				lblScreenSizesValue.Text = lblScreenSizesValue.Text.Remove(lblScreenSizesValue.Text.Length - 2, 2);
			}
			if (apkFile.ScreenDensities.Count > 0)
			{
				lblScreenDensitiesValue.Text = string.Empty;
				foreach (var screenDensity in apkFile.ScreenDensities)
				{
					lblScreenDensitiesValue.Text += string.Format("{0}, ", screenDensity);
				}
				lblScreenDensitiesValue.Text = lblScreenDensitiesValue.Text.Remove(lblScreenDensitiesValue.Text.Length - 2, 2);
			}
			if (apkFile.Permissions.Count > 0)
			{
				txtPermissionsValue.Text = string.Empty;
				foreach (var permission in apkFile.Permissions)
				{
					txtPermissionsValue.Text += string.Format("{0}\r\n", permission);
				}
				txtPermissionsValue.Text = txtPermissionsValue.Text.Remove(txtPermissionsValue.Text.Length - 2, 2);
			}
			if (apkFile.Features.Count > 0)
			{
				txtFeaturesValue.Text = string.Empty;
				foreach (var feature in apkFile.Features)
				{
					txtFeaturesValue.Text += string.Format("{0}\r\n", feature);
				}
				txtFeaturesValue.Text = txtFeaturesValue.Text.Remove(txtFeaturesValue.Text.Length - 2, 2);
			}

            Task.Factory.StartNew(() => SqliteConnector.ReadIcon(apkFile)).ContinueWith(t => SetApkIcon(t.Result));
	    }

        private void SetApkIcon(byte[] imageAsByteArray)
        {
            if (imageAsByteArray != null)
            {
                Invoke((MethodInvoker)delegate {
                    using (var ms = new MemoryStream(imageAsByteArray))
                    {
                        picIcon.Image = Image.FromStream(ms);
                        if (picIcon.Image.Width > picIcon.Width || picIcon.Image.Height > picIcon.Height)
                        {
                            picIcon.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            picIcon.SizeMode = PictureBoxSizeMode.CenterImage;
                        }
                    }
                });
            }
        }

        private void btnRenameSingle_Click(object sender, EventArgs e)
		{
			RenameSelectedItemClicked();
		}

		private void btnRemoveSingle_Click(object sender, EventArgs e)
		{
			RemoveSelectedItemClicked();
		}

		private void btnOpenFolder_Click(object sender, EventArgs e)
		{
			OpenFolderClicked();
		}

		private void btnSendToDeviceQr_Click(object sender, EventArgs e)
		{
			SendToDeviceClicked();
		}

		private void btnOpenGooglePlay_Click(object sender, EventArgs e)
		{
			OpenGooglePlayClicked();
		}

		private void btnRenameMulti_Click(object sender, EventArgs e)
		{
			RenameSelectionClicked();
		}

		private void btnRemoveMulti_Click(object sender, EventArgs e)
		{
			RemoveSelectionClicked();
		}

		private void btnCommands_Click(object sender, EventArgs e)
		{
			if (_apkCommands.Count > 0)
			{
				var cms = new ContextMenuStrip();

				foreach (var cd in _apkCommands)
				{
					var cdItem = new ToolStripMenuItem();
					cdItem.Tag = cd;
					cdItem.Text = cd.Title;
					cdItem.Click += tsmiCommandItem_Click;
					cms.Items.Add(cdItem);
				}

				//Show toolstrip
				var pButtonPosition = PointToScreen(btnCommands.Bounds.Location);
				var pMenuPosition = new Point(pButtonPosition.X, pButtonPosition.Y + btnCommands.Height);
				cms.Show(pMenuPosition);
			}
		}

        private void lvMain_RefreshClicked(object sender, ApkFile apkFile)
        {
            RefreshPackage(apkFile.PackageName);
        }

        private void btnRefreshGooglePlayOlder_Click(object sender, EventArgs e)
        {
            var frmRefreshOlderThan = new frmRefreshOlderThan();
            frmRefreshOlderThan.OnRefreshOlderThanStartButtonClicked += FrmRefreshOlderThan_OnRefreshOlderThanStartButtonClicked;
            frmRefreshOlderThan.ShowDialog();
        }

        private void FrmRefreshOlderThan_OnRefreshOlderThanStartButtonClicked(object sender, int days)
        {
            var packageNames = SqliteConnector.GetPackageNamesFromHashesAndOlderThan(_hashes, days);
            RefreshPackages(packageNames);
        }

        private void btnRefreshGooglePlayAll_Click(object sender, EventArgs e)
        {
            var packageNames = SqliteConnector.GetPackageNamesFromHashes(_hashes);
            RefreshPackages(packageNames);
        }

        private void RefreshPackage(string packageName)
        {
            var wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.DownloadStringCompleted += wc_DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri(GooglePlayHelper.GetUrlForPackageName(packageName, true)), packageName);
        }

        private void RefreshPackages(IReadOnlyCollection<string> packageNames)
        {
            _countInfoMax = packageNames.Count;
            if (packageNames.Count == 0)
            {
                FinishSearch();
            }
            else
            {
                foreach (var packageName in packageNames)
                {
                    RefreshPackage(packageName);
                }
            }
        }

        private void btnRefreshGooglePlaySelection_Click(object sender, EventArgs e)
        {
            var selectedItems = lvMain.SelectedItems;
            var apkFiles = (from ListViewItem i in selectedItems select (ApkFile)i.Tag).ToList();

            var hashes = new HashSet<string>();
            foreach (var apkFile in apkFiles)
            {
                hashes.Add(apkFile.Md5Hash);
            }
            var packageNames = SqliteConnector.GetPackageNamesFromHashes(hashes);
            RefreshPackages(packageNames);

        }

        private void SetProgressVisiblity(bool visible)
        {
            lblStatus.Visible = visible;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var apkFiles = new List<ApkFile>();
            foreach (ListViewItem lvi in lvMain.Items)
            {
                var apkFile = (ApkFile) lvi.Tag;
                apkFiles.Add(apkFile);
            }
            var exportForm = new frmExport(apkFiles);
            exportForm.ShowDialog();
        }
    }
}
