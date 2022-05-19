namespace DemoDevicesActivator
{
    public partial class FrmSettings : Form
    {
        #region Events

        public event ConfigurationMessage ?ConfigurationSave;

        #endregion

        #region Data Members

        private ActivatorConfiguration configuration;

        private ToolStripDropDownMenu presetsContextMenu;
        private ToolStripDropDownMenu devicesContextMenu;

        #endregion

        #region Constructor

        public FrmSettings(ActivatorConfiguration inConfiguration)
        {
            InitializeComponent();

            devicesContextMenu = new ToolStripDropDownMenu();
            presetsContextMenu = new ToolStripDropDownMenu();

            configuration = inConfiguration;
        }

        #endregion

        #region Startup

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                string result;

                Location = Cursor.Position;

                if (configuration == null)
                {
                    configuration = new();
                }

                txtExecutablePath.Text = configuration.ExecutablePath;

                List<DemoDevicesPreset> presets = configuration.Presets;

                if ((presets != null) && (presets.Count > 0))
                {
                    if (!FillPresetsGrid(presets, out result))
                    {
                        MessageBox.Show(result, "Fill Presets Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (!CreateContextMenus(out result))
                {
                    MessageBox.Show(result, "Create Context Menus Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Gui

        #region Context Menu

        private bool CreateContextMenus(out string result)
        {
            result = string.Empty;

            try
            {
                presetsContextMenu = new ToolStripDropDownMenu();
                presetsContextMenu.Items.Add("Add Preset", null, new EventHandler(AddPreset));
                presetsContextMenu.Items.Add("Update Preset", null, new EventHandler(UpdatePreset));
                presetsContextMenu.Items.Add("Delete Preset", null, new EventHandler(DeletePreset));

                devicesContextMenu = new ToolStripDropDownMenu();
                devicesContextMenu.Items.Add("Add Device", null, new EventHandler(AddDevice));
                devicesContextMenu.Items.Add("Update Device", null, new EventHandler(UpdateDevice));
                devicesContextMenu.Items.Add("Delete Device", null, new EventHandler(DeleteDevice));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #region Devices

        private void DeleteDevice(object? sender, EventArgs e)
        {
            int rowIndex;
            int presetId;
            int deviceId;
            
            string ?deviceIdString;
            string ?presetIdString;
            string ?deviceName;

            try
            {
                rowIndex = dgvDevices.SelectedRows[0].Index;
                deviceIdString = dgvDevices.Rows[rowIndex].Cells[0].Value.ToString();
                deviceName = dgvDevices.Rows[rowIndex].Cells[2].Value.ToString();
                presetIdString = dgvDevices.Rows[rowIndex].Cells[4].Value.ToString();

                presetId = int.TryParse(presetIdString, out presetId) ? presetId : Constants.NONE;
                deviceId = int.TryParse(deviceIdString, out deviceId) ? deviceId : Constants.NONE;

                if (string.IsNullOrEmpty(deviceName))
                {
                    MessageBox.Show("No Device Name",
                                    "Failed Deleting Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return;
                }

                if (presetId == Constants.NONE)
                {
                    MessageBox.Show("Preset ID Not Found",
                                    "Failed Deleting Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                if (deviceId == Constants.NONE)
                {
                    MessageBox.Show("Device ID Not Found",
                                    "Failed Deleting Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                int presetIndex = configuration.GetIndex(presetId, out string result);
                if (presetIndex == Constants.NONE)
                {
                    MessageBox.Show($"Preset With ID[{presetId}] Not Found",
                                    "Failed Deleting Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Delete Device '{deviceName}'?",
                                                            "Delete Device",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (!configuration.Presets[presetIndex].DeleteDevice(deviceId, out result))
                    {
                        MessageBox.Show(result,
                                        $"Failed Deleting Device '{deviceName}'",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                        return;
                    }
                }

                if (!FillDevicesGrid(configuration.Presets[presetIndex].Devices, out result))
                {
                    MessageBox.Show(result, "Fill Devices Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Failed Deleting Preset",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void UpdateDevice(object? sender, EventArgs e)
        {
            int rowIndex;
            int presetId;
            int deviceId;
            int port;

            string? portString;
            string? deviceIdString;
            string? presetIdString;
            string? deviceName;
            string? deviceTypeString;

            try
            {
                rowIndex = dgvDevices.SelectedRows[0].Index;
                deviceIdString = dgvDevices.Rows[rowIndex].Cells[0].Value.ToString();
                deviceName = dgvDevices.Rows[rowIndex].Cells[2].Value.ToString();
                deviceTypeString = dgvDevices.Rows[rowIndex].Cells[1].Value.ToString();
                portString = dgvDevices.Rows[rowIndex].Cells[3].Value.ToString();
                presetIdString = dgvDevices.Rows[rowIndex].Cells[4].Value.ToString();

                presetId = int.TryParse(presetIdString, out presetId) ? presetId : Constants.NONE;
                deviceId = int.TryParse(deviceIdString, out deviceId) ? deviceId : Constants.NONE;
                port = int.TryParse(portString, out port) ? port : Constants.NONE;

                if (string.IsNullOrEmpty(deviceName))
                {
                    MessageBox.Show("No Device Name",
                                    "Failed Updating Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return;
                }

                if (presetId == Constants.NONE)
                {
                    MessageBox.Show("Preset ID Not Found",
                                    "Failed Updating Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                if (deviceId == Constants.NONE)
                {
                    MessageBox.Show("Device ID Not Found",
                                    "Failed Updating Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                if (port == Constants.NONE)
                {
                    MessageBox.Show("Port Not Found",
                                    "Failed Updating Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                int presetIndex = configuration.GetIndex(presetId, out string result);
                if (presetIndex == Constants.NONE)
                {
                    MessageBox.Show($"Preset With ID[{presetId}] Not Found",
                                    "Failed Updating Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Update Device '{deviceName}'?",
                                                            "Update Device",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (!Enum.TryParse(deviceTypeString, out DeviceType deviceType))
                    {
                        deviceType = DeviceType.Unknown;
                    }

                    DemoDeviceProperties device = new()
                    {
                        Id = deviceId,
                        Type = deviceType,
                        Name = deviceName,
                        PresetId = presetId,
                        Port = port
                    };

                    FrmAddDemoDevice updateDevice = new(device);
                    updateDevice.DeviceSave += UpdateDevice_DeviceSave;
                    updateDevice.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Failed Updating Preset",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void AddDevice(object? sender, EventArgs e)
        {
            int rowIndex;
            int presetId;
            
            string ?presetIdString;

            try
            {
                rowIndex = dgvPresets.SelectedRows[0].Index;
                presetIdString = dgvPresets.Rows[rowIndex].Cells[0].Value.ToString();

                if (string.IsNullOrEmpty(presetIdString))
                {
                    return;
                }

                presetId = int.TryParse(presetIdString, out presetId) ? presetId : Constants.NONE;
                if (presetId == Constants.NONE)
                {
                    MessageBox.Show("No Valid Preset Id",
                                    "Failed Adding Device",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    return;
                }

                FrmAddDemoDevice addDevice = new(presetId);
                addDevice.DeviceSave += AddDevice_DeviceSave;
                addDevice.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Failed Adding Device Preset",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void AddDevice_DeviceSave(DemoDeviceProperties device)
        {
            try
            {
                if (device == null)
                {
                    MessageBox.Show("Device Is Null", "Add Device Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int presetIndex = configuration.GetIndex(device.PresetId, out string result);
                if (presetIndex == Constants.NONE)
                {
                    MessageBox.Show($"No Preset With ID[{device.PresetId}]", 
                                    "Add Device Error", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Warning);

                    return;
                }
                
                int newDeviceId = configuration.Presets[presetIndex].GetNewId();

                if (newDeviceId == Constants.NONE)
                {
                    MessageBox.Show($"Can't Get New Device Id For Preset With ID[{device.PresetId}]",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return;
                }

                device.Id = newDeviceId;

                if (configuration.PortExists(device.Port, out result))
                {
                    MessageBox.Show($"Failed Adding New Device[{device.Id} - {device.Name}] Port[{device.Port}] Already Exists",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return;
                }

                if (!configuration.Presets[presetIndex].AddDevice(device, out result))
                {
                    MessageBox.Show($"Failed Adding New Device[{device.Id} - {device.Name}] For Preset With ID[{device.PresetId}]. {result}",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return;
                }

                if (!FillDevicesGrid(configuration.Presets[presetIndex].Devices, out result))
                {
                    MessageBox.Show($"Failed Displaying Devices For Preset With ID[{device.PresetId}]. {result}",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Save Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDevice_DeviceSave(DemoDeviceProperties device)
        {
            try
            {
                if (device == null)
                {
                    MessageBox.Show("Device Is Null", "Add Device Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                int presetIndex = configuration.GetIndex(device.PresetId, out string result);
                if (presetIndex == Constants.NONE)
                {
                    MessageBox.Show($"No Preset With ID[{device.PresetId}]",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return;
                }

                if (!configuration.Presets[presetIndex].UpdateDevice(device, out result))
                {
                    MessageBox.Show($"Failed Adding New Device[{device.Id} - {device.Name}] For Preset With ID[{device.PresetId}]. {result}",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    return;
                }

                if (!FillDevicesGrid(configuration.Presets[presetIndex].Devices, out result))
                {
                    MessageBox.Show($"Failed Displaying Devices For Preset With ID[{device.PresetId}]. {result}",
                                    "Add Device Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Save Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Presets

        private void DeletePreset(object? sender, EventArgs e)
        {
            int rowIndex;

            string? presetName;
            string result;

            try
            {
                rowIndex = dgvPresets.SelectedRows[0].Index;
                presetName = dgvPresets.Rows[rowIndex].Cells[1].Value.ToString();

                if (string.IsNullOrEmpty(presetName))
                {
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Delete Preset '{presetName}'?", 
                                                            "Delete Preset", 
                                                            MessageBoxButtons.YesNo, 
                                                            MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (!configuration.DeletePreset(presetName, out result))
                    {
                        MessageBox.Show(result,
                                        $"Failed Deleting Preset '{presetName}'",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);

                        return;
                    }
                }

                if (!FillPresetsGrid(configuration.Presets, out result))
                {
                    MessageBox.Show(result, "Fill Presets Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Failed Deleting Preset",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void UpdatePreset(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddPreset(object? sender, EventArgs e)
        {
            try
            {
                int newPresetId = configuration.GetNewId();
                if (newPresetId == Constants.NONE)
                {
                    MessageBox.Show("Can't Get New Preset Id", "Add Preset Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                string newPresetName = Microsoft.VisualBasic.Interaction.InputBox("Name", 
                                                                                  "Add Preset", 
                                                                                  $"Preset_{newPresetId}", 
                                                                                  Cursor.Position.X, 
                                                                                  Cursor.Position.Y);
                if (!configuration.AddPreset(newPresetId, newPresetName, new List<DemoDeviceProperties>(), out string result))
                {
                    MessageBox.Show(result, "Add Preset Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (!FillPresetsGrid(configuration.Presets, out result))
                {
                    MessageBox.Show(result, "Fill Presets Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Preset Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #endregion

        #region Grids

        private bool FillPresetsGrid(List<DemoDevicesPreset> presets, out string result)
        {
            try
            {
                result = string.Empty;

                if ((presets == null) || (presets.Count == 0))
                {
                    result = "No Presets";

                    return false;
                }

                dgvPresets.Rows.Clear();
                foreach (DemoDevicesPreset preset in presets)
                {
                    dgvPresets.Rows.Add(new string[] { preset.Id.ToString(), preset.Name });
                }

                lblPresets.Text = $"{presets.Count} Presets";

                return true;
            }
            catch (Exception ex)
            {
                result = $"Fill Presets Grid Error. {ex.Message}";

                return false;
            }
        }
        
        private void DgvPresets_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;

            try
            {
                if (dgvPresets.Rows.Count == 0)
                {
                    presetsContextMenu.Items[0].Visible = true;
                    presetsContextMenu.Items[1].Visible = false;
                    presetsContextMenu.Items[2].Visible = false;

                    presetsContextMenu.Show(dgvPresets, new Point(e.X, e.Y));
                }
                else
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Right:
                            hitTestInfo = dgvPresets.HitTest(e.X, e.Y);
                            if ((hitTestInfo.Type == DataGridViewHitTestType.RowHeader) || 
                                (hitTestInfo.Type == DataGridViewHitTestType.Cell))
                            {
                                dgvPresets.Rows[hitTestInfo.RowIndex].Selected = true;

                                presetsContextMenu.Items[0].Visible = false;
                                presetsContextMenu.Items[1].Visible = true;
                                presetsContextMenu.Items[2].Visible = true;
                            }
                            else
                            {
                                presetsContextMenu.Items[0].Visible = true;
                                presetsContextMenu.Items[1].Visible = false;
                                presetsContextMenu.Items[2].Visible = false;
                            }
                            
                            presetsContextMenu.Show(dgvPresets, new Point(e.X, e.Y));
                            break;

                        case MouseButtons.Left:
                            dgvDevices.Rows.Clear();

                            hitTestInfo = dgvPresets.HitTest(e.X, e.Y);

                            int rowIndex = hitTestInfo.RowIndex;
                            if (rowIndex == Constants.NONE)
                            {
                                return;
                            }

                            int presetId = int.TryParse(dgvPresets.Rows[rowIndex].Cells[0].Value.ToString(), 
                                                        out presetId) ? presetId : Constants.NONE;
                            if (presetId == Constants.NONE)
                            {
                                return;
                            }

                            if (!configuration.GetDevices(presetId, 
                                                          out List<DemoDeviceProperties> ?devices, 
                                                          out string result))
                            {
                                MessageBox.Show(result,
                                                $"Presets Grid Mouse Down Get Devices For Preset ID[{presetId}] Failure",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);

                                return;
                            }

                            if ((devices == null) || (devices.Count == 0))
                            {
                                return;
                            }

                            if (!FillDevicesGrid(devices, out result))
                            {
                                MessageBox.Show(result,
                                                $"Presets Grid Mouse Down Fill Devices Grid For Preset ID[{presetId}] Failure",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Presets Grid Mouse Down Failure",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private bool FillDevicesGrid(List<DemoDeviceProperties> devices, out string result)
        {
            try
            {
                result = string.Empty;

                if ((devices == null) || (devices.Count == 0))
                {
                    return true;
                }

                dgvDevices.Rows.Clear();
                foreach (DemoDeviceProperties device in devices)
                {
                    dgvDevices.Rows.Add(new string[] { device.Id.ToString(), 
                                                       device.Type.ToString(), 
                                                       device.Name, 
                                                       device.Port.ToString(),
                                                       device.PresetId.ToString() });
                }

                lblDevices.Text = $"{devices.Count} Devices";

                return true;
            }
            catch (Exception ex)
            {
                result = $"Fill Presets Grid Error. {ex.Message}";

                return false;
            }
        }

        private void DgvDevices_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;

            try
            {
                if (dgvPresets.SelectedRows.Count == 0)
                {
                    return;
                }

                if (dgvDevices.Rows.Count == 0)
                {
                    devicesContextMenu.Items[0].Visible = true;
                    devicesContextMenu.Items[1].Visible = false;
                    devicesContextMenu.Items[2].Visible = false;

                    devicesContextMenu.Show(dgvDevices, new Point(e.X, e.Y));
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        hitTestInfo = dgvDevices.HitTest(e.X, e.Y);
                        if ((hitTestInfo.Type == DataGridViewHitTestType.RowHeader) || 
                            (hitTestInfo.Type == DataGridViewHitTestType.Cell))
                        {
                            dgvDevices.Rows[hitTestInfo.RowIndex].Selected = true;

                            devicesContextMenu.Items[0].Visible = false;
                            devicesContextMenu.Items[1].Visible = true;
                            devicesContextMenu.Items[2].Visible = true;

                        }
                        else
                        {
                            devicesContextMenu.Items[0].Visible = true;
                            devicesContextMenu.Items[1].Visible = false;
                            devicesContextMenu.Items[2].Visible = false;
                        }

                        devicesContextMenu.Show(dgvDevices, new Point(e.X, e.Y));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Devices Grid Mouse Down Failure",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Buttons

        private void BtnExecutablePath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new()
                {
                    InitialDirectory = string.IsNullOrEmpty(configuration.ExecutablePath) ? @"c:\" : configuration.ExecutablePath,
                    Title = "Select 'Demo Device.exe' File",
                    DefaultExt = "exe",
                    Filter = "EXE files (*.exe)|*.exe",
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    txtExecutablePath.Text = openFile.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Executable Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                configuration.ExecutablePath = txtExecutablePath.Text;

                OnConfigurationSave();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region Events Handlers

        public void OnConfigurationSave()
        {
            if (configuration != null)
            {
                ConfigurationSave?.Invoke(configuration);
            }
        }

        #endregion
    }
}
