using System;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using LocalAPK.DA;

namespace LocalAPK
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            btnOK.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("http://breezie.be/dev/localapk");
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            
        }

		private void frmAbout_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void btnUpdates_Click(object sender, EventArgs e)
		{
			try
			{
				var wc = new WebClient();
				var latestVersion = wc.DownloadString("http://breezie.be/dev/localapk/latest.txt");

				if (latestVersion == "2.1.1")
				{
					MessageBox.Show("You are running the latest version of LocalAPK.", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(string.Format("You are running an outdated version of LocalAPK. Latest version is {0}.", latestVersion), "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch
			{
				MessageBox.Show("An error occured while checking for the latest version of LocalAPK.","Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}
    }
}
