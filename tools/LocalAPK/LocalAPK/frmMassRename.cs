using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LocalAPK.DA;
using LocalAPK.Data;

namespace LocalAPK
{
    public partial class frmMassRename : Form
    {
	    private const string UnknownString = "Unknown";

	    readonly ListView _lvMain;
	    readonly bool _isSelection;
	    readonly Label _lblFileNameValue;

        public frmMassRename(ListView lvMain, Label lblFileNameValue, bool isSelection)
        {
            InitializeComponent();
            _lvMain = lvMain;
            _isSelection = isSelection;
			_lblFileNameValue = lblFileNameValue;
            if (isSelection)
            {
                Text = "Rename Selection";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SqliteConnector.SetSettingValue(SettingEnum.MassRenameString, txtFormat.Text);

            var listRenamedOld = new List<string>();
	        var listRenamedNew = new List<string>();
	        var listSkippedUnknown = new List<string>();
	        var listSkippedFailed = new List<string>();
	        var listSkippedAlreadyExists = new List<string>();

            if (_isSelection)
            {
                var items = _lvMain.SelectedItems;
                foreach (ListViewItem lvi in items)
                {
	                var apkFile = (ApkFile) lvi.Tag;
                    var format = txtFormat.Text;

					if (format.Contains("{packagename}") && (apkFile.PackageName == UnknownString || string.IsNullOrWhiteSpace(apkFile.PackageName)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{appname}") && (apkFile.InternalName == UnknownString || string.IsNullOrWhiteSpace(apkFile.InternalName)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{playname}") && (apkFile.GooglePlayName == UnknownString || string.IsNullOrWhiteSpace(apkFile.GooglePlayName)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{category}") && (apkFile.Category == UnknownString || string.IsNullOrWhiteSpace(apkFile.Category)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{localversion}") && (apkFile.LocalVersion == UnknownString || string.IsNullOrWhiteSpace(apkFile.LocalVersion)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					
					format = format.Replace("{packagename}", apkFile.PackageName);
					format = format.Replace("{appname}", apkFile.InternalName);
					format = format.Replace("{playname}", apkFile.GooglePlayName);
					format = format.Replace("{category}", apkFile.Category);
                    format = format.Replace("{localversion}", apkFile.LocalVersion);

                    var newShortFilename = clsUtils.LegalizeFilename(format);
                    var newLongFilename = Path.Combine(apkFile.DirectoryName, newShortFilename);

                    if (!File.Exists(newLongFilename))
                    {
                        try
                        {
                            File.Move(apkFile.LongFileName, newLongFilename);
							listRenamedOld.Add(apkFile.LongFileName);
							listRenamedNew.Add(newLongFilename);

							lvi.SubItems[(int)ApkColumn.FileName].Text = newShortFilename;
	                        apkFile.LongFileName = newLongFilename;
                        }
                        catch
                        {
                            listSkippedFailed.Add(apkFile.LongFileName);
                        }
                    }
                    else
                    {
                        listSkippedAlreadyExists.Add(apkFile.LongFileName);
                    }
                }
            }
            else
            {
                var items = _lvMain.Items;
                foreach (ListViewItem lvi in items)
                {
	                var apkFile = (ApkFile) lvi.Tag;
                    var format = txtFormat.Text;

					if (format.Contains("{packagename}") && (apkFile.PackageName == UnknownString || string.IsNullOrWhiteSpace(apkFile.PackageName)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{appname}") && (apkFile.InternalName == UnknownString || string.IsNullOrWhiteSpace(apkFile.InternalName)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{playname}") && (apkFile.GooglePlayName == UnknownString || string.IsNullOrWhiteSpace(apkFile.GooglePlayName)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{category}") && (apkFile.Category == UnknownString || string.IsNullOrWhiteSpace(apkFile.Category)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}
					if (format.Contains("{localversion}") && (apkFile.LocalVersion == UnknownString || string.IsNullOrWhiteSpace(apkFile.LocalVersion)))
					{
						listSkippedUnknown.Add(apkFile.LongFileName);
						continue;
					}

					format = format.Replace("{packagename}", apkFile.PackageName);
					format = format.Replace("{appname}", apkFile.InternalName);
					format = format.Replace("{playname}", apkFile.GooglePlayName);
					format = format.Replace("{category}", apkFile.Category);
                    format = format.Replace("{localversion}", apkFile.LocalVersion);

                    var newShortFilename = clsUtils.LegalizeFilename(format);
                    var newLongFilename = apkFile.DirectoryName + "\\" + newShortFilename;

                    if (!File.Exists(newLongFilename))
                    {
                        try
                        {
                            File.Move(apkFile.LongFileName, newLongFilename);
							listRenamedOld.Add(apkFile.LongFileName);
							listRenamedNew.Add(newLongFilename);

							lvi.SubItems[(int)ApkColumn.FileName].Text = newShortFilename;
							if (_lvMain.SelectedItems.Count == 1 && _lvMain.SelectedItems[0].Index == lvi.Index)
							{
								_lblFileNameValue.Text = newShortFilename;
							}
	                        apkFile.LongFileName = newLongFilename;
                        }
                        catch
                        {
                            listSkippedFailed.Add(apkFile.LongFileName);
                        }
                    }
                    else
                    {
                        listSkippedAlreadyExists.Add(apkFile.LongFileName);
                    }
                }
            }

            //Renaming done
	        var totalRenamed = listRenamedNew.Count;
	        var totalSkipped = (listSkippedAlreadyExists.Count + listSkippedFailed.Count + listSkippedUnknown.Count);
			var oldBiggestCharCount = listRenamedOld.Select(Path.GetFileName).Select(fileName => fileName.Length).Concat(new[] { 1 }).Max();
			var newBiggestCharCount = listRenamedNew.Select(Path.GetFileName).Select(fileName => fileName.Length).Concat(new[] { 1 }).Max();

	        if (
		        MessageBox.Show(
			        string.Format(
				        "{0} files have been renamed.{1}{2} files have been skipped.{1}Show an overview of renamed/skipped files?",
				        totalRenamed, Environment.NewLine, totalSkipped), "Renaming finished", MessageBoxButtons.YesNo,
			        MessageBoxIcon.Information) == DialogResult.Yes)
	        {
				var sb = new StringBuilder();
		        if (totalRenamed > 0)
		        {
					sb.AppendLine("FILES RENAMED:");
					sb.AppendLine("---------------------------------");

					for (var i = 0; i < listRenamedOld.Count; i++)
					{
						var oldFilename = listRenamedOld[i];
						var newFilename = listRenamedNew[i];

						sb.AppendLine(string.Format("{0, -" + oldBiggestCharCount + "}{1}{2, -" + newBiggestCharCount + "} ({3})", Path.GetFileName(oldFilename), " => ", Path.GetFileName(newFilename), Path.GetDirectoryName(oldFilename)));
					}

					sb.AppendLine("---------------------------------");
		        }
		        if (totalSkipped > 0)
		        {
					sb.AppendLine("FILES SKIPPED:");
					sb.AppendLine("---------------------------------");

					foreach (var skippedFile in listSkippedAlreadyExists.Concat(listSkippedFailed).Concat(listSkippedUnknown))
					{
						sb.AppendLine(skippedFile);
					}

					sb.AppendLine("---------------------------------");
		        }
				
				sb.AppendLine("TOTAL:");
				sb.AppendLine("---------------------------------");
				sb.AppendLine(string.Format("Renamed: {0} files", totalRenamed));
				sb.AppendLine(string.Format("Skipped: {0} files", totalSkipped));

				var logForm = new frmLog(sb.ToString());
				logForm.ShowDialog();
	        }

	        Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMassRename_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

		private void frmMassRename_Load(object sender, EventArgs e)
		{
		    txtFormat.Text = SqliteConnector.GetSettingValue(SettingEnum.MassRenameString);
		}

		private void txtFormat_TextChanged(object sender, EventArgs e)
		{
			if (txtFormat.Text.Contains(".apk") && (txtFormat.Text.Contains("{packagename}") || txtFormat.Text.Contains("{appname}") || txtFormat.Text.Contains("{playname}")))
			{
				btnStart.Enabled = true;
			}
			else
			{
				btnStart.Enabled = false;
			}
		}
    }
}
