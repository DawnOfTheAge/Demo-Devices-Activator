namespace DemoDevicesActivator
{
    public class DemoDevicesPreset
    {
        #region Properties

        public string Name { get; set; }

        public int Id { get; set; }

        public List<DemoDeviceProperties> Devices { get; set; }

        #endregion

        #region Constructors

        public DemoDevicesPreset()
        {
            Id = Constants.NONE;
            
            Name = string.Empty;

            Devices = new List<DemoDeviceProperties>();
        }

        public DemoDevicesPreset(int id, string name, List<DemoDeviceProperties> devices)
        {
            Id = id;
            
            Name = name;

            Devices = devices;
        }

        #endregion

        #region Public Methods

        public bool AddDevice(DemoDeviceProperties newDevice, out string result)
        {
            result = string.Empty;

            try
            {
                if (newDevice == null)
                {
                    result = "Added Device Is Null";

                    return false;
                }

                if (string.IsNullOrEmpty(newDevice.Name))
                {
                    result = "Device Must Have A Name";

                    return false;
                }

                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();
                }

                if (Devices.Find(device => device.Id == newDevice.Id) != null)
                {
                    result = $"Device With ID[{newDevice.Id}] Aleady Exists";

                    return false;
                }

                if (Devices.Find(device => device.Type == newDevice.Type && device.Name == newDevice.Name) != null)
                {
                    result = $"Device With Type[{newDevice.Type}] And Name[{newDevice.Name}] Aleady Exists";

                    return false;
                }

                if (Devices.Find(device => device.Port == newDevice.Port) != null)
                {
                    result = $"Device With Port[{newDevice.Port}] Aleady Exists";

                    return false;
                }

                Devices.Add(newDevice);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool AddDevices(List<DemoDeviceProperties> devices, out string result)
        {
            result = string.Empty;

            try
            {
                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();
                }

                Devices.Clear();
                Devices.AddRange(devices);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool UpdateDevice(DemoDeviceProperties updatedDevice, out string result)
        {
            result = string.Empty;

            try
            {
                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();

                    result = "Devices List Is Empty";

                    return false;
                }

                int deviceIndex = Devices.FindIndex(device => device.Id == updatedDevice.Id);
                if (deviceIndex == Constants.NONE)
                {
                    result = $"Device With ID[{updatedDevice.Id}] Does Not Exists";

                    return false;
                }

                Devices[deviceIndex] = updatedDevice;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool DeleteDevice(int id, out string result)
        {
            result = string.Empty;

            try
            {
                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();

                    result = "Devices List Is Empty";

                    return false;
                }

                int deviceIndex = Devices.FindIndex(device => device.Id == id);
                if (deviceIndex == Constants.NONE)
                {
                    result = $"Device With ID[{id}] Does Not Exists";

                    return false;
                }

                Devices.RemoveAt(deviceIndex);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public int GetNewId()
        {
            try
            {
                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();

                    return 1;
                }

                if (Devices.Count == 0)
                {
                    return 1;
                }

                int newId = Devices.Max(device => device.Id) + 1;

                return newId;
            }
            catch (Exception)
            {
                return Constants.NONE;
            }
        }

        public bool NameExists(string newDeviceName, DeviceType newDeviceType, out string result)
        {
            try
            {
                result = string.Empty;

                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();

                    return false;
                }

                if (Devices.Count == 0)
                {
                    return false;
                }

                DemoDeviceProperties? foundDevice = Devices.Find(device => device.Name.ToLower() == newDeviceName.ToLower() && 
                                                                           device.Type == newDeviceType);

                return foundDevice != null;
            }
            catch (Exception e)
            {
                result = e.Message;

                return true;
            }
        }

        public bool PortExists(int newPort, out string result)
        {
            try
            {
                result = string.Empty;

                if (Devices == null)
                {
                    Devices = new List<DemoDeviceProperties>();

                    return false;
                }

                if (Devices.Count == 0)
                {
                    return false;
                }

                DemoDeviceProperties? foundDevice = Devices.Find(device => device.Port == newPort);

                return foundDevice != null;
            }
            catch (Exception e)
            {
                result = e.Message;

                return true;
            }
        }

        #endregion
    }
}
