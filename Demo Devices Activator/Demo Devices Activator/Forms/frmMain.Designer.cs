namespace DemoDevicesActivator
{
    partial class FrmMain
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
            this.dgvDemoDevices = new System.Windows.Forms.DataGridView();
            this.colDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevicePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPresets = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemoDevices)).BeginInit();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDemoDevices
            // 
            this.dgvDemoDevices.AllowUserToAddRows = false;
            this.dgvDemoDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDemoDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeviceType,
            this.colDeviceName,
            this.colDevicePort,
            this.colDeviceId});
            this.dgvDemoDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDemoDevices.Location = new System.Drawing.Point(0, 24);
            this.dgvDemoDevices.Name = "dgvDemoDevices";
            this.dgvDemoDevices.RowTemplate.Height = 25;
            this.dgvDemoDevices.Size = new System.Drawing.Size(457, 426);
            this.dgvDemoDevices.TabIndex = 2;
            // 
            // colDeviceType
            // 
            this.colDeviceType.HeaderText = "Device Type";
            this.colDeviceType.Name = "colDeviceType";
            this.colDeviceType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeviceType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDeviceName
            // 
            this.colDeviceName.HeaderText = "Device Name";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDevicePort
            // 
            this.colDevicePort.HeaderText = "Device Port ";
            this.colDevicePort.Name = "colDevicePort";
            // 
            // colDeviceId
            // 
            this.colDeviceId.HeaderText = "Device Id";
            this.colDeviceId.Name = "colDeviceId";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuPresets,
            this.mnuActivate,
            this.mnuExit});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(457, 24);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.MnuSettings_Click);
            // 
            // mnuPresets
            // 
            this.mnuPresets.Name = "mnuPresets";
            this.mnuPresets.Size = new System.Drawing.Size(56, 20);
            this.mnuPresets.Text = "Presets";
            // 
            // mnuActivate
            // 
            this.mnuActivate.Name = "mnuActivate";
            this.mnuActivate.Size = new System.Drawing.Size(62, 20);
            this.mnuActivate.Text = "Activate";
            this.mnuActivate.Click += new System.EventHandler(this.MnuActivate_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(38, 20);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 450);
            this.Controls.Add(this.dgvDemoDevices);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FrmMain";
            this.Text = "Demo Devices Activator";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDemoDevices)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvDemoDevices;
        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuSettings;
        private ToolStripMenuItem mnuPresets;
        private ToolStripMenuItem mnuActivate;
        private ToolStripMenuItem mnuExit;
        private DataGridViewTextBoxColumn colDeviceType;
        private DataGridViewTextBoxColumn colDeviceName;
        private DataGridViewTextBoxColumn colDevicePort;
        private DataGridViewTextBoxColumn colDeviceId;
    }
}