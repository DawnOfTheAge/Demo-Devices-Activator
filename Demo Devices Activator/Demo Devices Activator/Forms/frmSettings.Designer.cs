namespace DemoDevicesActivator
{
    partial class FrmSettings
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
            this.btnExecutablePath = new System.Windows.Forms.Button();
            this.txtExecutablePath = new System.Windows.Forms.TextBox();
            this.lblExecutablePath = new System.Windows.Forms.Label();
            this.dgvPresets = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.lblPresets = new System.Windows.Forms.Label();
            this.lblDevices = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecutablePath
            // 
            this.btnExecutablePath.BackgroundImage = global::DemoDevicesActivator.Properties.Resources._3Dots;
            this.btnExecutablePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExecutablePath.Location = new System.Drawing.Point(545, 23);
            this.btnExecutablePath.Name = "btnExecutablePath";
            this.btnExecutablePath.Size = new System.Drawing.Size(30, 30);
            this.btnExecutablePath.TabIndex = 0;
            this.btnExecutablePath.UseVisualStyleBackColor = true;
            this.btnExecutablePath.Click += new System.EventHandler(this.BtnExecutablePath_Click);
            // 
            // txtExecutablePath
            // 
            this.txtExecutablePath.Location = new System.Drawing.Point(123, 28);
            this.txtExecutablePath.Name = "txtExecutablePath";
            this.txtExecutablePath.Size = new System.Drawing.Size(416, 23);
            this.txtExecutablePath.TabIndex = 1;
            // 
            // lblExecutablePath
            // 
            this.lblExecutablePath.AutoSize = true;
            this.lblExecutablePath.Location = new System.Drawing.Point(26, 31);
            this.lblExecutablePath.Name = "lblExecutablePath";
            this.lblExecutablePath.Size = new System.Drawing.Size(91, 15);
            this.lblExecutablePath.TabIndex = 2;
            this.lblExecutablePath.Text = "Executable Path";
            // 
            // dgvPresets
            // 
            this.dgvPresets.AllowUserToAddRows = false;
            this.dgvPresets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName});
            this.dgvPresets.Location = new System.Drawing.Point(26, 124);
            this.dgvPresets.Name = "dgvPresets";
            this.dgvPresets.RowTemplate.Height = 25;
            this.dgvPresets.Size = new System.Drawing.Size(256, 290);
            this.dgvPresets.TabIndex = 3;
            this.dgvPresets.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvPresets_MouseDown);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colType,
            this.dataGridViewTextBoxColumn2,
            this.colPort,
            this.colPresetId});
            this.dgvDevices.Location = new System.Drawing.Point(364, 124);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowTemplate.Height = 25;
            this.dgvDevices.Size = new System.Drawing.Size(424, 290);
            this.dgvDevices.TabIndex = 4;
            this.dgvDevices.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvDevices_MouseDown);
            // 
            // lblPresets
            // 
            this.lblPresets.AutoSize = true;
            this.lblPresets.Location = new System.Drawing.Point(26, 106);
            this.lblPresets.Name = "lblPresets";
            this.lblPresets.Size = new System.Drawing.Size(44, 15);
            this.lblPresets.TabIndex = 5;
            this.lblPresets.Text = "Presets";
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(364, 106);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(47, 15);
            this.lblDevices.TabIndex = 6;
            this.lblDevices.Text = "Devices";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // colPort
            // 
            this.colPort.HeaderText = "Port";
            this.colPort.Name = "colPort";
            // 
            // colPresetId
            // 
            this.colPresetId.HeaderText = "Preset ID";
            this.colPresetId.Name = "colPresetId";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.lblPresets);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.dgvPresets);
            this.Controls.Add(this.lblExecutablePath);
            this.Controls.Add(this.txtExecutablePath);
            this.Controls.Add(this.btnExecutablePath);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnExecutablePath;
        private TextBox txtExecutablePath;
        private Label lblExecutablePath;
        private DataGridView dgvPresets;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridView dgvDevices;
        private Label lblPresets;
        private Label lblDevices;
        private Button btnSave;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn colPort;
        private DataGridViewTextBoxColumn colPresetId;
    }
}