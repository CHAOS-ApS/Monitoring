using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Factory;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Core
{
    public class PluginManager
    {
        private List<IPlugin> _plugins = new List<IPlugin>( );

        public void LoadPlugin( IFactory factory, string parameters )
        {
            _plugins.Add(factory.InitilizePlugin(parameters));
        }

        public void RunAllPlugins( )
        {
            foreach ( IPlugin plugin in _plugins )
            {
                plugin.Run( );
            }
        }
    }
}
