using System;
using System.Windows.Forms;
using System.Diagnostics;
using LocalAPK.DA;
using LocalAPK.Data;
using System.IO;
using System.Linq;

namespace LocalAPK
{
    public partial class frmSettings : Form
    {
        //Boolean to know if settings have been changed
	    public bool SettingsChanged { get; private set; }

	    public frmSettings()
        {
            InitializeComponent();

            //Add shield to shell extension buttons
            UACSecurity.AddShieldToButton(btnRegisterShellExt);
            UACSecurity.AddShieldToButton(btnUnregisterShellExt);
        }

        private void lstScanFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstScanFolders.SelectedItems.Count == 1)
            {
                btnRemoveFolder.Enabled = true;
            }
            else
            {
                btnRemoveFolder.Enabled = false;
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var oFbd = new FolderBrowserDialog();
            if (oFbd.ShowDialog() == DialogResult.OK)
            {
                lstScanFolders.Items.Add(oFbd.SelectedPath);
                var scanFolders = (from object item in lstScanFolders.Items select item.ToString()).ToList();
                SqliteConnector.SetScanFolders(scanFolders);
                SettingsChanged = true;
            }
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            lstScanFolders.Items.RemoveAt(lstScanFolders.SelectedIndex);
            var scanFolders = (from object item in lstScanFolders.Items select item.ToString()).ToList();
            SqliteConnector.SetScanFolders(scanFolders);
            SettingsChanged = true;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadGeneralSettings();
            LoadScanFolders();
            LoadCommands();
            LicenceCheck();
            CheckShellExt();

            CheckDirectories();

            UpdateCacheSize();
        }

        private void UpdateCacheSize()
        {
            var file = clsUtils.GetSqliteDbFile();
            if (File.Exists(file))
            {
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double len = new FileInfo(file).Length;
                int order = 0;
                while (len >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    len = len / 1024;
                }
                lblCacheInformation.Text = string.Format("The size of the cache is currently {0:0.##} {1}", len, sizes[order]);
            }
        }

        private void CheckDirectories()
        {
            var removedDirs = clsUtils.CheckRemovedScanFolders();
            if (removedDirs.Count > 0)
            {
                if (MessageBox.Show("It appears some of the scan folders have been removed. Do you want to remove these folders from the scan list?", "Scan Folders", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var dir in removedDirs)
                    {
                        lstScanFolders.Items.Remove(dir);
                    }
                    var scanFolders = (from object item in lstScanFolders.Items select item.ToString()).ToList();
                    SqliteConnector.SetScanFolders(scanFolders);
                }
            }
        }

        private void LoadGeneralSettings()
        {
            //Download Latest Version Info
            chkFetchGooglePlay.Checked = Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.AutoFetchGooglePlay));

            //Refresh on Startup
            chkStartupSearch.Checked = Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.StartupRefresh)); ;

            //Group Results
            chkGroupResults.Checked = Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.GroupResults)); ;

            //New group for every subfolder
            chkNewGroupSub.Checked = Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.SubdirGroup)); ;
        }

        private void CheckShellExt()
        {
            if (clsUtils.IsShellExtInstalled())
            {
                btnRegisterShellExt.Enabled = false;
                btnUnregisterShellExt.Enabled = true;

                btnRegisterShellExt.Refresh();
                btnUnregisterShellExt.Refresh();
            }
            else
            {
                btnRegisterShellExt.Enabled = true;
                btnUnregisterShellExt.Enabled = false;

                btnRegisterShellExt.Refresh();
                btnUnregisterShellExt.Refresh();
            }
        }

        private void LicenceCheck()
        {
            if (clsSettings.Portable)
            {
                pnlShellExtRegistered.Visible = false;
                pnlShellExtPortable.Visible = true;
                pnlShellExtPortable.Dock = DockStyle.Fill;
            }
            else
            {
                pnlShellExtRegistered.Visible = true;
                pnlShellExtPortable.Visible = false;
                pnlShellExtRegistered.Dock = DockStyle.Fill;
            }
        }

        private void LoadCommands()
        {
            lvwCommands.Items.Clear();
            foreach (var cd in SqliteConnector.GetCommands())
            {
                var ci = new ListViewItem(cd.Title);
                ci.Tag = cd;
                ci.SubItems.Add(cd.Command);
                lvwCommands.Items.Add(ci);
            }
        }

        private void LoadScanFolders()
        {
            lstScanFolders.Items.Clear();
            foreach (var s in SqliteConnector.GetScanFolders())
            {
                lstScanFolders.Items.Add(s);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvwCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwCommands.SelectedItems.Count == 1)
            {
                btnRemoveCommand.Enabled = true;

                //Up & Down buttons
                if (lvwCommands.Items.Count == 1)
                {
                    btnCommandItemUp.Enabled = false;
                    btnCommandItemDown.Enabled = false;
                }
                else
                {
                    if (lvwCommands.SelectedItems[0].Index == 0)
                    {
                        btnCommandItemUp.Enabled = false;
                        btnCommandItemDown.Enabled = true;
                    }
                    if (lvwCommands.SelectedItems[0].Index == (lvwCommands.Items.Count - 1))
                    {
                        btnCommandItemUp.Enabled = true;
                        btnCommandItemDown.Enabled = false;
                    }
                    if ((lvwCommands.SelectedItems[0].Index != (lvwCommands.Items.Count - 1)) && (lvwCommands.SelectedItems[0].Index != 0))
                    {
                        btnCommandItemUp.Enabled = true;
                        btnCommandItemDown.Enabled = true;
                    }
                }
            }
            else
            {
                btnRemoveCommand.Enabled = false;
                btnCommandItemUp.Enabled = false;
                btnCommandItemDown.Enabled = false;
            }
        }

        private void btnAddSearchProvider_Click(object sender, EventArgs e)
        {
            var newSearchProviderForm = new frmNewCommand();
            newSearchProviderForm.OnCommandAdded += NewSearchProviderForm_OnCommandAdded;
            newSearchProviderForm.ShowDialog();
            newSearchProviderForm.OnCommandAdded -= NewSearchProviderForm_OnCommandAdded;
        }

        private void NewSearchProviderForm_OnCommandAdded(object sender, ApkCommand cmd)
        {
            var ci = new ListViewItem(cmd.Title);
            ci.Tag = cmd;
            ci.SubItems.Add(cmd.Command);
            lvwCommands.Items.Add(ci);

            SaveCommands();
        }

        private void btnRemoveSearchProvider_Click(object sender, EventArgs e)
        {
            lvwCommands.Items.RemoveAt(lvwCommands.SelectedItems[0].Index);

            SaveCommands();
        }

        private void btnCommandItemUp_Click(object sender, EventArgs e)
        {
            var currentSelectedItemIndex = lvwCommands.SelectedItems[0].Index;
            var currentSelectedItem = lvwCommands.SelectedItems[0];
            lvwCommands.Items.Remove(currentSelectedItem);
            lvwCommands.Items.Insert(currentSelectedItemIndex - 1, currentSelectedItem);
            lvwCommands.Items[currentSelectedItemIndex - 1].Selected = true;
            lvwCommands.Select();

            SaveCommands();
        }

        private void btnCommandItemDown_Click(object sender, EventArgs e)
        {
            var currentSelectedItemIndex = lvwCommands.SelectedItems[0].Index;
            var currentSelectedItem = lvwCommands.SelectedItems[0];
            lvwCommands.Items.Remove(currentSelectedItem);
            lvwCommands.Items.Insert(currentSelectedItemIndex + 1, currentSelectedItem);
            lvwCommands.Items[currentSelectedItemIndex + 1].Selected = true;
            lvwCommands.Select();

            SaveCommands();
        }

        private void SaveCommands()
        {
            var apkCommands = (from ListViewItem item in lvwCommands.Items select (ApkCommand)item.Tag).ToList();
            SqliteConnector.SetCommands(apkCommands);
        }

        private void btnRegisterShellExt_Click(object sender, EventArgs e)
        {
			if (clsUtils.GetAssemblyArchitecture() == clsUtils.GetOsArchitecture())
			{
				try
				{
				    var psi = new ProcessStartInfo
				    {
				        FileName = Path.Combine(Application.StartupPath, "LocalAPK.exe"),
				        Arguments = "/registershellext",
				        Verb = "runas"
				    };

				    var process = new Process();
					process.StartInfo = psi;
					process.Start();
					process.WaitForExit();

					MessageBox.Show("Shell extensions has been installed. A reboot might be required for the changes to take effect.",
						"Shell extension installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch
				{

				}
				finally
				{
					CheckShellExt();
				}
			}
			else
			{
				MessageBox.Show("Installing Shell Extension failed. Please download the correct version of LocalAPK for your OS Architecture.", "Architecture mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error); 
			}
            
        }

        private void btnUnregisterShellExt_Click(object sender, EventArgs e)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = Path.Combine(Application.StartupPath, "LocalAPK.exe"),
                    Arguments = "/unregistershellext",
                    Verb = "runas"
                };

                var process = new Process();
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();
            }
            catch
            {

            }
            finally
            {
                CheckShellExt();
            }
        }

        private void frmSettings_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void chkGroupResults_Click(object sender, EventArgs e)
        {
            SqliteConnector.SetSettingValue(SettingEnum.GroupResults, chkGroupResults.Checked.ToString().ToLower());
            SettingsChanged = true;
        }

        private void chkLatestVersionDownload_Click(object sender, EventArgs e)
        {
            SqliteConnector.SetSettingValue(SettingEnum.AutoFetchGooglePlay, chkFetchGooglePlay.Checked.ToString().ToLower());
            SettingsChanged = true;
        }

        private void chkStartupSearch_Click(object sender, EventArgs e)
        {
            SqliteConnector.SetSettingValue(SettingEnum.StartupRefresh, chkStartupSearch.Checked.ToString().ToLower());
            SettingsChanged = true;
        }

        private void chkNewGroupSub_Click(object sender, EventArgs e)
        {
            SqliteConnector.SetSettingValue(SettingEnum.SubdirGroup, chkNewGroupSub.Checked.ToString().ToLower());
            SettingsChanged = true;
        }

        private void btnCacheClearIcons_Click(object sender, EventArgs e)
        {
            SqliteConnector.CleanupCacheIcons();
            UpdateCacheSize();
        }

        private void btnCacheClearAll_Click(object sender, EventArgs e)
        {
            SqliteConnector.CleanupCacheAll();
            UpdateCacheSize();
        }
    }
}