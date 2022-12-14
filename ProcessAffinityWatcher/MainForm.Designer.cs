namespace ProcessAffinityWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstWatchList = new System.Windows.Forms.ListBox();
            this.cmbProcessSelect = new System.Windows.Forms.ComboBox();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.grpAffinity = new System.Windows.Forms.GroupBox();
            this.lblProcessStatus = new System.Windows.Forms.Label();
            this.chkCPUAll = new System.Windows.Forms.CheckBox();
            this.btnRemoveProcess = new System.Windows.Forms.Button();
            this.chkCPU15 = new System.Windows.Forms.CheckBox();
            this.chkCPU14 = new System.Windows.Forms.CheckBox();
            this.chkCPU13 = new System.Windows.Forms.CheckBox();
            this.chkCPU12 = new System.Windows.Forms.CheckBox();
            this.chkCPU11 = new System.Windows.Forms.CheckBox();
            this.chkCPU10 = new System.Windows.Forms.CheckBox();
            this.chkCPU09 = new System.Windows.Forms.CheckBox();
            this.chkCPU08 = new System.Windows.Forms.CheckBox();
            this.chkCPU07 = new System.Windows.Forms.CheckBox();
            this.chkCPU06 = new System.Windows.Forms.CheckBox();
            this.chkCPU05 = new System.Windows.Forms.CheckBox();
            this.chkCPU04 = new System.Windows.Forms.CheckBox();
            this.chkCPU03 = new System.Windows.Forms.CheckBox();
            this.chkCPU02 = new System.Windows.Forms.CheckBox();
            this.chkCPU01 = new System.Windows.Forms.CheckBox();
            this.btnSaveAffinity = new System.Windows.Forms.Button();
            this.chkCPU00 = new System.Windows.Forms.CheckBox();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.tmrProcessCheck = new System.Windows.Forms.Timer(this.components);
            this.trayMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mitFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mitMinimizeTray = new System.Windows.Forms.ToolStripMenuItem();
            this.mitExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPolling = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPoll5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPoll10 = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPoll30 = new System.Windows.Forms.ToolStripMenuItem();
            this.mitPoll60 = new System.Windows.Forms.ToolStripMenuItem();
            this.mitInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mitInfoVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.mitAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpAffinity.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstWatchList
            // 
            this.lstWatchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstWatchList.FormattingEnabled = true;
            this.lstWatchList.Location = new System.Drawing.Point(12, 54);
            this.lstWatchList.Name = "lstWatchList";
            this.lstWatchList.Size = new System.Drawing.Size(256, 329);
            this.lstWatchList.TabIndex = 0;
            this.lstWatchList.SelectedIndexChanged += new System.EventHandler(this.lstWatchList_SelectedIndexChanged);
            // 
            // cmbProcessSelect
            // 
            this.cmbProcessSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbProcessSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProcessSelect.Enabled = false;
            this.cmbProcessSelect.FormattingEnabled = true;
            this.cmbProcessSelect.Location = new System.Drawing.Point(12, 27);
            this.cmbProcessSelect.Name = "cmbProcessSelect";
            this.cmbProcessSelect.Size = new System.Drawing.Size(256, 21);
            this.cmbProcessSelect.TabIndex = 1;
            this.cmbProcessSelect.Enter += new System.EventHandler(this.CmbProcessSelect_Enter);
            this.cmbProcessSelect.Leave += new System.EventHandler(this.CmbProcessSelect_Leave);
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.Location = new System.Drawing.Point(274, 25);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(147, 23);
            this.btnAddProcess.TabIndex = 2;
            this.btnAddProcess.Text = "Add process";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // grpAffinity
            // 
            this.grpAffinity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAffinity.Controls.Add(this.lblProcessStatus);
            this.grpAffinity.Controls.Add(this.chkCPUAll);
            this.grpAffinity.Controls.Add(this.btnRemoveProcess);
            this.grpAffinity.Controls.Add(this.chkCPU15);
            this.grpAffinity.Controls.Add(this.chkCPU14);
            this.grpAffinity.Controls.Add(this.chkCPU13);
            this.grpAffinity.Controls.Add(this.chkCPU12);
            this.grpAffinity.Controls.Add(this.chkCPU11);
            this.grpAffinity.Controls.Add(this.chkCPU10);
            this.grpAffinity.Controls.Add(this.chkCPU09);
            this.grpAffinity.Controls.Add(this.chkCPU08);
            this.grpAffinity.Controls.Add(this.chkCPU07);
            this.grpAffinity.Controls.Add(this.chkCPU06);
            this.grpAffinity.Controls.Add(this.chkCPU05);
            this.grpAffinity.Controls.Add(this.chkCPU04);
            this.grpAffinity.Controls.Add(this.chkCPU03);
            this.grpAffinity.Controls.Add(this.chkCPU02);
            this.grpAffinity.Controls.Add(this.chkCPU01);
            this.grpAffinity.Controls.Add(this.btnSaveAffinity);
            this.grpAffinity.Controls.Add(this.chkCPU00);
            this.grpAffinity.Controls.Add(this.lblProcessName);
            this.grpAffinity.Location = new System.Drawing.Point(274, 54);
            this.grpAffinity.Name = "grpAffinity";
            this.grpAffinity.Size = new System.Drawing.Size(278, 336);
            this.grpAffinity.TabIndex = 3;
            this.grpAffinity.TabStop = false;
            this.grpAffinity.Text = "Affinity";
            // 
            // lblProcessStatus
            // 
            this.lblProcessStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcessStatus.Location = new System.Drawing.Point(10, 266);
            this.lblProcessStatus.Name = "lblProcessStatus";
            this.lblProcessStatus.Size = new System.Drawing.Size(262, 23);
            this.lblProcessStatus.TabIndex = 20;
            this.lblProcessStatus.Text = "---";
            // 
            // chkCPUAll
            // 
            this.chkCPUAll.AutoSize = true;
            this.chkCPUAll.Location = new System.Drawing.Point(10, 45);
            this.chkCPUAll.Name = "chkCPUAll";
            this.chkCPUAll.Size = new System.Drawing.Size(81, 17);
            this.chkCPUAll.TabIndex = 19;
            this.chkCPUAll.Text = "<Select all>";
            this.chkCPUAll.UseVisualStyleBackColor = true;
            this.chkCPUAll.CheckedChanged += new System.EventHandler(this.chkCPUAll_CheckedChanged);
            // 
            // btnRemoveProcess
            // 
            this.btnRemoveProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveProcess.Location = new System.Drawing.Point(197, 307);
            this.btnRemoveProcess.Name = "btnRemoveProcess";
            this.btnRemoveProcess.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProcess.TabIndex = 18;
            this.btnRemoveProcess.Text = "Remove";
            this.btnRemoveProcess.UseVisualStyleBackColor = true;
            this.btnRemoveProcess.Click += new System.EventHandler(this.btnRemoveProcess_Click);
            // 
            // chkCPU15
            // 
            this.chkCPU15.AutoSize = true;
            this.chkCPU15.Location = new System.Drawing.Point(69, 229);
            this.chkCPU15.Name = "chkCPU15";
            this.chkCPU15.Size = new System.Drawing.Size(38, 17);
            this.chkCPU15.TabIndex = 17;
            this.chkCPU15.Text = "15";
            this.chkCPU15.UseVisualStyleBackColor = true;
            this.chkCPU15.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU14
            // 
            this.chkCPU14.AutoSize = true;
            this.chkCPU14.Location = new System.Drawing.Point(69, 206);
            this.chkCPU14.Name = "chkCPU14";
            this.chkCPU14.Size = new System.Drawing.Size(38, 17);
            this.chkCPU14.TabIndex = 16;
            this.chkCPU14.Text = "14";
            this.chkCPU14.UseVisualStyleBackColor = true;
            this.chkCPU14.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU13
            // 
            this.chkCPU13.AutoSize = true;
            this.chkCPU13.Location = new System.Drawing.Point(69, 183);
            this.chkCPU13.Name = "chkCPU13";
            this.chkCPU13.Size = new System.Drawing.Size(38, 17);
            this.chkCPU13.TabIndex = 15;
            this.chkCPU13.Text = "13";
            this.chkCPU13.UseVisualStyleBackColor = true;
            this.chkCPU13.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU12
            // 
            this.chkCPU12.AutoSize = true;
            this.chkCPU12.Location = new System.Drawing.Point(69, 160);
            this.chkCPU12.Name = "chkCPU12";
            this.chkCPU12.Size = new System.Drawing.Size(38, 17);
            this.chkCPU12.TabIndex = 14;
            this.chkCPU12.Text = "12";
            this.chkCPU12.UseVisualStyleBackColor = true;
            this.chkCPU12.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU11
            // 
            this.chkCPU11.AutoSize = true;
            this.chkCPU11.Location = new System.Drawing.Point(69, 137);
            this.chkCPU11.Name = "chkCPU11";
            this.chkCPU11.Size = new System.Drawing.Size(38, 17);
            this.chkCPU11.TabIndex = 13;
            this.chkCPU11.Text = "11";
            this.chkCPU11.UseVisualStyleBackColor = true;
            this.chkCPU11.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU10
            // 
            this.chkCPU10.AutoSize = true;
            this.chkCPU10.Location = new System.Drawing.Point(69, 114);
            this.chkCPU10.Name = "chkCPU10";
            this.chkCPU10.Size = new System.Drawing.Size(38, 17);
            this.chkCPU10.TabIndex = 12;
            this.chkCPU10.Text = "10";
            this.chkCPU10.UseVisualStyleBackColor = true;
            this.chkCPU10.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU09
            // 
            this.chkCPU09.AutoSize = true;
            this.chkCPU09.Location = new System.Drawing.Point(69, 91);
            this.chkCPU09.Name = "chkCPU09";
            this.chkCPU09.Size = new System.Drawing.Size(38, 17);
            this.chkCPU09.TabIndex = 11;
            this.chkCPU09.Text = "09";
            this.chkCPU09.UseVisualStyleBackColor = true;
            this.chkCPU09.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU08
            // 
            this.chkCPU08.AutoSize = true;
            this.chkCPU08.Location = new System.Drawing.Point(69, 68);
            this.chkCPU08.Name = "chkCPU08";
            this.chkCPU08.Size = new System.Drawing.Size(38, 17);
            this.chkCPU08.TabIndex = 10;
            this.chkCPU08.Text = "08";
            this.chkCPU08.UseVisualStyleBackColor = true;
            this.chkCPU08.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU07
            // 
            this.chkCPU07.AutoSize = true;
            this.chkCPU07.Location = new System.Drawing.Point(10, 229);
            this.chkCPU07.Name = "chkCPU07";
            this.chkCPU07.Size = new System.Drawing.Size(38, 17);
            this.chkCPU07.TabIndex = 9;
            this.chkCPU07.Text = "07";
            this.chkCPU07.UseVisualStyleBackColor = true;
            this.chkCPU07.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU06
            // 
            this.chkCPU06.AutoSize = true;
            this.chkCPU06.Location = new System.Drawing.Point(10, 206);
            this.chkCPU06.Name = "chkCPU06";
            this.chkCPU06.Size = new System.Drawing.Size(38, 17);
            this.chkCPU06.TabIndex = 8;
            this.chkCPU06.Text = "06";
            this.chkCPU06.UseVisualStyleBackColor = true;
            this.chkCPU06.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU05
            // 
            this.chkCPU05.AutoSize = true;
            this.chkCPU05.Location = new System.Drawing.Point(10, 183);
            this.chkCPU05.Name = "chkCPU05";
            this.chkCPU05.Size = new System.Drawing.Size(38, 17);
            this.chkCPU05.TabIndex = 7;
            this.chkCPU05.Text = "05";
            this.chkCPU05.UseVisualStyleBackColor = true;
            this.chkCPU05.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU04
            // 
            this.chkCPU04.AutoSize = true;
            this.chkCPU04.Location = new System.Drawing.Point(10, 160);
            this.chkCPU04.Name = "chkCPU04";
            this.chkCPU04.Size = new System.Drawing.Size(38, 17);
            this.chkCPU04.TabIndex = 6;
            this.chkCPU04.Text = "04";
            this.chkCPU04.UseVisualStyleBackColor = true;
            this.chkCPU04.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU03
            // 
            this.chkCPU03.AutoSize = true;
            this.chkCPU03.Location = new System.Drawing.Point(10, 137);
            this.chkCPU03.Name = "chkCPU03";
            this.chkCPU03.Size = new System.Drawing.Size(38, 17);
            this.chkCPU03.TabIndex = 5;
            this.chkCPU03.Text = "03";
            this.chkCPU03.UseVisualStyleBackColor = true;
            this.chkCPU03.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU02
            // 
            this.chkCPU02.AutoSize = true;
            this.chkCPU02.Location = new System.Drawing.Point(10, 114);
            this.chkCPU02.Name = "chkCPU02";
            this.chkCPU02.Size = new System.Drawing.Size(38, 17);
            this.chkCPU02.TabIndex = 4;
            this.chkCPU02.Text = "02";
            this.chkCPU02.UseVisualStyleBackColor = true;
            this.chkCPU02.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // chkCPU01
            // 
            this.chkCPU01.AutoSize = true;
            this.chkCPU01.Location = new System.Drawing.Point(10, 91);
            this.chkCPU01.Name = "chkCPU01";
            this.chkCPU01.Size = new System.Drawing.Size(38, 17);
            this.chkCPU01.TabIndex = 3;
            this.chkCPU01.Text = "01";
            this.chkCPU01.UseVisualStyleBackColor = true;
            this.chkCPU01.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // btnSaveAffinity
            // 
            this.btnSaveAffinity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveAffinity.Location = new System.Drawing.Point(7, 290);
            this.btnSaveAffinity.Name = "btnSaveAffinity";
            this.btnSaveAffinity.Size = new System.Drawing.Size(111, 40);
            this.btnSaveAffinity.TabIndex = 2;
            this.btnSaveAffinity.Text = "Save";
            this.btnSaveAffinity.UseVisualStyleBackColor = true;
            this.btnSaveAffinity.Click += new System.EventHandler(this.btnSaveAffinity_Click);
            // 
            // chkCPU00
            // 
            this.chkCPU00.AutoSize = true;
            this.chkCPU00.Location = new System.Drawing.Point(10, 68);
            this.chkCPU00.Name = "chkCPU00";
            this.chkCPU00.Size = new System.Drawing.Size(38, 17);
            this.chkCPU00.TabIndex = 1;
            this.chkCPU00.Text = "00";
            this.chkCPU00.UseVisualStyleBackColor = true;
            this.chkCPU00.CheckedChanged += new System.EventHandler(this.ChkCPU_CheckedChanged);
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Location = new System.Drawing.Point(7, 20);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(250, 13);
            this.lblProcessName.TabIndex = 0;
            this.lblProcessName.Text = "Set affinity for <please select a process on the left>:";
            // 
            // tmrProcessCheck
            // 
            this.tmrProcessCheck.Enabled = true;
            this.tmrProcessCheck.Interval = 10000;
            this.tmrProcessCheck.Tick += new System.EventHandler(this.TmrProcessCheck_Tick);
            // 
            // trayMain
            // 
            this.trayMain.Icon = ((System.Drawing.Icon)(resources.GetObject("trayMain.Icon")));
            this.trayMain.Text = "ProcessAffinityWatcher";
            this.trayMain.Visible = true;
            this.trayMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayMain_MouseDoubleClick);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitFile,
            this.mitPolling,
            this.mitInfo});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(564, 24);
            this.mnuMain.TabIndex = 5;
            this.mnuMain.Text = "mnuMain";
            // 
            // mitFile
            // 
            this.mitFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitMinimizeTray,
            this.mitExit});
            this.mitFile.Name = "mitFile";
            this.mitFile.Size = new System.Drawing.Size(37, 20);
            this.mitFile.Text = "File";
            // 
            // mitMinimizeTray
            // 
            this.mitMinimizeTray.Checked = true;
            this.mitMinimizeTray.CheckOnClick = true;
            this.mitMinimizeTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mitMinimizeTray.Name = "mitMinimizeTray";
            this.mitMinimizeTray.Size = new System.Drawing.Size(180, 22);
            this.mitMinimizeTray.Text = "Minimize to tray";
            this.mitMinimizeTray.Click += new System.EventHandler(this.mitMinimizeTray_Click);
            // 
            // mitExit
            // 
            this.mitExit.Name = "mitExit";
            this.mitExit.Size = new System.Drawing.Size(180, 22);
            this.mitExit.Text = "Exit";
            this.mitExit.Click += new System.EventHandler(this.mitExit_Click);
            // 
            // mitPolling
            // 
            this.mitPolling.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitPoll5,
            this.mitPoll10,
            this.mitPoll30,
            this.mitPoll60});
            this.mitPolling.Name = "mitPolling";
            this.mitPolling.Size = new System.Drawing.Size(56, 20);
            this.mitPolling.Text = "Polling";
            // 
            // mitPoll5
            // 
            this.mitPoll5.CheckOnClick = true;
            this.mitPoll5.Name = "mitPoll5";
            this.mitPoll5.Size = new System.Drawing.Size(180, 22);
            this.mitPoll5.Text = "5 seconds";
            this.mitPoll5.Click += new System.EventHandler(this.mitPoll5_Click);
            // 
            // mitPoll10
            // 
            this.mitPoll10.Checked = true;
            this.mitPoll10.CheckOnClick = true;
            this.mitPoll10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mitPoll10.Name = "mitPoll10";
            this.mitPoll10.Size = new System.Drawing.Size(180, 22);
            this.mitPoll10.Text = "10 seconds";
            this.mitPoll10.Click += new System.EventHandler(this.mitPoll10_Click);
            // 
            // mitPoll30
            // 
            this.mitPoll30.CheckOnClick = true;
            this.mitPoll30.Name = "mitPoll30";
            this.mitPoll30.Size = new System.Drawing.Size(180, 22);
            this.mitPoll30.Text = "30 seconds";
            this.mitPoll30.Click += new System.EventHandler(this.mitPoll30_Click);
            // 
            // mitPoll60
            // 
            this.mitPoll60.CheckOnClick = true;
            this.mitPoll60.Name = "mitPoll60";
            this.mitPoll60.Size = new System.Drawing.Size(180, 22);
            this.mitPoll60.Text = "60 seconds";
            this.mitPoll60.Click += new System.EventHandler(this.mitPoll60_Click);
            // 
            // mitInfo
            // 
            this.mitInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitInfoVersion,
            this.mitAbout});
            this.mitInfo.Name = "mitInfo";
            this.mitInfo.Size = new System.Drawing.Size(40, 20);
            this.mitInfo.Text = "Info";
            // 
            // mitInfoVersion
            // 
            this.mitInfoVersion.Enabled = false;
            this.mitInfoVersion.Name = "mitInfoVersion";
            this.mitInfoVersion.Size = new System.Drawing.Size(180, 22);
            this.mitInfoVersion.Text = "Version";
            // 
            // mitAbout
            // 
            this.mitAbout.Name = "mitAbout";
            this.mitAbout.Size = new System.Drawing.Size(180, 22);
            this.mitAbout.Text = "About";
            this.mitAbout.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 401);
            this.Controls.Add(this.grpAffinity);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.cmbProcessSelect);
            this.Controls.Add(this.lstWatchList);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(580, 440);
            this.Name = "MainForm";
            this.Text = "ProcessAffinityWatcher";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.grpAffinity.ResumeLayout(false);
            this.grpAffinity.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstWatchList;
        private System.Windows.Forms.ComboBox cmbProcessSelect;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.GroupBox grpAffinity;
        private System.Windows.Forms.CheckBox chkCPUAll;
        private System.Windows.Forms.Button btnRemoveProcess;
        private System.Windows.Forms.CheckBox chkCPU15;
        private System.Windows.Forms.CheckBox chkCPU14;
        private System.Windows.Forms.CheckBox chkCPU13;
        private System.Windows.Forms.CheckBox chkCPU12;
        private System.Windows.Forms.CheckBox chkCPU11;
        private System.Windows.Forms.CheckBox chkCPU10;
        private System.Windows.Forms.CheckBox chkCPU09;
        private System.Windows.Forms.CheckBox chkCPU08;
        private System.Windows.Forms.CheckBox chkCPU07;
        private System.Windows.Forms.CheckBox chkCPU06;
        private System.Windows.Forms.CheckBox chkCPU05;
        private System.Windows.Forms.CheckBox chkCPU04;
        private System.Windows.Forms.CheckBox chkCPU03;
        private System.Windows.Forms.CheckBox chkCPU02;
        private System.Windows.Forms.CheckBox chkCPU01;
        private System.Windows.Forms.Button btnSaveAffinity;
        private System.Windows.Forms.CheckBox chkCPU00;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Timer tmrProcessCheck;
        private System.Windows.Forms.Label lblProcessStatus;
        private System.Windows.Forms.NotifyIcon trayMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mitFile;
        private System.Windows.Forms.ToolStripMenuItem mitMinimizeTray;
        private System.Windows.Forms.ToolStripMenuItem mitExit;
        private System.Windows.Forms.ToolStripMenuItem mitPolling;
        private System.Windows.Forms.ToolStripMenuItem mitPoll5;
        private System.Windows.Forms.ToolStripMenuItem mitPoll10;
        private System.Windows.Forms.ToolStripMenuItem mitPoll30;
        private System.Windows.Forms.ToolStripMenuItem mitPoll60;
        private System.Windows.Forms.ToolStripMenuItem mitInfo;
        private System.Windows.Forms.ToolStripMenuItem mitInfoVersion;
        private System.Windows.Forms.ToolStripMenuItem mitAbout;
    }
}

