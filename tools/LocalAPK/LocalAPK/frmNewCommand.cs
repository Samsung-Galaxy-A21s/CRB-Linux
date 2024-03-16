using System;
using System.Windows.Forms;
using LocalAPK.Data;

namespace LocalAPK
{
    public partial class frmNewCommand : Form
    {
        public delegate void CommandAdded(object sender, ApkCommand command);
        public event CommandAdded OnCommandAdded;

        public frmNewCommand()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtTitle.Text != string.Empty) && (txtCommand.Text != string.Empty))
            {
                var apkCommand = new ApkCommand
                {
                    Title = txtTitle.Text,
                    Command = txtCommand.Text
                };

                OnCommandAdded?.Invoke(this, apkCommand);

                Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmNewCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
