using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDevicesActivator
{
    public delegate void ConfigurationMessage(ActivatorConfiguration configuration);
    public delegate void DeviceReadyMessage(DemoDeviceProperties device);
}
