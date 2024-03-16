using System.Drawing;
using System.Windows.Forms;

namespace LocalAPK
{
	public partial class frmLog : Form
	{
		public frmLog(string logText)
		{
			InitializeComponent();

			txtLog.Text = logText;
		}

		private void frmLog_Shown(object sender, System.EventArgs e)
		{
			txtLog.SelectionStart = txtLog.Text.Length;
			txtLog.ScrollToCaret();

			//Change log backcolor
			txtLog.BackColor = SystemColors.Window;
		}

		private void frmLog_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void txtLog_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
