namespace DemoDevicesActivator
{
    public class ActivatorConfiguration
    {
        #region Properties

        public string ExecutablePath { get; set; }

        public List<DemoDevicesPreset> Presets { get; set; }

        #endregion

        #region Constructors

        public ActivatorConfiguration()
        {
            ExecutablePath = string.Empty;

            Presets = new List<DemoDevicesPreset>();
        }

        public ActivatorConfiguration(string executablePath)
        {
            ExecutablePath = executablePath;

            Presets = new List<DemoDevicesPreset>();
        }

        #endregion

        #region Public Methods

        public bool AddPreset(int id, string name, List<DemoDeviceProperties> devices, out string result)
        {
            result = string.Empty;

            try
            {
                if (devices == null)
                {
                    devices = new List<DemoDeviceProperties>();
                }

                if (string.IsNullOrEmpty(name))
                {
                    result = $"Preset Must Have A Name";

                    return false;
                }

                if (Presets.Find(preset => preset.Id == id) != null)
                {
                    result = $"Preset With ID[{id}] Aleady Exists";

                    return false;
                }

                if (Presets.Find(preset => preset.Name == name) != null)
                {
                    result = $"Preset With Name[{name}] Aleady Exists";

                    return false;
                }

                Presets.Add(new DemoDevicesPreset(id, name, devices));

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool UpdatePreset(int id, string name, List<DemoDeviceProperties> devices, out string result)
        {
            result = string.Empty;

            try
            {
                if (Presets == null)
                {
                    Presets = new List<DemoDevicesPreset>();

                    result = "Presets List Is Empty";

                    return false;
                }

                int presetIndex = devices.FindIndex(preset => preset.Id == id);
                if (presetIndex == Constants.NONE)
                {
                    result = $"Preset With ID[{id}] Does Not Exists";

                    return false;
                }

                Presets[presetIndex].Name = name;
                if (!Presets[presetIndex].AddDevices(devices, out result))
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

        public bool DeletePreset(int id, out string result)
        {
            result = string.Empty;

            try
            {
                if (Presets == null)
                {
                    Presets = new List<DemoDevicesPreset>();

                    result = "Presets List Is Empty";

                    return false;
                }

                int presetIndex = Presets.FindIndex(preset => preset.Id == id);
                if (presetIndex == Constants.NONE)
                {
                    result = $"Preset With ID[{id}] Does Not Exists";

                    return false;
                }

                Presets.RemoveAt(presetIndex);

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool DeletePreset(string name, out string result)
        {
            result = string.Empty;

            try
            {
                if (Presets == null)
                {
                    Presets = new List<DemoDevicesPreset>();

                    result = "Presets List Is Empty";

                    return false;
                }

                int presetIndex = Presets.FindIndex(preset => preset.Name.ToLower() == name.ToLower());
                if (presetIndex == Constants.NONE)
                {
                    result = $"Preset With Name[{name}] Does Not Exists";

                    return false;
                }

                Presets.RemoveAt(presetIndex);

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
                if (Presets == null)
                {
                    Presets = new List<DemoDevicesPreset>();

                    return 1;
                }

                if (Presets.Count == 0)
                {
                    return 1;
                }

                int newId = Presets.Max(preset => preset.Id) + 1;

                return newId;
            }
            catch (Exception)
            {
                return Constants.NONE;
            }
        }

        public bool NameExists(string newPresetName, out string result)
        {
            try
            {
                result = string.Empty;

                if (Presets == null)
                {
                    Presets = new List<DemoDevicesPreset>();

                    return false;
                }

                if (Presets.Count == 0)
                {
                    return false;
                }

                DemoDevicesPreset ?foundPreset = Presets.Find(preset => preset.Name.ToLower() == newPresetName.ToLower());

                return foundPreset != null;
            }
            catch (Exception e)
            {
                result = e.Message;

                return true;
            }
        }

        public int GetIndex(int presetId, out string result)
        {
            try
            {
                result = string.Empty;

                if ((Presets == null) || (Presets.Count == 0))
                {
                    result = "No Presets";

                    return 1;
                }

                int foundIndex = Presets.FindIndex(preset => preset.Id == presetId);

                return foundIndex;
            }
            catch (Exception e)
            {
                result = e.Message;

                return Constants.NONE;
            }
        }

        public bool GetDevices(int presetId, out List<DemoDeviceProperties> ?devices, out string result)
        {
            result = string.Empty;
            devices = null;

            try
            {
                if ((Presets == null) || (Presets.Count == 0))
                {
                    result = "No Presets";

                    return false;
                }

                DemoDevicesPreset ?foundPreset = Presets.Find(preset => preset.Id == presetId);
                if (foundPreset == null)
                {
                    result = $"No Preset With Preset ID[{presetId}]";

                    return false;
                }

                devices = foundPreset.Devices;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool GetDevices(string presetName, out List<DemoDeviceProperties>? devices, out string result)
        {
            result = string.Empty;
            devices = null;

            try
            {
                if ((Presets == null) || (Presets.Count == 0))
                {
                    result = "No Presets";

                    return false;
                }

                DemoDevicesPreset? foundPreset = Presets.Find(preset => preset.Name.ToLower() == presetName.ToLower());
                if (foundPreset == null)
                {
                    result = $"No Preset With Preset Name[{presetName}]";

                    return false;
                }

                devices = foundPreset.Devices;

                return true;
            }
            catch (Exception e)
            {
                result = e.Message;

                return false;
            }
        }

        public bool PortExists(int port, out string result)
        {
            try
            {
                result = string.Empty;

                if (Presets == null)
                {
                    result = "No Presets";

                    return false;
                }

                foreach (DemoDevicesPreset preset in Presets)
                {
                    if (preset.PortExists(port, out result))
                    {
                        return true;
                    }
                }

                return false;
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
