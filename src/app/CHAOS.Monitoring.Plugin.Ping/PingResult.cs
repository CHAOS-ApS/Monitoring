using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHAOS.Monitoring.Plugin.Ping
{
    public class PingResult: IPluginResult
    {
        public long Result { get; set; }
    }
}
