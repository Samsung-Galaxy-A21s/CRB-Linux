using System;
using System.Windows.Forms;

namespace LocalAPK
{
    public partial class frmRename : Form
    {
	    public string ResultText { get; private set; }
		public bool OkPressed { get; private set; }

	    public frmRename(string currentFilename)
        {
            InitializeComponent();
            txtFilename.Text = currentFilename;
            txtFilename.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
	        OkPressed = true;
            ResultText = txtFilename.Text;
            Close();
        }

        private void frmRename_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
