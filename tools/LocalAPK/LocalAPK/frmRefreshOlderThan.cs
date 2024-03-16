using System;
using System.Windows.Forms;
using LocalAPK.Data;
using LocalAPK.DA;

namespace LocalAPK
{
    public partial class frmRefreshOlderThan : Form
    {
        public delegate void RefreshOlderThanStartButtonClicked(object sender, int days);
        public event RefreshOlderThanStartButtonClicked OnRefreshOlderThanStartButtonClicked;

        public frmRefreshOlderThan()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SqliteConnector.SetSettingValue(SettingEnum.RefreshDays, Convert.ToString(tbMain.Value));
            OnRefreshOlderThanStartButtonClicked?.Invoke(this, tbMain.Value);
            Close();
        }

        private void tbMain_ValueChanged(object sender, EventArgs e)
        {
            SetMainLabel();
        }

        private void frmRefreshOlderThan_Load(object sender, EventArgs e)
        {
            tbMain.Value = Convert.ToInt32(SqliteConnector.GetSettingValue(SettingEnum.RefreshDays));
            SetMainLabel();
        }

        private void SetMainLabel()
        {
            if (tbMain.Value == 1)
            {
                lblMain.Text = string.Format("Refresh details older than {0} day", tbMain.Value);
            }
            else
            {
                lblMain.Text = string.Format("Refresh details older than {0} days", tbMain.Value);
            }
        }
    }
}
