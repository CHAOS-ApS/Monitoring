using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Factory.Ping
{
    public class PingFactory: IFactory
    {
        public IPlugin InitilizePlugin( string parameters )
        {
            return ( new Plugin.Ping.Ping( parameters ) );
        }
    }
}
