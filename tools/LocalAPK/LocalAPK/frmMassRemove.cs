using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using LocalAPK.Data;

namespace LocalAPK
{
    public partial class frmMassRemove : Form
    {
	    readonly ListView lvMain;
        public frmMassRemove(ListView lvMain)
        {
            InitializeComponent();
            this.lvMain = lvMain;
        }

        private void chkOutdated_CheckedChanged(object sender, EventArgs e)
        {
            checkStart();
        }

        private void chkUnknown_CheckedChanged(object sender, EventArgs e)
        {
            checkStart();
        }

        private void checkStart()
        {
            if ((chkOutdated.Checked) || (chkUnknown.Checked))
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var items = lvMain.Items;

            foreach (ListViewItem lvi in items)
            {
                if (chkOutdated.Checked)
                {
                    if (lvi.SubItems[(int) ApkColumn.LocalVersion].BackColor == Color.PaleVioletRed)
                    {
                        try
                        {
	                        var apkFile = (ApkFile) lvi.Tag;
                            File.Delete(apkFile.LongFileName);
                            lvMain.Items.Remove(lvi);
                        }
                        catch
                        {
                            //do nothing
                        }
                    }
                }
                if (chkUnknown.Checked)
                {
					if ((lvi.SubItems[(int)ApkColumn.LocalVersion].BackColor != Color.PaleVioletRed) && (lvi.SubItems[(int)ApkColumn.LocalVersion].BackColor != Color.LightGreen))
					{
                        try
                        {
							var apkFile = (ApkFile)lvi.Tag;
                            File.Delete(apkFile.LongFileName);
                            lvMain.Items.Remove(lvi);
                        }
                        catch
                        {
                            //do nothing
                        }
                    }
                }
            }

            Close();
        }

        private void frmMassRemove_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
