namespace DemoDevicesActivator
{
    public class DemoDeviceProperties
    {
        #region Properties

        public string Name { get; set; }

        public DeviceType Type { get; set; }

        public int Port { get; set; }

        public int Id { get; set; }
        
        public int PresetId { get; set; }

        #endregion

        #region Constructors

        public DemoDeviceProperties()
        {
            Id = Constants.NONE;
            PresetId = Constants.NONE;
            Port = Constants.NONE;
            Type = DeviceType.Unknown;
            Name = string.Empty;
        }

        public DemoDeviceProperties(int id, int presetId, DeviceType type, string name, int port)
        {
            Id = id;
            PresetId = presetId;
            Port = port;
            Type = type;
            Name = name;
        }

        #endregion
    }
}
