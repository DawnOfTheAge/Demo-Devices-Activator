namespace DemoDevicesActivator
{
    partial class FrmAddDemoDevice
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.cboDeviceTypes = new System.Windows.Forms.ComboBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.lblDevicePort = new System.Windows.Forms.Label();
            this.lblDeviceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(278, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.AutoSize = true;
            this.lblDeviceType.Location = new System.Drawing.Point(13, 15);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(69, 15);
            this.lblDeviceType.TabIndex = 1;
            this.lblDeviceType.Text = "Device Type";
            // 
            // cboDeviceTypes
            // 
            this.cboDeviceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceTypes.FormattingEnabled = true;
            this.cboDeviceTypes.Location = new System.Drawing.Point(97, 12);
            this.cboDeviceTypes.Name = "cboDeviceTypes";
            this.cboDeviceTypes.Size = new System.Drawing.Size(121, 23);
            this.cboDeviceTypes.TabIndex = 2;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(97, 79);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(120, 23);
            this.nudPort.TabIndex = 3;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(97, 45);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(256, 23);
            this.txtDeviceName.TabIndex = 4;
            // 
            // lblDevicePort
            // 
            this.lblDevicePort.AutoSize = true;
            this.lblDevicePort.Location = new System.Drawing.Point(13, 81);
            this.lblDevicePort.Name = "lblDevicePort";
            this.lblDevicePort.Size = new System.Drawing.Size(67, 15);
            this.lblDevicePort.TabIndex = 5;
            this.lblDevicePort.Text = "Device Port";
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(13, 48);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(77, 15);
            this.lblDeviceName.TabIndex = 6;
            this.lblDeviceName.Text = "Device Name";
            // 
            // frmAddDemoDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 115);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.lblDevicePort);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.cboDeviceTypes);
            this.Controls.Add(this.lblDeviceType);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddDemoDevice";
            this.Text = "Add Demo Device";
            this.Load += new System.EventHandler(this.FrmAddDemoDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAdd;
        private Label lblDeviceType;
        private ComboBox cboDeviceTypes;
        private NumericUpDown nudPort;
        private TextBox txtDeviceName;
        private Label lblDevicePort;
        private Label lblDeviceName;
    }
}