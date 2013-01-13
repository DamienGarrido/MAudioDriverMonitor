namespace MAudioDriverMonitor
{
    partial class MonitorForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmShow = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itmStartMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.itmStopMonitoring = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHide = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.chkMonitoringStatus = new System.Windows.Forms.CheckBox();
            this.btnStartServices = new System.Windows.Forms.Button();
            this.btnStopServices = new System.Windows.Forms.Button();
            this.lsvSuspendServices = new System.Windows.Forms.ListView();
            this.mnuService = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSuspendServices = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpResumeServices = new System.Windows.Forms.GroupBox();
            this.lsvResumeServices = new System.Windows.Forms.ListView();
            this.mnuNotifyIcon.SuspendLayout();
            this.mnuService.SuspendLayout();
            this.grpSuspendServices.SuspendLayout();
            this.grpResumeServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.mnuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "M-Audio Driver Monitor";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // mnuNotifyIcon
            // 
            this.mnuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmShow,
            this.itmHide,
            this.toolStripSeparator2,
            this.itmStartMonitoring,
            this.itmStopMonitoring,
            this.toolStripSeparator1,
            this.itmQuit});
            this.mnuNotifyIcon.Name = "ctxMnuNotifyIcon";
            this.mnuNotifyIcon.Size = new System.Drawing.Size(162, 126);
            // 
            // itmShow
            // 
            this.itmShow.Enabled = false;
            this.itmShow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.itmShow.Name = "itmShow";
            this.itmShow.Size = new System.Drawing.Size(161, 22);
            this.itmShow.Text = "Show";
            this.itmShow.Click += new System.EventHandler(this.itmShow_Click);
            // 
            // itmHide
            // 
            this.itmHide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.itmHide.Name = "itmHide";
            this.itmHide.Size = new System.Drawing.Size(161, 22);
            this.itmHide.Text = "Hide";
            this.itmHide.Click += new System.EventHandler(this.itmHide_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // itmStartMonitoring
            // 
            this.itmStartMonitoring.Enabled = false;
            this.itmStartMonitoring.Name = "itmStartMonitoring";
            this.itmStartMonitoring.Size = new System.Drawing.Size(161, 22);
            this.itmStartMonitoring.Text = "Start Monitoring";
            this.itmStartMonitoring.Click += new System.EventHandler(this.itmStartMonitoring_Click);
            // 
            // itmStopMonitoring
            // 
            this.itmStopMonitoring.Name = "itmStopMonitoring";
            this.itmStopMonitoring.Size = new System.Drawing.Size(161, 22);
            this.itmStopMonitoring.Text = "Stop Monitoring";
            this.itmStopMonitoring.Click += new System.EventHandler(this.itmStopMonitoring_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // itmQuit
            // 
            this.itmQuit.Name = "itmQuit";
            this.itmQuit.Size = new System.Drawing.Size(161, 22);
            this.itmQuit.Text = "Quit";
            this.itmQuit.Click += new System.EventHandler(this.itmQuit_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(177, 356);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 1;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(530, 83);
            this.lblDescription.TabIndex = 2;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(303, 356);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // chkMonitoringStatus
            // 
            this.chkMonitoringStatus.AutoSize = true;
            this.chkMonitoringStatus.Checked = true;
            this.chkMonitoringStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonitoringStatus.Location = new System.Drawing.Point(12, 99);
            this.chkMonitoringStatus.Name = "chkMonitoringStatus";
            this.chkMonitoringStatus.Size = new System.Drawing.Size(126, 17);
            this.chkMonitoringStatus.TabIndex = 4;
            this.chkMonitoringStatus.Text = "Monitoring is enabled";
            this.chkMonitoringStatus.UseVisualStyleBackColor = true;
            this.chkMonitoringStatus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkMonitoringStatus_MouseClick);
            // 
            // btnStartServices
            // 
            this.btnStartServices.Location = new System.Drawing.Point(163, 327);
            this.btnStartServices.Name = "btnStartServices";
            this.btnStartServices.Size = new System.Drawing.Size(89, 23);
            this.btnStartServices.TabIndex = 5;
            this.btnStartServices.Text = "Start services";
            this.btnStartServices.UseVisualStyleBackColor = true;
            this.btnStartServices.Click += new System.EventHandler(this.btnStartServices_Click);
            // 
            // btnStopServices
            // 
            this.btnStopServices.Location = new System.Drawing.Point(303, 327);
            this.btnStopServices.Name = "btnStopServices";
            this.btnStopServices.Size = new System.Drawing.Size(89, 23);
            this.btnStopServices.TabIndex = 6;
            this.btnStopServices.Text = "Stop services";
            this.btnStopServices.UseVisualStyleBackColor = true;
            this.btnStopServices.Click += new System.EventHandler(this.btnStopServices_Click);
            // 
            // lsvSuspendServices
            // 
            this.lsvSuspendServices.ContextMenuStrip = this.mnuService;
            this.lsvSuspendServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvSuspendServices.Location = new System.Drawing.Point(3, 16);
            this.lsvSuspendServices.Name = "lsvSuspendServices";
            this.lsvSuspendServices.Size = new System.Drawing.Size(524, 79);
            this.lsvSuspendServices.TabIndex = 7;
            this.lsvSuspendServices.UseCompatibleStateImageBehavior = false;
            this.lsvSuspendServices.View = System.Windows.Forms.View.Details;
            this.lsvSuspendServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsvSuspendServices_MouseDown);
            // 
            // mnuService
            // 
            this.mnuService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.mnuService.Name = "mnuService";
            this.mnuService.Size = new System.Drawing.Size(99, 48);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // grpSuspendServices
            // 
            this.grpSuspendServices.Controls.Add(this.lsvSuspendServices);
            this.grpSuspendServices.Location = new System.Drawing.Point(12, 122);
            this.grpSuspendServices.Name = "grpSuspendServices";
            this.grpSuspendServices.Size = new System.Drawing.Size(530, 98);
            this.grpSuspendServices.TabIndex = 8;
            this.grpSuspendServices.TabStop = false;
            this.grpSuspendServices.Text = "Services to be stopped on Suspend event";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(467, 95);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpResumeServices
            // 
            this.grpResumeServices.Controls.Add(this.lsvResumeServices);
            this.grpResumeServices.Location = new System.Drawing.Point(12, 226);
            this.grpResumeServices.Name = "grpResumeServices";
            this.grpResumeServices.Size = new System.Drawing.Size(530, 95);
            this.grpResumeServices.TabIndex = 10;
            this.grpResumeServices.TabStop = false;
            this.grpResumeServices.Text = "Services to be started on Resume event";
            // 
            // lsvResumeServices
            // 
            this.lsvResumeServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvResumeServices.Location = new System.Drawing.Point(3, 16);
            this.lsvResumeServices.Name = "lsvResumeServices";
            this.lsvResumeServices.Size = new System.Drawing.Size(524, 76);
            this.lsvResumeServices.TabIndex = 0;
            this.lsvResumeServices.UseCompatibleStateImageBehavior = false;
            this.lsvResumeServices.View = System.Windows.Forms.View.Details;
            this.lsvResumeServices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lsvResumeServices_MouseDown);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 391);
            this.Controls.Add(this.grpResumeServices);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpSuspendServices);
            this.Controls.Add(this.btnStopServices);
            this.Controls.Add(this.btnStartServices);
            this.Controls.Add(this.chkMonitoringStatus);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonitorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MonitorForm_FormClosing);
            this.mnuNotifyIcon.ResumeLayout(false);
            this.mnuService.ResumeLayout(false);
            this.grpSuspendServices.ResumeLayout(false);
            this.grpResumeServices.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip mnuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem itmShow;
        private System.Windows.Forms.ToolStripMenuItem itmHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itmQuit;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem itmStartMonitoring;
        private System.Windows.Forms.ToolStripMenuItem itmStopMonitoring;
        private System.Windows.Forms.CheckBox chkMonitoringStatus;
        private System.Windows.Forms.Button btnStartServices;
        private System.Windows.Forms.Button btnStopServices;
        private System.Windows.Forms.ListView lsvSuspendServices;
        private System.Windows.Forms.GroupBox grpSuspendServices;
        private System.Windows.Forms.ContextMenuStrip mnuService;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpResumeServices;
        private System.Windows.Forms.ListView lsvResumeServices;
    }
}

