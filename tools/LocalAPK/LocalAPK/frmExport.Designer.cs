namespace LocalAPK
{
    partial class frmExport
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
            this.lblFiletype = new System.Windows.Forms.Label();
            this.cboFiletype = new System.Windows.Forms.ComboBox();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.lblTabHint = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // lblFiletype
            // 
            this.lblFiletype.AutoSize = true;
            this.lblFiletype.Location = new System.Drawing.Point(12, 9);
            this.lblFiletype.Name = "lblFiletype";
            this.lblFiletype.Size = new System.Drawing.Size(46, 13);
            this.lblFiletype.TabIndex = 0;
            this.lblFiletype.Text = "Filetype:";
            // 
            // cboFiletype
            // 
            this.cboFiletype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiletype.FormattingEnabled = true;
            this.cboFiletype.Items.AddRange(new object[] {
            "CSV file (*.csv)"});
            this.cboFiletype.Location = new System.Drawing.Point(12, 25);
            this.cboFiletype.Name = "cboFiletype";
            this.cboFiletype.Size = new System.Drawing.Size(260, 21);
            this.cboFiletype.TabIndex = 1;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(12, 49);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(50, 13);
            this.lblDelimiter.TabIndex = 2;
            this.lblDelimiter.Text = "Delimiter:";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(12, 65);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(260, 20);
            this.txtDelimiter.TabIndex = 3;
            // 
            // lblTabHint
            // 
            this.lblTabHint.AutoSize = true;
            this.lblTabHint.Location = new System.Drawing.Point(172, 88);
            this.lblTabHint.Name = "lblTabHint";
            this.lblTabHint.Size = new System.Drawing.Size(100, 13);
            this.lblTabHint.TabIndex = 4;
            this.lblTabHint.Text = "Hint: Use \\t for tabs";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // sfdMain
            // 
            this.sfdMain.DefaultExt = "csv";
            this.sfdMain.Filter = "CSV files|*.csv";
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 134);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTabHint);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.cboFiletype);
            this.Controls.Add(this.lblFiletype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiletype;
        private System.Windows.Forms.ComboBox cboFiletype;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label lblTabHint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.SaveFileDialog sfdMain;
    }
}