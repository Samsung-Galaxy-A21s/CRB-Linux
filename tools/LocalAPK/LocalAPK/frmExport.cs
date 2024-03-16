using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LocalAPK.Data;
using LocalAPK.DA;

namespace LocalAPK
{
    public partial class frmExport : Form
    {
        private List<ApkFile> _apkFiles;

        public frmExport(List<ApkFile> apkFiles)
        {
            InitializeComponent();

            _apkFiles = apkFiles;

            var delimiter = SqliteConnector.GetSettingValue(SettingEnum.ExportDelimiter);
            if (!string.IsNullOrWhiteSpace(delimiter))
            {
                txtDelimiter.Text = delimiter;
            }
            else
            {
                txtDelimiter.Text = "\\t";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var outputString = new StringBuilder();
            var delimiter = txtDelimiter.Text;
            foreach (var apkFile in _apkFiles)
            {
                outputString.Append(apkFile.ShortFileName); //ShortFileName
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.DirectoryName); //DirectoryName
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.LongFileName); //LongFileName
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.PackageName); //PackageName
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.InternalName); //InternalName
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.GooglePlayName); //GooglePlayName
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.Category); //Category
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.LocalVersion); //LocalVersion
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.LatestVersion); //LatestVersion
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.Append(apkFile.Price); //Price
                outputString.Append(delimiter.Equals("\\t") ? "\t" : delimiter); //Delimiter
                outputString.AppendLine(); //New line
            }

            var longFilename = SqliteConnector.GetSettingValue(SettingEnum.ExportFilename);
            var shortFilename = Path.GetFileName(longFilename);
            var directory = Path.GetDirectoryName(longFilename);

            if (!string.IsNullOrWhiteSpace(longFilename))
            {
                sfdMain.FileName = shortFilename;
                if (Directory.Exists(directory))
                {
                    sfdMain.InitialDirectory = directory;
                }
            }
            if (sfdMain.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfdMain.FileName, outputString.ToString());
                SqliteConnector.SetSettingValue(SettingEnum.ExportDelimiter, txtDelimiter.Text);
                SqliteConnector.SetSettingValue(SettingEnum.ExportFilename, sfdMain.FileName);
                Close();
            }
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            cboFiletype.SelectedIndex = 0;
        }
    }
}