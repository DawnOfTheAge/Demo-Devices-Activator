using System.Diagnostics;
using System.Reflection;

namespace DemoDevicesActivator
{
    public partial class FrmMain : Form
    {
        #region Data Members

        private string JsonFilesPath;

        private ActivatorConfiguration configuration;

        #endregion

        #region Constructor

        public FrmMain()
        {
            InitializeComponent();

            JsonFilesPath = string.Empty;
            configuration = new();
        }

        #endregion

        #region Startup

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                if (!Initialize(out string result))
                {
                    MessageBox.Show(result, "Initialize Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Initialize Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Initialize(out string result)
        {
            try
            {
                #region Configuration

                JsonFilesPath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\JsonFiles\";
                if (!ReadConfiguration(out result))
                {
                    return false;
                }

                #endregion

                #region Fill Presets Menu

                if (!FillPresetsMenu(out result))
                {
                    return false;
                }

                #endregion

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;
                
                return false;
            }
        }

        #endregion

        #region Configuration

        private bool ReadConfiguration(out string result)
        {
            string filename;

            try
            {
                filename = $"{JsonFilesPath}ActivatorConfiguration.json";
                if (!File.Exists(filename))
                {
                    result = $"File '{filename}' Does Not Exist";

                    return false;
                }

                if (!JsonUtils.Json2Object(filename, out configuration, out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        private bool SaveConfiguration(out string result)
        {
            try
            {
                string filename = $"{JsonFilesPath}ActivatorConfiguration.json";

                if (!JsonUtils.Object2Json(filename, configuration, out result))
                {
                    return false;
                }

                if (!FillPresetsMenu(out result))
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion

        #region Gui

        #region Main Menu

        private void MnuSettings_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSettings settings = new(configuration);
                settings.ConfigurationSave += Settings_ConfigurationSave;
                settings.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Settings_ConfigurationSave(ActivatorConfiguration inConfiguration)
        {
            try
            {
                if (inConfiguration == null)
                {
                    MessageBox.Show("Configuration Is Null", "Save Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                configuration = inConfiguration;

                if (!SaveConfiguration(out string result))
                {
                    MessageBox.Show(result, "Save Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Save Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MnuActivate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int row = 0; row < dgvDemoDevices.Rows.Count; row++)
                {
                    string ?type = dgvDemoDevices.Rows[row].Cells[0].Value.ToString();
                    if (string.IsNullOrEmpty(type))
                    {
                        continue;
                    }

                    string? name = dgvDemoDevices.Rows[row].Cells[1].Value.ToString();
                    if (string.IsNullOrEmpty(name))
                    {
                        continue;
                    }

                    string? portString = dgvDemoDevices.Rows[row].Cells[2].Value.ToString();
                    if (string.IsNullOrEmpty(portString))
                    {
                        continue;
                    }

                    int port = int.TryParse(portString, out port) ? port : Constants.NONE;
                    if (port == Constants.NONE)
                    {
                        continue;
                    }

                    Process process = new();
                    process.StartInfo.FileName = configuration.ExecutablePath;
                    process.StartInfo.Arguments = $"-p {port} -n {name} -t {type}";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Activate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion

        #region Data Grid View

        private bool FillGrid(List<DemoDeviceProperties> devices, out string result)
        {
            try
            {
                result = string.Empty;

                if ((devices == null) || (devices.Count == 0))
                {
                    result = "No Devices";

                    return true;
                }

                dgvDemoDevices.Rows.Clear();
                foreach (DemoDeviceProperties device in devices)
                {
                    dgvDemoDevices.Rows.Add(new string[] { device.Type.ToString(), device.Name, device.Port.ToString(), device.Id.ToString() });
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
            
        }

        #endregion

        #endregion
        
        #region Handlers

        private void ShowPresetDevicesHandler(object? sender, EventArgs e)
        {
            try
            {
                if (sender == null)
                {
                    MessageBox.Show("Wrong Sender", 
                                    "Show Preset Devices Handler Error", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Warning);

                    return;
                }

                Type t = sender.GetType();

                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem item = (ToolStripMenuItem)sender;
                    string presetName = item.Text;

                    if (!configuration.GetDevices(presetName, 
                                                  out List<DemoDeviceProperties> ?devices, 
                                                  out string result))
                    {
                        MessageBox.Show($"No Devices. {result}",
                                        "Show Preset Devices Handler Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                        return;
                    }

                    if ((devices == null) || (devices.Count == 0))
                    {
                        MessageBox.Show("No Devices",
                                        "Show Preset Devices Handler Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        return;
                    }

                    if (!FillGrid(devices, out result))
                    {
                        MessageBox.Show($"Failed Displaying Devices. {result}",
                                        "Show Preset Devices Handler Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }

                    Text = $"Demo Devices Activator - Active Preset[{presetName}]";
                }
                else
                {
                    MessageBox.Show("Wrong Sender Type",
                                    "Show Preset Devices Handler Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Preset Devices Handler Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Utils

        private bool FillPresetsMenu(out string result)
        {
            result = string.Empty;

            try
            {
                List<DemoDevicesPreset> presets = configuration.Presets;
                if ((presets != null) && (presets.Count > 0))
                {
                    mnuPresets.DropDownItems.Clear();
                    foreach (DemoDevicesPreset preset in presets)
                    {
                        mnuPresets.DropDownItems.Add(preset.Name, null, ShowPresetDevicesHandler);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        #endregion
    }
}
