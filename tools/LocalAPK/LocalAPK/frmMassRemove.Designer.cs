namespace LocalAPK
{
    partial class frmMassRemove
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkOutdated = new System.Windows.Forms.CheckBox();
            this.chkUnknown = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkOutdated
            // 
            this.chkOutdated.AutoSize = true;
            this.chkOutdated.Location = new System.Drawing.Point(12, 12);
            this.chkOutdated.Name = "chkOutdated";
            this.chkOutdated.Size = new System.Drawing.Size(124, 17);
            this.chkOutdated.TabIndex = 0;
            this.chkOutdated.Text = "Remove all outdated";
            this.chkOutdated.UseVisualStyleBackColor = true;
            this.chkOutdated.CheckedChanged += new System.EventHandler(this.chkOutdated_CheckedChanged);
            // 
            // chkUnknown
            // 
            this.chkUnknown.AutoSize = true;
            this.chkUnknown.Location = new System.Drawing.Point(12, 35);
            this.chkUnknown.Name = "chkUnknown";
            this.chkUnknown.Size = new System.Drawing.Size(126, 17);
            this.chkUnknown.TabIndex = 1;
            this.chkUnknown.Text = "Remove all unknown";
            this.chkUnknown.UseVisualStyleBackColor = true;
            this.chkUnknown.CheckedChanged += new System.EventHandler(this.chkUnknown_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(197, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(116, 62);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmMassRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkUnknown);
            this.Controls.Add(this.chkOutdated);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMassRemove";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mass Remove";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMassRemove_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOutdated;
        private System.Windows.Forms.CheckBox chkUnknown;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStart;
    }
}