namespace LocalAPK
{
    partial class frmSettings
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
            this.gpbScanFolder = new System.Windows.Forms.GroupBox();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.lstScanFolders = new System.Windows.Forms.ListBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.gpbGrouping = new System.Windows.Forms.GroupBox();
            this.chkNewGroupSub = new System.Windows.Forms.CheckBox();
            this.chkGroupResults = new System.Windows.Forms.CheckBox();
            this.gpbGeneral = new System.Windows.Forms.GroupBox();
            this.chkFetchGooglePlay = new System.Windows.Forms.CheckBox();
            this.chkStartupSearch = new System.Windows.Forms.CheckBox();
            this.tpScanFolders = new System.Windows.Forms.TabPage();
            this.tpCommands = new System.Windows.Forms.TabPage();
            this.gpbCommands = new System.Windows.Forms.GroupBox();
            this.btnCommandItemDown = new System.Windows.Forms.Button();
            this.btnCommandItemUp = new System.Windows.Forms.Button();
            this.btnAddCommand = new System.Windows.Forms.Button();
            this.btnRemoveCommand = new System.Windows.Forms.Button();
            this.lvwCommands = new System.Windows.Forms.ListView();
            this.clmnhTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnhCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpShellExtension = new System.Windows.Forms.TabPage();
            this.pnlShellExtPortable = new System.Windows.Forms.Panel();
            this.lblPortableMode = new System.Windows.Forms.Label();
            this.pnlShellExtRegistered = new System.Windows.Forms.Panel();
            this.gpbUninstallShellExt = new System.Windows.Forms.GroupBox();
            this.btnUnregisterShellExt = new System.Windows.Forms.Button();
            this.gpbInstallShellExt = new System.Windows.Forms.GroupBox();
            this.btnRegisterShellExt = new System.Windows.Forms.Button();
            this.tpCache = new System.Windows.Forms.TabPage();
            this.gpbCacheCleanup = new System.Windows.Forms.GroupBox();
            this.btnCacheClearIcons = new System.Windows.Forms.Button();
            this.btnCacheClearAll = new System.Windows.Forms.Button();
            this.gpbCacheInformation = new System.Windows.Forms.GroupBox();
            this.lblCacheInformation = new System.Windows.Forms.Label();
            this.gpbScanFolder.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.gpbGrouping.SuspendLayout();
            this.gpbGeneral.SuspendLayout();
            this.tpScanFolders.SuspendLayout();
            this.tpCommands.SuspendLayout();
            this.gpbCommands.SuspendLayout();
            this.tpShellExtension.SuspendLayout();
            this.pnlShellExtPortable.SuspendLayout();
            this.pnlShellExtRegistered.SuspendLayout();
            this.gpbUninstallShellExt.SuspendLayout();
            this.gpbInstallShellExt.SuspendLayout();
            this.tpCache.SuspendLayout();
            this.gpbCacheCleanup.SuspendLayout();
            this.gpbCacheInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbScanFolder
            // 
            this.gpbScanFolder.Controls.Add(this.btnRemoveFolder);
            this.gpbScanFolder.Controls.Add(this.lstScanFolders);
            this.gpbScanFolder.Controls.Add(this.btnAddFolder);
            this.gpbScanFolder.Location = new System.Drawing.Point(8, 6);
            this.gpbScanFolder.Name = "gpbScanFolder";
            this.gpbScanFolder.Size = new System.Drawing.Size(456, 190);
            this.gpbScanFolder.TabIndex = 0;
            this.gpbScanFolder.TabStop = false;
            this.gpbScanFolder.Text = "Scan Folders";
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Enabled = false;
            this.btnRemoveFolder.Location = new System.Drawing.Point(375, 159);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFolder.TabIndex = 2;
            this.btnRemoveFolder.Text = "Remove";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // lstScanFolders
            // 
            this.lstScanFolders.FormattingEnabled = true;
            this.lstScanFolders.Location = new System.Drawing.Point(6, 19);
            this.lstScanFolders.Name = "lstScanFolders";
            this.lstScanFolders.Size = new System.Drawing.Size(444, 134);
            this.lstScanFolders.TabIndex = 0;
            this.lstScanFolders.SelectedIndexChanged += new System.EventHandler(this.lstScanFolders_SelectedIndexChanged);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(294, 159);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "Add";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(398, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.tpGeneral);
            this.tabSettings.Controls.Add(this.tpScanFolders);
            this.tabSettings.Controls.Add(this.tpCommands);
            this.tabSettings.Controls.Add(this.tpShellExtension);
            this.tabSettings.Controls.Add(this.tpCache);
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(480, 366);
            this.tabSettings.TabIndex = 2;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.gpbGrouping);
            this.tpGeneral.Controls.Add(this.gpbGeneral);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(472, 340);
            this.tpGeneral.TabIndex = 4;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // gpbGrouping
            // 
            this.gpbGrouping.Controls.Add(this.chkNewGroupSub);
            this.gpbGrouping.Controls.Add(this.chkGroupResults);
            this.gpbGrouping.Location = new System.Drawing.Point(10, 80);
            this.gpbGrouping.Name = "gpbGrouping";
            this.gpbGrouping.Size = new System.Drawing.Size(456, 70);
            this.gpbGrouping.TabIndex = 1;
            this.gpbGrouping.TabStop = false;
            this.gpbGrouping.Text = "Grouping";
            // 
            // chkNewGroupSub
            // 
            this.chkNewGroupSub.AutoSize = true;
            this.chkNewGroupSub.Checked = true;
            this.chkNewGroupSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewGroupSub.Location = new System.Drawing.Point(6, 42);
            this.chkNewGroupSub.Name = "chkNewGroupSub";
            this.chkNewGroupSub.Size = new System.Drawing.Size(168, 17);
            this.chkNewGroupSub.TabIndex = 3;
            this.chkNewGroupSub.Text = "New group for every subfolder";
            this.chkNewGroupSub.UseVisualStyleBackColor = true;
            this.chkNewGroupSub.Click += new System.EventHandler(this.chkNewGroupSub_Click);
            // 
            // chkGroupResults
            // 
            this.chkGroupResults.AutoSize = true;
            this.chkGroupResults.Checked = true;
            this.chkGroupResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGroupResults.Location = new System.Drawing.Point(6, 19);
            this.chkGroupResults.Name = "chkGroupResults";
            this.chkGroupResults.Size = new System.Drawing.Size(131, 17);
            this.chkGroupResults.TabIndex = 2;
            this.chkGroupResults.Text = "Group results by folder";
            this.chkGroupResults.UseVisualStyleBackColor = true;
            this.chkGroupResults.Click += new System.EventHandler(this.chkGroupResults_Click);
            // 
            // gpbGeneral
            // 
            this.gpbGeneral.Controls.Add(this.chkFetchGooglePlay);
            this.gpbGeneral.Controls.Add(this.chkStartupSearch);
            this.gpbGeneral.Location = new System.Drawing.Point(8, 6);
            this.gpbGeneral.Name = "gpbGeneral";
            this.gpbGeneral.Size = new System.Drawing.Size(456, 68);
            this.gpbGeneral.TabIndex = 0;
            this.gpbGeneral.TabStop = false;
            this.gpbGeneral.Text = "General";
            // 
            // chkFetchGooglePlay
            // 
            this.chkFetchGooglePlay.AutoSize = true;
            this.chkFetchGooglePlay.Checked = true;
            this.chkFetchGooglePlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFetchGooglePlay.Location = new System.Drawing.Point(6, 42);
            this.chkFetchGooglePlay.Name = "chkFetchGooglePlay";
            this.chkFetchGooglePlay.Size = new System.Drawing.Size(330, 17);
            this.chkFetchGooglePlay.TabIndex = 1;
            this.chkFetchGooglePlay.Text = "Fetch details from Google Play Store on startup for new APK files";
            this.chkFetchGooglePlay.UseVisualStyleBackColor = true;
            this.chkFetchGooglePlay.Click += new System.EventHandler(this.chkLatestVersionDownload_Click);
            // 
            // chkStartupSearch
            // 
            this.chkStartupSearch.AutoSize = true;
            this.chkStartupSearch.Checked = true;
            this.chkStartupSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartupSearch.Location = new System.Drawing.Point(6, 19);
            this.chkStartupSearch.Name = "chkStartupSearch";
            this.chkStartupSearch.Size = new System.Drawing.Size(173, 17);
            this.chkStartupSearch.TabIndex = 0;
            this.chkStartupSearch.Text = "Automatically refresh on startup";
            this.chkStartupSearch.UseVisualStyleBackColor = true;
            this.chkStartupSearch.Click += new System.EventHandler(this.chkStartupSearch_Click);
            // 
            // tpScanFolders
            // 
            this.tpScanFolders.Controls.Add(this.gpbScanFolder);
            this.tpScanFolders.Location = new System.Drawing.Point(4, 22);
            this.tpScanFolders.Name = "tpScanFolders";
            this.tpScanFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tpScanFolders.Size = new System.Drawing.Size(472, 340);
            this.tpScanFolders.TabIndex = 0;
            this.tpScanFolders.Text = "Scan Folders";
            this.tpScanFolders.UseVisualStyleBackColor = true;
            // 
            // tpCommands
            // 
            this.tpCommands.Controls.Add(this.gpbCommands);
            this.tpCommands.Location = new System.Drawing.Point(4, 22);
            this.tpCommands.Name = "tpCommands";
            this.tpCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tpCommands.Size = new System.Drawing.Size(472, 340);
            this.tpCommands.TabIndex = 1;
            this.tpCommands.Text = "Commands";
            this.tpCommands.UseVisualStyleBackColor = true;
            // 
            // gpbCommands
            // 
            this.gpbCommands.Controls.Add(this.btnCommandItemDown);
            this.gpbCommands.Controls.Add(this.btnCommandItemUp);
            this.gpbCommands.Controls.Add(this.btnAddCommand);
            this.gpbCommands.Controls.Add(this.btnRemoveCommand);
            this.gpbCommands.Controls.Add(this.lvwCommands);
            this.gpbCommands.Location = new System.Drawing.Point(8, 6);
            this.gpbCommands.Name = "gpbCommands";
            this.gpbCommands.Size = new System.Drawing.Size(456, 269);
            this.gpbCommands.TabIndex = 2;
            this.gpbCommands.TabStop = false;
            this.gpbCommands.Text = "Commands";
            // 
            // btnCommandItemDown
            // 
            this.btnCommandItemDown.Enabled = false;
            this.btnCommandItemDown.Location = new System.Drawing.Point(424, 130);
            this.btnCommandItemDown.Name = "btnCommandItemDown";
            this.btnCommandItemDown.Size = new System.Drawing.Size(26, 23);
            this.btnCommandItemDown.TabIndex = 11;
            this.btnCommandItemDown.Text = "˅";
            this.btnCommandItemDown.UseVisualStyleBackColor = true;
            this.btnCommandItemDown.Click += new System.EventHandler(this.btnCommandItemDown_Click);
            // 
            // btnCommandItemUp
            // 
            this.btnCommandItemUp.Enabled = false;
            this.btnCommandItemUp.Location = new System.Drawing.Point(424, 101);
            this.btnCommandItemUp.Name = "btnCommandItemUp";
            this.btnCommandItemUp.Size = new System.Drawing.Size(26, 23);
            this.btnCommandItemUp.TabIndex = 10;
            this.btnCommandItemUp.Text = "˄";
            this.btnCommandItemUp.UseVisualStyleBackColor = true;
            this.btnCommandItemUp.Click += new System.EventHandler(this.btnCommandItemUp_Click);
            // 
            // btnAddCommand
            // 
            this.btnAddCommand.Location = new System.Drawing.Point(294, 239);
            this.btnAddCommand.Name = "btnAddCommand";
            this.btnAddCommand.Size = new System.Drawing.Size(75, 23);
            this.btnAddCommand.TabIndex = 9;
            this.btnAddCommand.Text = "Add";
            this.btnAddCommand.UseVisualStyleBackColor = true;
            this.btnAddCommand.Click += new System.EventHandler(this.btnAddSearchProvider_Click);
            // 
            // btnRemoveCommand
            // 
            this.btnRemoveCommand.Enabled = false;
            this.btnRemoveCommand.Location = new System.Drawing.Point(375, 239);
            this.btnRemoveCommand.Name = "btnRemoveCommand";
            this.btnRemoveCommand.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCommand.TabIndex = 8;
            this.btnRemoveCommand.Text = "Remove";
            this.btnRemoveCommand.UseVisualStyleBackColor = true;
            this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveSearchProvider_Click);
            // 
            // lvwCommands
            // 
            this.lvwCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnhTitle,
            this.clmnhCommand});
            this.lvwCommands.FullRowSelect = true;
            this.lvwCommands.HideSelection = false;
            this.lvwCommands.Location = new System.Drawing.Point(6, 19);
            this.lvwCommands.MultiSelect = false;
            this.lvwCommands.Name = "lvwCommands";
            this.lvwCommands.Size = new System.Drawing.Size(412, 214);
            this.lvwCommands.TabIndex = 1;
            this.lvwCommands.UseCompatibleStateImageBehavior = false;
            this.lvwCommands.View = System.Windows.Forms.View.Details;
            this.lvwCommands.SelectedIndexChanged += new System.EventHandler(this.lvwCommands_SelectedIndexChanged);
            // 
            // clmnhTitle
            // 
            this.clmnhTitle.Text = "Title";
            this.clmnhTitle.Width = 110;
            // 
            // clmnhCommand
            // 
            this.clmnhCommand.Text = "Command";
            this.clmnhCommand.Width = 265;
            // 
            // tpShellExtension
            // 
            this.tpShellExtension.Controls.Add(this.pnlShellExtPortable);
            this.tpShellExtension.Controls.Add(this.pnlShellExtRegistered);
            this.tpShellExtension.Location = new System.Drawing.Point(4, 22);
            this.tpShellExtension.Name = "tpShellExtension";
            this.tpShellExtension.Padding = new System.Windows.Forms.Padding(3);
            this.tpShellExtension.Size = new System.Drawing.Size(472, 340);
            this.tpShellExtension.TabIndex = 3;
            this.tpShellExtension.Text = "Shell Extension";
            this.tpShellExtension.UseVisualStyleBackColor = true;
            // 
            // pnlShellExtPortable
            // 
            this.pnlShellExtPortable.Controls.Add(this.lblPortableMode);
            this.pnlShellExtPortable.Location = new System.Drawing.Point(8, 196);
            this.pnlShellExtPortable.Name = "pnlShellExtPortable";
            this.pnlShellExtPortable.Size = new System.Drawing.Size(456, 100);
            this.pnlShellExtPortable.TabIndex = 4;
            // 
            // lblPortableMode
            // 
            this.lblPortableMode.AutoSize = true;
            this.lblPortableMode.Location = new System.Drawing.Point(3, 3);
            this.lblPortableMode.Name = "lblPortableMode";
            this.lblPortableMode.Size = new System.Drawing.Size(226, 13);
            this.lblPortableMode.TabIndex = 0;
            this.lblPortableMode.Text = "Shell Extension not available in portable mode.";
            // 
            // pnlShellExtRegistered
            // 
            this.pnlShellExtRegistered.Controls.Add(this.gpbUninstallShellExt);
            this.pnlShellExtRegistered.Controls.Add(this.gpbInstallShellExt);
            this.pnlShellExtRegistered.Location = new System.Drawing.Point(8, 59);
            this.pnlShellExtRegistered.Name = "pnlShellExtRegistered";
            this.pnlShellExtRegistered.Size = new System.Drawing.Size(456, 131);
            this.pnlShellExtRegistered.TabIndex = 3;
            // 
            // gpbUninstallShellExt
            // 
            this.gpbUninstallShellExt.Controls.Add(this.btnUnregisterShellExt);
            this.gpbUninstallShellExt.Location = new System.Drawing.Point(6, 64);
            this.gpbUninstallShellExt.Name = "gpbUninstallShellExt";
            this.gpbUninstallShellExt.Size = new System.Drawing.Size(447, 55);
            this.gpbUninstallShellExt.TabIndex = 3;
            this.gpbUninstallShellExt.TabStop = false;
            this.gpbUninstallShellExt.Text = "Uninstall";
            // 
            // btnUnregisterShellExt
            // 
            this.btnUnregisterShellExt.Location = new System.Drawing.Point(130, 19);
            this.btnUnregisterShellExt.Name = "btnUnregisterShellExt";
            this.btnUnregisterShellExt.Size = new System.Drawing.Size(187, 23);
            this.btnUnregisterShellExt.TabIndex = 1;
            this.btnUnregisterShellExt.Text = "Uninstall Shell Extension";
            this.btnUnregisterShellExt.UseVisualStyleBackColor = true;
            this.btnUnregisterShellExt.Click += new System.EventHandler(this.btnUnregisterShellExt_Click);
            // 
            // gpbInstallShellExt
            // 
            this.gpbInstallShellExt.Controls.Add(this.btnRegisterShellExt);
            this.gpbInstallShellExt.Location = new System.Drawing.Point(6, 3);
            this.gpbInstallShellExt.Name = "gpbInstallShellExt";
            this.gpbInstallShellExt.Size = new System.Drawing.Size(447, 55);
            this.gpbInstallShellExt.TabIndex = 2;
            this.gpbInstallShellExt.TabStop = false;
            this.gpbInstallShellExt.Text = "Install";
            // 
            // btnRegisterShellExt
            // 
            this.btnRegisterShellExt.Location = new System.Drawing.Point(130, 19);
            this.btnRegisterShellExt.Name = "btnRegisterShellExt";
            this.btnRegisterShellExt.Size = new System.Drawing.Size(187, 23);
            this.btnRegisterShellExt.TabIndex = 0;
            this.btnRegisterShellExt.Text = "Install Shell Extension";
            this.btnRegisterShellExt.UseVisualStyleBackColor = true;
            this.btnRegisterShellExt.Click += new System.EventHandler(this.btnRegisterShellExt_Click);
            // 
            // tpCache
            // 
            this.tpCache.Controls.Add(this.gpbCacheCleanup);
            this.tpCache.Controls.Add(this.gpbCacheInformation);
            this.tpCache.Location = new System.Drawing.Point(4, 22);
            this.tpCache.Name = "tpCache";
            this.tpCache.Padding = new System.Windows.Forms.Padding(3);
            this.tpCache.Size = new System.Drawing.Size(472, 340);
            this.tpCache.TabIndex = 5;
            this.tpCache.Text = "Cache";
            this.tpCache.UseVisualStyleBackColor = true;
            // 
            // gpbCacheCleanup
            // 
            this.gpbCacheCleanup.Controls.Add(this.btnCacheClearIcons);
            this.gpbCacheCleanup.Controls.Add(this.btnCacheClearAll);
            this.gpbCacheCleanup.Location = new System.Drawing.Point(8, 52);
            this.gpbCacheCleanup.Name = "gpbCacheCleanup";
            this.gpbCacheCleanup.Size = new System.Drawing.Size(456, 84);
            this.gpbCacheCleanup.TabIndex = 1;
            this.gpbCacheCleanup.TabStop = false;
            this.gpbCacheCleanup.Text = "Cleanup";
            // 
            // btnCacheClearIcons
            // 
            this.btnCacheClearIcons.Location = new System.Drawing.Point(136, 48);
            this.btnCacheClearIcons.Name = "btnCacheClearIcons";
            this.btnCacheClearIcons.Size = new System.Drawing.Size(187, 23);
            this.btnCacheClearIcons.TabIndex = 1;
            this.btnCacheClearIcons.Text = "Clear icon cache";
            this.btnCacheClearIcons.UseVisualStyleBackColor = true;
            this.btnCacheClearIcons.Click += new System.EventHandler(this.btnCacheClearIcons_Click);
            // 
            // btnCacheClearAll
            // 
            this.btnCacheClearAll.Location = new System.Drawing.Point(136, 19);
            this.btnCacheClearAll.Name = "btnCacheClearAll";
            this.btnCacheClearAll.Size = new System.Drawing.Size(187, 23);
            this.btnCacheClearAll.TabIndex = 0;
            this.btnCacheClearAll.Text = "Clear all cache";
            this.btnCacheClearAll.UseVisualStyleBackColor = true;
            this.btnCacheClearAll.Click += new System.EventHandler(this.btnCacheClearAll_Click);
            // 
            // gpbCacheInformation
            // 
            this.gpbCacheInformation.Controls.Add(this.lblCacheInformation);
            this.gpbCacheInformation.Location = new System.Drawing.Point(8, 6);
            this.gpbCacheInformation.Name = "gpbCacheInformation";
            this.gpbCacheInformation.Size = new System.Drawing.Size(456, 40);
            this.gpbCacheInformation.TabIndex = 0;
            this.gpbCacheInformation.TabStop = false;
            this.gpbCacheInformation.Text = "Information";
            // 
            // lblCacheInformation
            // 
            this.lblCacheInformation.AutoSize = true;
            this.lblCacheInformation.Location = new System.Drawing.Point(6, 16);
            this.lblCacheInformation.Name = "lblCacheInformation";
            this.lblCacheInformation.Size = new System.Drawing.Size(200, 13);
            this.lblCacheInformation.TabIndex = 0;
            this.lblCacheInformation.Text = "The size of the cache is currently XX KB.";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 405);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyUp);
            this.gpbScanFolder.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.gpbGrouping.ResumeLayout(false);
            this.gpbGrouping.PerformLayout();
            this.gpbGeneral.ResumeLayout(false);
            this.gpbGeneral.PerformLayout();
            this.tpScanFolders.ResumeLayout(false);
            this.tpCommands.ResumeLayout(false);
            this.gpbCommands.ResumeLayout(false);
            this.tpShellExtension.ResumeLayout(false);
            this.pnlShellExtPortable.ResumeLayout(false);
            this.pnlShellExtPortable.PerformLayout();
            this.pnlShellExtRegistered.ResumeLayout(false);
            this.gpbUninstallShellExt.ResumeLayout(false);
            this.gpbInstallShellExt.ResumeLayout(false);
            this.tpCache.ResumeLayout(false);
            this.gpbCacheCleanup.ResumeLayout(false);
            this.gpbCacheInformation.ResumeLayout(false);
            this.gpbCacheInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbScanFolder;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.ListBox lstScanFolders;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tpScanFolders;
        private System.Windows.Forms.TabPage tpCommands;
        private System.Windows.Forms.GroupBox gpbCommands;
        private System.Windows.Forms.ListView lvwCommands;
        private System.Windows.Forms.ColumnHeader clmnhTitle;
        private System.Windows.Forms.ColumnHeader clmnhCommand;
        private System.Windows.Forms.Button btnAddCommand;
        private System.Windows.Forms.Button btnRemoveCommand;
        private System.Windows.Forms.Button btnCommandItemDown;
        private System.Windows.Forms.Button btnCommandItemUp;
        private System.Windows.Forms.TabPage tpShellExtension;
        private System.Windows.Forms.Button btnUnregisterShellExt;
        private System.Windows.Forms.Button btnRegisterShellExt;
        private System.Windows.Forms.Panel pnlShellExtRegistered;
        private System.Windows.Forms.GroupBox gpbUninstallShellExt;
        private System.Windows.Forms.GroupBox gpbInstallShellExt;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.GroupBox gpbGeneral;
        private System.Windows.Forms.CheckBox chkFetchGooglePlay;
        private System.Windows.Forms.CheckBox chkStartupSearch;
        private System.Windows.Forms.CheckBox chkGroupResults;
		private System.Windows.Forms.CheckBox chkNewGroupSub;
		private System.Windows.Forms.GroupBox gpbGrouping;
        private System.Windows.Forms.Panel pnlShellExtPortable;
        private System.Windows.Forms.Label lblPortableMode;
        private System.Windows.Forms.TabPage tpCache;
        private System.Windows.Forms.GroupBox gpbCacheInformation;
        private System.Windows.Forms.Label lblCacheInformation;
        private System.Windows.Forms.GroupBox gpbCacheCleanup;
        private System.Windows.Forms.Button btnCacheClearIcons;
        private System.Windows.Forms.Button btnCacheClearAll;
    }
}