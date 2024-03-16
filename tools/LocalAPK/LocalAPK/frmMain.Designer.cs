namespace LocalAPK
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMarketPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToPhoneQRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMainMulti = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshGooglePlay = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRefreshGooglePlayAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefreshGooglePlaySelection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefreshGooglePlayOlder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.tssOne = new System.Windows.Forms.ToolStripSeparator();
            this.btnMassRename = new System.Windows.Forms.ToolStripButton();
            this.btnMassRemove = new System.Windows.Forms.ToolStripButton();
            this.tssTwo = new System.Windows.Forms.ToolStripSeparator();
            this.btnCommands = new System.Windows.Forms.ToolStripButton();
            this.btnRenameSingle = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveSingle = new System.Windows.Forms.ToolStripButton();
            this.btnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.btnSendToDeviceQr = new System.Windows.Forms.ToolStripButton();
            this.btnOpenGooglePlay = new System.Windows.Forms.ToolStripButton();
            this.tssSingleSelection = new System.Windows.Forms.ToolStripSeparator();
            this.btnRenameMulti = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveMulti = new System.Windows.Forms.ToolStripButton();
            this.tssMultiSelection = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.tssThree = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lvMain = new LocalAPK.ListViewNF();
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPackage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInternalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGooglePlayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLocalVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLatestVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGooglePlayFetch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRefresh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.pnlIcon = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblIcon = new System.Windows.Forms.Label();
            this.flpGeneral = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblFilenameValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPackageName = new System.Windows.Forms.Label();
            this.lblPackageNameValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInternalName = new System.Windows.Forms.Label();
            this.lblInternalNameValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblGooglePlayName = new System.Windows.Forms.Label();
            this.lblGooglePlayNameValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCategoryValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLocalVersion = new System.Windows.Forms.Label();
            this.lblLocalVersionValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblLatestVersionValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.tpMore = new System.Windows.Forms.TabPage();
            this.flpMore = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVersionCode = new System.Windows.Forms.Label();
            this.lblVersionCodeValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinSdkVersion = new System.Windows.Forms.Label();
            this.lblMinSdkVersionValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTargetSdkVersion = new System.Windows.Forms.Label();
            this.lblTargetSdkVersionValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lblScreenSizes = new System.Windows.Forms.Label();
            this.lblScreenSizesValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lblScreenDensities = new System.Windows.Forms.Label();
            this.lblScreenDensitiesValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.txtPermissionsValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFeaturesValue = new System.Windows.Forms.TextBox();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.cmsMain.SuspendLayout();
            this.cmsMainMulti.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.pnlIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.flpGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tpMore.SuspendLayout();
            this.flpMore.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMarketPageToolStripMenuItem,
            this.sendToPhoneQRToolStripMenuItem,
            this.toolStripSeparator1,
            this.openFolderToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(172, 120);
            // 
            // openMarketPageToolStripMenuItem
            // 
            this.openMarketPageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openMarketPageToolStripMenuItem.Image")));
            this.openMarketPageToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openMarketPageToolStripMenuItem.Name = "openMarketPageToolStripMenuItem";
            this.openMarketPageToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openMarketPageToolStripMenuItem.Text = "Open Google Play";
            this.openMarketPageToolStripMenuItem.Click += new System.EventHandler(this.openMarketPageToolStripMenuItem_Click);
            // 
            // sendToPhoneQRToolStripMenuItem
            // 
            this.sendToPhoneQRToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendToPhoneQRToolStripMenuItem.Image")));
            this.sendToPhoneQRToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendToPhoneQRToolStripMenuItem.Name = "sendToPhoneQRToolStripMenuItem";
            this.sendToPhoneQRToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.sendToPhoneQRToolStripMenuItem.Text = "Send to Device QR";
            this.sendToPhoneQRToolStripMenuItem.Click += new System.EventHandler(this.sendToDeviceQrToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFolderToolStripMenuItem.Image")));
            this.openFolderToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameToolStripMenuItem.Image")));
            this.renameToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem.Text = "Remove";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cmsMainMulti
            // 
            this.cmsMainMulti.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameSelectedToolStripMenuItem,
            this.removeSelectedToolStripMenuItem});
            this.cmsMainMulti.Name = "cmsMainMulti";
            this.cmsMainMulti.Size = new System.Drawing.Size(165, 48);
            // 
            // renameSelectedToolStripMenuItem
            // 
            this.renameSelectedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renameSelectedToolStripMenuItem.Image")));
            this.renameSelectedToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renameSelectedToolStripMenuItem.Name = "renameSelectedToolStripMenuItem";
            this.renameSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.renameSelectedToolStripMenuItem.Text = "Rename Selected";
            this.renameSelectedToolStripMenuItem.Click += new System.EventHandler(this.renameSelectedToolStripMenuItem_Click);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeSelectedToolStripMenuItem.Image")));
            this.removeSelectedToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.ssMain.Location = new System.Drawing.Point(0, 580);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(1210, 22);
            this.ssMain.TabIndex = 4;
            this.ssMain.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Image = ((System.Drawing.Image)(resources.GetObject("lblStatus.Image")));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 17);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnRefreshGooglePlay,
            this.btnExport,
            this.tssOne,
            this.btnMassRename,
            this.btnMassRemove,
            this.tssTwo,
            this.btnCommands,
            this.btnRenameSingle,
            this.btnRemoveSingle,
            this.btnOpenFolder,
            this.btnSendToDeviceQr,
            this.btnOpenGooglePlay,
            this.tssSingleSelection,
            this.btnRenameMulti,
            this.btnRemoveMulti,
            this.tssMultiSelection,
            this.btnSettings,
            this.tssThree,
            this.btnAbout,
            this.btnExit});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1210, 38);
            this.tsMain.TabIndex = 5;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 35);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.ToolTipText = "Refresh list by checking filesystem for new APK files";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRefreshGooglePlay
            // 
            this.btnRefreshGooglePlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshGooglePlayAll,
            this.btnRefreshGooglePlaySelection,
            this.btnRefreshGooglePlayOlder});
            this.btnRefreshGooglePlay.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshGooglePlay.Image")));
            this.btnRefreshGooglePlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefreshGooglePlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshGooglePlay.Name = "btnRefreshGooglePlay";
            this.btnRefreshGooglePlay.Size = new System.Drawing.Size(86, 35);
            this.btnRefreshGooglePlay.Text = "Fetch details";
            this.btnRefreshGooglePlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefreshGooglePlay.ToolTipText = "Fetch details from Google Play (Google Play Name, Category, Latest Version and Pr" +
    "ice)";
            // 
            // btnRefreshGooglePlayAll
            // 
            this.btnRefreshGooglePlayAll.Name = "btnRefreshGooglePlayAll";
            this.btnRefreshGooglePlayAll.Size = new System.Drawing.Size(256, 22);
            this.btnRefreshGooglePlayAll.Text = "Fetch all details";
            this.btnRefreshGooglePlayAll.Click += new System.EventHandler(this.btnRefreshGooglePlayAll_Click);
            // 
            // btnRefreshGooglePlaySelection
            // 
            this.btnRefreshGooglePlaySelection.Name = "btnRefreshGooglePlaySelection";
            this.btnRefreshGooglePlaySelection.Size = new System.Drawing.Size(256, 22);
            this.btnRefreshGooglePlaySelection.Text = "Fetch details for selection";
            this.btnRefreshGooglePlaySelection.Click += new System.EventHandler(this.btnRefreshGooglePlaySelection_Click);
            // 
            // btnRefreshGooglePlayOlder
            // 
            this.btnRefreshGooglePlayOlder.Name = "btnRefreshGooglePlayOlder";
            this.btnRefreshGooglePlayOlder.Size = new System.Drawing.Size(256, 22);
            this.btnRefreshGooglePlayOlder.Text = "Fetch details for items older than...";
            this.btnRefreshGooglePlayOlder.Click += new System.EventHandler(this.btnRefreshGooglePlayOlder_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(45, 35);
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tssOne
            // 
            this.tssOne.Name = "tssOne";
            this.tssOne.Size = new System.Drawing.Size(6, 38);
            // 
            // btnMassRename
            // 
            this.btnMassRename.Enabled = false;
            this.btnMassRename.Image = ((System.Drawing.Image)(resources.GetObject("btnMassRename.Image")));
            this.btnMassRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMassRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMassRename.Name = "btnMassRename";
            this.btnMassRename.Size = new System.Drawing.Size(81, 35);
            this.btnMassRename.Text = "Mass rename";
            this.btnMassRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMassRename.Click += new System.EventHandler(this.btnMassRename_Click);
            // 
            // btnMassRemove
            // 
            this.btnMassRemove.Enabled = false;
            this.btnMassRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnMassRemove.Image")));
            this.btnMassRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMassRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMassRemove.Name = "btnMassRemove";
            this.btnMassRemove.Size = new System.Drawing.Size(84, 35);
            this.btnMassRemove.Text = "Mass Remove";
            this.btnMassRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMassRemove.Click += new System.EventHandler(this.btnMassRemove_Click);
            // 
            // tssTwo
            // 
            this.tssTwo.Name = "tssTwo";
            this.tssTwo.Size = new System.Drawing.Size(6, 38);
            // 
            // btnCommands
            // 
            this.btnCommands.Image = ((System.Drawing.Image)(resources.GetObject("btnCommands.Image")));
            this.btnCommands.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCommands.Name = "btnCommands";
            this.btnCommands.Size = new System.Drawing.Size(73, 35);
            this.btnCommands.Text = "Commands";
            this.btnCommands.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCommands.Visible = false;
            this.btnCommands.Click += new System.EventHandler(this.btnCommands_Click);
            // 
            // btnRenameSingle
            // 
            this.btnRenameSingle.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameSingle.Image")));
            this.btnRenameSingle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRenameSingle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameSingle.Name = "btnRenameSingle";
            this.btnRenameSingle.Size = new System.Drawing.Size(54, 35);
            this.btnRenameSingle.Text = "Rename";
            this.btnRenameSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRenameSingle.Visible = false;
            this.btnRenameSingle.Click += new System.EventHandler(this.btnRenameSingle_Click);
            // 
            // btnRemoveSingle
            // 
            this.btnRemoveSingle.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveSingle.Image")));
            this.btnRemoveSingle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRemoveSingle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveSingle.Name = "btnRemoveSingle";
            this.btnRemoveSingle.Size = new System.Drawing.Size(54, 35);
            this.btnRemoveSingle.Text = "Remove";
            this.btnRemoveSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveSingle.Visible = false;
            this.btnRemoveSingle.Click += new System.EventHandler(this.btnRemoveSingle_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFolder.Image")));
            this.btnOpenFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(76, 35);
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenFolder.Visible = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnSendToDeviceQr
            // 
            this.btnSendToDeviceQr.Image = ((System.Drawing.Image)(resources.GetObject("btnSendToDeviceQr.Image")));
            this.btnSendToDeviceQr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSendToDeviceQr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendToDeviceQr.Name = "btnSendToDeviceQr";
            this.btnSendToDeviceQr.Size = new System.Drawing.Size(109, 35);
            this.btnSendToDeviceQr.Text = "Send To Device QR";
            this.btnSendToDeviceQr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendToDeviceQr.Visible = false;
            this.btnSendToDeviceQr.Click += new System.EventHandler(this.btnSendToDeviceQr_Click);
            // 
            // btnOpenGooglePlay
            // 
            this.btnOpenGooglePlay.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenGooglePlay.Image")));
            this.btnOpenGooglePlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenGooglePlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenGooglePlay.Name = "btnOpenGooglePlay";
            this.btnOpenGooglePlay.Size = new System.Drawing.Size(106, 35);
            this.btnOpenGooglePlay.Text = "Open Google Play";
            this.btnOpenGooglePlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenGooglePlay.Visible = false;
            this.btnOpenGooglePlay.Click += new System.EventHandler(this.btnOpenGooglePlay_Click);
            // 
            // tssSingleSelection
            // 
            this.tssSingleSelection.Name = "tssSingleSelection";
            this.tssSingleSelection.Size = new System.Drawing.Size(6, 38);
            this.tssSingleSelection.Visible = false;
            // 
            // btnRenameMulti
            // 
            this.btnRenameMulti.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameMulti.Image")));
            this.btnRenameMulti.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRenameMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRenameMulti.Name = "btnRenameMulti";
            this.btnRenameMulti.Size = new System.Drawing.Size(101, 35);
            this.btnRenameMulti.Text = "Rename Selected";
            this.btnRenameMulti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRenameMulti.Visible = false;
            this.btnRenameMulti.Click += new System.EventHandler(this.btnRenameMulti_Click);
            // 
            // btnRemoveMulti
            // 
            this.btnRemoveMulti.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveMulti.Image")));
            this.btnRemoveMulti.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRemoveMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveMulti.Name = "btnRemoveMulti";
            this.btnRemoveMulti.Size = new System.Drawing.Size(101, 35);
            this.btnRemoveMulti.Text = "Remove Selected";
            this.btnRemoveMulti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveMulti.Visible = false;
            this.btnRemoveMulti.Click += new System.EventHandler(this.btnRemoveMulti_Click);
            // 
            // tssMultiSelection
            // 
            this.tssMultiSelection.Name = "tssMultiSelection";
            this.tssMultiSelection.Size = new System.Drawing.Size(6, 38);
            this.tssMultiSelection.Visible = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(53, 35);
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tssThree
            // 
            this.tssThree.Name = "tssThree";
            this.tssThree.Size = new System.Drawing.Size(6, 38);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(44, 35);
            this.btnAbout.Text = "About";
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 35);
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 38);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lvMain);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.tcMain);
            this.scMain.Size = new System.Drawing.Size(1210, 542);
            this.scMain.SplitterDistance = 331;
            this.scMain.TabIndex = 6;
            // 
            // lvMain
            // 
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename,
            this.chPackage,
            this.chInternalName,
            this.chGooglePlayName,
            this.chCategory,
            this.chLocalVersion,
            this.chLatestVersion,
            this.chPrice,
            this.chGooglePlayFetch,
            this.chRefresh});
            this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMain.FullRowSelect = true;
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(0, 0);
            this.lvMain.Name = "lvMain";
            this.lvMain.OwnerDraw = true;
            this.lvMain.Size = new System.Drawing.Size(1210, 331);
            this.lvMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvMain.TabIndex = 1;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            this.lvMain.RefreshClicked += new LocalAPK.ListViewNF.RefreshClickedDelegate(this.lvMain_RefreshClicked);
            this.lvMain.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvMain_ItemSelectionChanged);
            this.lvMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvMain_KeyUp);
            this.lvMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvMain_MouseClick);
            // 
            // chFilename
            // 
            this.chFilename.Text = "Filename";
            this.chFilename.Width = 210;
            // 
            // chPackage
            // 
            this.chPackage.Text = "Package";
            this.chPackage.Width = 200;
            // 
            // chInternalName
            // 
            this.chInternalName.Text = "Internal Name";
            this.chInternalName.Width = 200;
            // 
            // chGooglePlayName
            // 
            this.chGooglePlayName.Text = "Google Play Name";
            this.chGooglePlayName.Width = 200;
            // 
            // chCategory
            // 
            this.chCategory.Text = "Category";
            this.chCategory.Width = 110;
            // 
            // chLocalVersion
            // 
            this.chLocalVersion.Text = "Local Version";
            this.chLocalVersion.Width = 100;
            // 
            // chLatestVersion
            // 
            this.chLatestVersion.Text = "Latest Version";
            this.chLatestVersion.Width = 100;
            // 
            // chPrice
            // 
            this.chPrice.Text = "Price";
            // 
            // chGooglePlayFetch
            // 
            this.chGooglePlayFetch.Text = "Google Play Fetch";
            this.chGooglePlayFetch.Width = 120;
            // 
            // chRefresh
            // 
            this.chRefresh.Text = "🔄";
            this.chRefresh.Width = 26;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpGeneral);
            this.tcMain.Controls.Add(this.tpMore);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1210, 207);
            this.tcMain.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.pnlIcon);
            this.tpGeneral.Controls.Add(this.flpGeneral);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(1202, 181);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // pnlIcon
            // 
            this.pnlIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlIcon.Controls.Add(this.picIcon);
            this.pnlIcon.Controls.Add(this.lblIcon);
            this.pnlIcon.Location = new System.Drawing.Point(8, 6);
            this.pnlIcon.Name = "pnlIcon";
            this.pnlIcon.Size = new System.Drawing.Size(147, 170);
            this.pnlIcon.TabIndex = 1;
            // 
            // picIcon
            // 
            this.picIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picIcon.Location = new System.Drawing.Point(3, 19);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(141, 141);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // lblIcon
            // 
            this.lblIcon.AutoSize = true;
            this.lblIcon.Location = new System.Drawing.Point(3, 3);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(31, 13);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "Icon:";
            // 
            // flpGeneral
            // 
            this.flpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpGeneral.Controls.Add(this.tableLayoutPanel1);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel2);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel3);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel4);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel5);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel6);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel7);
            this.flpGeneral.Controls.Add(this.tableLayoutPanel8);
            this.flpGeneral.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGeneral.Location = new System.Drawing.Point(161, 6);
            this.flpGeneral.Name = "flpGeneral";
            this.flpGeneral.Size = new System.Drawing.Size(1068, 170);
            this.flpGeneral.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblFilename, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFilenameValue, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(3, 0);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(52, 13);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "Filename:";
            // 
            // lblFilenameValue
            // 
            this.lblFilenameValue.AutoSize = true;
            this.lblFilenameValue.Location = new System.Drawing.Point(133, 0);
            this.lblFilenameValue.Name = "lblFilenameValue";
            this.lblFilenameValue.Size = new System.Drawing.Size(58, 13);
            this.lblFilenameValue.TabIndex = 1;
            this.lblFilenameValue.Text = "<filename>";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblPackageName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPackageNameValue, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblPackageName
            // 
            this.lblPackageName.AutoSize = true;
            this.lblPackageName.Location = new System.Drawing.Point(3, 0);
            this.lblPackageName.Name = "lblPackageName";
            this.lblPackageName.Size = new System.Drawing.Size(84, 13);
            this.lblPackageName.TabIndex = 0;
            this.lblPackageName.Text = "Package Name:";
            // 
            // lblPackageNameValue
            // 
            this.lblPackageNameValue.AutoSize = true;
            this.lblPackageNameValue.Location = new System.Drawing.Point(133, 0);
            this.lblPackageNameValue.Name = "lblPackageNameValue";
            this.lblPackageNameValue.Size = new System.Drawing.Size(87, 13);
            this.lblPackageNameValue.TabIndex = 1;
            this.lblPackageNameValue.Text = "<packagename>";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.lblInternalName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblInternalNameValue, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // lblInternalName
            // 
            this.lblInternalName.AutoSize = true;
            this.lblInternalName.Location = new System.Drawing.Point(3, 0);
            this.lblInternalName.Name = "lblInternalName";
            this.lblInternalName.Size = new System.Drawing.Size(76, 13);
            this.lblInternalName.TabIndex = 0;
            this.lblInternalName.Text = "Internal Name:";
            // 
            // lblInternalNameValue
            // 
            this.lblInternalNameValue.AutoSize = true;
            this.lblInternalNameValue.Location = new System.Drawing.Point(133, 0);
            this.lblInternalNameValue.Name = "lblInternalNameValue";
            this.lblInternalNameValue.Size = new System.Drawing.Size(79, 13);
            this.lblInternalNameValue.TabIndex = 1;
            this.lblInternalNameValue.Text = "<internalname>";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.lblGooglePlayName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblGooglePlayNameValue, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // lblGooglePlayName
            // 
            this.lblGooglePlayName.AutoSize = true;
            this.lblGooglePlayName.Location = new System.Drawing.Point(3, 0);
            this.lblGooglePlayName.Name = "lblGooglePlayName";
            this.lblGooglePlayName.Size = new System.Drawing.Size(98, 13);
            this.lblGooglePlayName.TabIndex = 0;
            this.lblGooglePlayName.Text = "Google Play Name:";
            // 
            // lblGooglePlayNameValue
            // 
            this.lblGooglePlayNameValue.AutoSize = true;
            this.lblGooglePlayNameValue.Location = new System.Drawing.Point(133, 0);
            this.lblGooglePlayNameValue.Name = "lblGooglePlayNameValue";
            this.lblGooglePlayNameValue.Size = new System.Drawing.Size(96, 13);
            this.lblGooglePlayNameValue.TabIndex = 1;
            this.lblGooglePlayNameValue.Text = "<googleplayname>";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.lblCategory, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblCategoryValue, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 91);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(3, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // lblCategoryValue
            // 
            this.lblCategoryValue.AutoSize = true;
            this.lblCategoryValue.Location = new System.Drawing.Point(133, 0);
            this.lblCategoryValue.Name = "lblCategoryValue";
            this.lblCategoryValue.Size = new System.Drawing.Size(60, 13);
            this.lblCategoryValue.TabIndex = 1;
            this.lblCategoryValue.Text = "<category>";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.lblLocalVersion, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblLocalVersionValue, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 113);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // lblLocalVersion
            // 
            this.lblLocalVersion.AutoSize = true;
            this.lblLocalVersion.Location = new System.Drawing.Point(3, 0);
            this.lblLocalVersion.Name = "lblLocalVersion";
            this.lblLocalVersion.Size = new System.Drawing.Size(74, 13);
            this.lblLocalVersion.TabIndex = 0;
            this.lblLocalVersion.Text = "Local Version:";
            // 
            // lblLocalVersionValue
            // 
            this.lblLocalVersionValue.AutoSize = true;
            this.lblLocalVersionValue.Location = new System.Drawing.Point(133, 0);
            this.lblLocalVersionValue.Name = "lblLocalVersionValue";
            this.lblLocalVersionValue.Size = new System.Drawing.Size(75, 13);
            this.lblLocalVersionValue.TabIndex = 1;
            this.lblLocalVersionValue.Text = "<localversion>";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.lblLatestVersion, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.lblLatestVersionValue, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 135);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Location = new System.Drawing.Point(3, 0);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(77, 13);
            this.lblLatestVersion.TabIndex = 0;
            this.lblLatestVersion.Text = "Latest Version:";
            // 
            // lblLatestVersionValue
            // 
            this.lblLatestVersionValue.AutoSize = true;
            this.lblLatestVersionValue.Location = new System.Drawing.Point(133, 0);
            this.lblLatestVersionValue.Name = "lblLatestVersionValue";
            this.lblLatestVersionValue.Size = new System.Drawing.Size(78, 13);
            this.lblLatestVersionValue.TabIndex = 1;
            this.lblLatestVersionValue.Text = "<latestversion>";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.lblPrice, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblPriceValue, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(384, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(3, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Price:";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Location = new System.Drawing.Point(133, 0);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(42, 13);
            this.lblPriceValue.TabIndex = 1;
            this.lblPriceValue.Text = "<price>";
            // 
            // tpMore
            // 
            this.tpMore.Controls.Add(this.flpMore);
            this.tpMore.Location = new System.Drawing.Point(4, 22);
            this.tpMore.Name = "tpMore";
            this.tpMore.Padding = new System.Windows.Forms.Padding(3);
            this.tpMore.Size = new System.Drawing.Size(1202, 181);
            this.tpMore.TabIndex = 1;
            this.tpMore.Text = "More";
            this.tpMore.UseVisualStyleBackColor = true;
            // 
            // flpMore
            // 
            this.flpMore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMore.Controls.Add(this.tableLayoutPanel9);
            this.flpMore.Controls.Add(this.tableLayoutPanel10);
            this.flpMore.Controls.Add(this.tableLayoutPanel11);
            this.flpMore.Controls.Add(this.tableLayoutPanel12);
            this.flpMore.Controls.Add(this.tableLayoutPanel13);
            this.flpMore.Controls.Add(this.tableLayoutPanel14);
            this.flpMore.Controls.Add(this.tableLayoutPanel15);
            this.flpMore.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMore.Location = new System.Drawing.Point(8, 6);
            this.flpMore.Name = "flpMore";
            this.flpMore.Size = new System.Drawing.Size(1190, 167);
            this.flpMore.TabIndex = 1;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.lblVersionCode, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblVersionCodeValue, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // lblVersionCode
            // 
            this.lblVersionCode.AutoSize = true;
            this.lblVersionCode.Location = new System.Drawing.Point(3, 0);
            this.lblVersionCode.Name = "lblVersionCode";
            this.lblVersionCode.Size = new System.Drawing.Size(73, 13);
            this.lblVersionCode.TabIndex = 0;
            this.lblVersionCode.Text = "Version Code:";
            // 
            // lblVersionCodeValue
            // 
            this.lblVersionCodeValue.AutoSize = true;
            this.lblVersionCodeValue.Location = new System.Drawing.Point(133, 0);
            this.lblVersionCodeValue.Name = "lblVersionCodeValue";
            this.lblVersionCodeValue.Size = new System.Drawing.Size(77, 13);
            this.lblVersionCodeValue.TabIndex = 1;
            this.lblVersionCodeValue.Text = "<versioncode>";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.Controls.Add(this.lblMinSdkVersion, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.lblMinSdkVersionValue, 1, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // lblMinSdkVersion
            // 
            this.lblMinSdkVersion.AutoSize = true;
            this.lblMinSdkVersion.Location = new System.Drawing.Point(3, 0);
            this.lblMinSdkVersion.Name = "lblMinSdkVersion";
            this.lblMinSdkVersion.Size = new System.Drawing.Size(93, 13);
            this.lblMinSdkVersion.TabIndex = 0;
            this.lblMinSdkVersion.Text = "Min. SDK Version:";
            // 
            // lblMinSdkVersionValue
            // 
            this.lblMinSdkVersionValue.AutoSize = true;
            this.lblMinSdkVersionValue.Location = new System.Drawing.Point(133, 0);
            this.lblMinSdkVersionValue.Name = "lblMinSdkVersionValue";
            this.lblMinSdkVersionValue.Size = new System.Drawing.Size(86, 13);
            this.lblMinSdkVersionValue.TabIndex = 1;
            this.lblMinSdkVersionValue.Text = "<minsdkversion>";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.lblTargetSdkVersion, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.lblTargetSdkVersionValue, 1, 0);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // lblTargetSdkVersion
            // 
            this.lblTargetSdkVersion.AutoSize = true;
            this.lblTargetSdkVersion.Location = new System.Drawing.Point(3, 0);
            this.lblTargetSdkVersion.Name = "lblTargetSdkVersion";
            this.lblTargetSdkVersion.Size = new System.Drawing.Size(104, 13);
            this.lblTargetSdkVersion.TabIndex = 0;
            this.lblTargetSdkVersion.Text = "Target SDK Version:";
            // 
            // lblTargetSdkVersionValue
            // 
            this.lblTargetSdkVersionValue.AutoSize = true;
            this.lblTargetSdkVersionValue.Location = new System.Drawing.Point(133, 0);
            this.lblTargetSdkVersionValue.Name = "lblTargetSdkVersionValue";
            this.lblTargetSdkVersionValue.Size = new System.Drawing.Size(97, 13);
            this.lblTargetSdkVersionValue.TabIndex = 1;
            this.lblTargetSdkVersionValue.Text = "<targetsdkversion>";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.lblScreenSizes, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.lblScreenSizesValue, 1, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel12.TabIndex = 3;
            // 
            // lblScreenSizes
            // 
            this.lblScreenSizes.AutoSize = true;
            this.lblScreenSizes.Location = new System.Drawing.Point(3, 0);
            this.lblScreenSizes.Name = "lblScreenSizes";
            this.lblScreenSizes.Size = new System.Drawing.Size(72, 13);
            this.lblScreenSizes.TabIndex = 0;
            this.lblScreenSizes.Text = "Screen Sizes:";
            // 
            // lblScreenSizesValue
            // 
            this.lblScreenSizesValue.AutoSize = true;
            this.lblScreenSizesValue.Location = new System.Drawing.Point(133, 0);
            this.lblScreenSizesValue.Name = "lblScreenSizesValue";
            this.lblScreenSizesValue.Size = new System.Drawing.Size(74, 13);
            this.lblScreenSizesValue.TabIndex = 1;
            this.lblScreenSizesValue.Text = "<screensizes>";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.Controls.Add(this.lblScreenDensities, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.lblScreenDensitiesValue, 1, 0);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 91);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(375, 16);
            this.tableLayoutPanel13.TabIndex = 4;
            // 
            // lblScreenDensities
            // 
            this.lblScreenDensities.AutoSize = true;
            this.lblScreenDensities.Location = new System.Drawing.Point(3, 0);
            this.lblScreenDensities.Name = "lblScreenDensities";
            this.lblScreenDensities.Size = new System.Drawing.Size(90, 13);
            this.lblScreenDensities.TabIndex = 0;
            this.lblScreenDensities.Text = "Screen Densities:";
            // 
            // lblScreenDensitiesValue
            // 
            this.lblScreenDensitiesValue.AutoSize = true;
            this.lblScreenDensitiesValue.Location = new System.Drawing.Point(133, 0);
            this.lblScreenDensitiesValue.Name = "lblScreenDensitiesValue";
            this.lblScreenDensitiesValue.Size = new System.Drawing.Size(92, 13);
            this.lblScreenDensitiesValue.TabIndex = 1;
            this.lblScreenDensitiesValue.Text = "<screendensities>";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.Controls.Add(this.lblPermissions, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.txtPermissionsValue, 1, 0);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(384, 3);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(375, 104);
            this.tableLayoutPanel14.TabIndex = 5;
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Location = new System.Drawing.Point(3, 0);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(65, 13);
            this.lblPermissions.TabIndex = 0;
            this.lblPermissions.Text = "Permissions:";
            // 
            // txtPermissionsValue
            // 
            this.txtPermissionsValue.Location = new System.Drawing.Point(103, 3);
            this.txtPermissionsValue.Multiline = true;
            this.txtPermissionsValue.Name = "txtPermissionsValue";
            this.txtPermissionsValue.ReadOnly = true;
            this.txtPermissionsValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPermissionsValue.Size = new System.Drawing.Size(272, 98);
            this.txtPermissionsValue.TabIndex = 1;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.Controls.Add(this.txtFeaturesValue, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblFeatures, 0, 0);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(765, 3);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(375, 104);
            this.tableLayoutPanel15.TabIndex = 6;
            // 
            // txtFeaturesValue
            // 
            this.txtFeaturesValue.Location = new System.Drawing.Point(103, 3);
            this.txtFeaturesValue.Multiline = true;
            this.txtFeaturesValue.Name = "txtFeaturesValue";
            this.txtFeaturesValue.ReadOnly = true;
            this.txtFeaturesValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFeaturesValue.Size = new System.Drawing.Size(272, 98);
            this.txtFeaturesValue.TabIndex = 2;
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Location = new System.Drawing.Point(3, 0);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(51, 13);
            this.lblFeatures.TabIndex = 0;
            this.lblFeatures.Text = "Features:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 602);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.ssMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "LocalAPK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.cmsMain.ResumeLayout(false);
            this.cmsMainMulti.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.pnlIcon.ResumeLayout(false);
            this.pnlIcon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.flpGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tpMore.ResumeLayout(false);
            this.flpMore.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private LocalAPK.ListViewNF lvMain;
        private System.Windows.Forms.ColumnHeader chFilename;
        private System.Windows.Forms.ColumnHeader chInternalName;
        private System.Windows.Forms.ColumnHeader chLocalVersion;
		private System.Windows.Forms.ColumnHeader chLatestVersion;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMarketPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip cmsMainMulti;
        private System.Windows.Forms.ToolStripMenuItem renameSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chPackage;
        private System.Windows.Forms.ToolStripMenuItem sendToPhoneQRToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader chPrice;
        private System.Windows.Forms.StatusStrip ssMain;
		private System.Windows.Forms.ColumnHeader chGooglePlayName;
		private System.Windows.Forms.ColumnHeader chCategory;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.ToolStripSeparator tssOne;
		private System.Windows.Forms.ToolStripButton btnMassRename;
		private System.Windows.Forms.ToolStripButton btnMassRemove;
		private System.Windows.Forms.ToolStripSeparator tssTwo;
		private System.Windows.Forms.ToolStripButton btnSettings;
		private System.Windows.Forms.ToolStripSeparator tssThree;
		private System.Windows.Forms.ToolStripButton btnAbout;
		private System.Windows.Forms.ToolStripButton btnExit;
		private System.Windows.Forms.SplitContainer scMain;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabPage tpMore;
		private System.Windows.Forms.FlowLayoutPanel flpGeneral;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.Label lblFilenameValue;
		private System.Windows.Forms.Label lblPackageName;
		private System.Windows.Forms.Label lblPackageNameValue;
		private System.Windows.Forms.Label lblInternalName;
		private System.Windows.Forms.Label lblInternalNameValue;
		private System.Windows.Forms.Label lblGooglePlayName;
		private System.Windows.Forms.Label lblGooglePlayNameValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.Label lblCategoryValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Label lblLocalVersion;
		private System.Windows.Forms.Label lblLocalVersionValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.Label lblLatestVersion;
		private System.Windows.Forms.Label lblLatestVersionValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.Label lblPriceValue;
		private System.Windows.Forms.Panel pnlIcon;
		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.Label lblIcon;
		private System.Windows.Forms.FlowLayoutPanel flpMore;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.Label lblVersionCode;
		private System.Windows.Forms.Label lblVersionCodeValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
		private System.Windows.Forms.Label lblMinSdkVersion;
		private System.Windows.Forms.Label lblMinSdkVersionValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
		private System.Windows.Forms.Label lblTargetSdkVersion;
		private System.Windows.Forms.Label lblTargetSdkVersionValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
		private System.Windows.Forms.Label lblScreenSizes;
		private System.Windows.Forms.Label lblScreenSizesValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
		private System.Windows.Forms.Label lblScreenDensities;
		private System.Windows.Forms.Label lblScreenDensitiesValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
		private System.Windows.Forms.Label lblPermissions;
		private System.Windows.Forms.TextBox txtPermissionsValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
		private System.Windows.Forms.TextBox txtFeaturesValue;
		private System.Windows.Forms.Label lblFeatures;
		private System.Windows.Forms.ToolStripButton btnOpenGooglePlay;
		private System.Windows.Forms.ToolStripButton btnCommands;
		private System.Windows.Forms.ToolStripButton btnRemoveSingle;
		private System.Windows.Forms.ToolStripButton btnRenameSingle;
		private System.Windows.Forms.ToolStripButton btnOpenFolder;
		private System.Windows.Forms.ToolStripButton btnSendToDeviceQr;
		private System.Windows.Forms.ToolStripSeparator tssSingleSelection;
		private System.Windows.Forms.ToolStripButton btnRemoveMulti;
		private System.Windows.Forms.ToolStripButton btnRenameMulti;
		private System.Windows.Forms.ToolStripSeparator tssMultiSelection;
        private System.Windows.Forms.ColumnHeader chGooglePlayFetch;
        private System.Windows.Forms.ColumnHeader chRefresh;
        private System.Windows.Forms.ToolStripDropDownButton btnRefreshGooglePlay;
        private System.Windows.Forms.ToolStripMenuItem btnRefreshGooglePlayAll;
        private System.Windows.Forms.ToolStripMenuItem btnRefreshGooglePlayOlder;
        private System.Windows.Forms.ToolStripMenuItem btnRefreshGooglePlaySelection;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripButton btnExport;
    }
}

