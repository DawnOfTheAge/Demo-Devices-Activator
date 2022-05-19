namespace DemoDevicesActivator
{
    public partial class FrmAddDemoDevice : Form
    {
        #region Events

        public event DeviceReadyMessage ?DeviceSave;

        #endregion

        #region Data Members

        private int presetId;
        private int deviceId;

        private DemoDeviceProperties device;

        private readonly CrudType mode;

        #endregion

        #region Constructors

        public FrmAddDemoDevice(int inPresetId)
        {
            InitializeComponent();

            presetId = inPresetId;
            deviceId = Constants.NONE;

            device = new DemoDeviceProperties();

            mode = CrudType.Create;
        }

        public FrmAddDemoDevice(DemoDeviceProperties inDevice)
        {
            InitializeComponent();

            device = inDevice;

            mode = CrudType.Update;
        }

        #endregion

        #region Startup

        private void FrmAddDemoDevice_Load(object sender, EventArgs e)
        {
            try
            {
                Location = Cursor.Position;

                foreach (string deviceType in Enum.GetNames(typeof(DeviceType)))
                {
                    if (!deviceType.ToLower().Equals(DeviceType.Unknown.ToString().ToLower()))
                    {
                       cboDeviceTypes.Items.Add(deviceType);
                    }
                }

                if (mode == CrudType.Update)
                {
                    deviceId = device.Id;
                    presetId = device.PresetId;

                    cboDeviceTypes.Text = device.Type.ToString();
                    txtDeviceName.Text = device.Name;
                    nudPort.Value = device.Port;
                }

                btnAdd.Text = (mode == CrudType.Update) ? "Update" : "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Gui

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Enum.TryParse(cboDeviceTypes.Text, out DeviceType deviceType))
                {
                    deviceType = DeviceType.Unknown;
                }

                device = new DemoDeviceProperties()
                {
                    PresetId = presetId,
                    Port = (int)nudPort.Value,
                    Name = txtDeviceName.Text,
                    Type = deviceType,
                    Id = deviceId,
                };

                OnDeviceSave();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        #region Events Handlers

        public void OnDeviceSave()
        {
            if (device != null)
            {
                DeviceSave?.Invoke(device);
            }
        }

        #endregion
    }
}
