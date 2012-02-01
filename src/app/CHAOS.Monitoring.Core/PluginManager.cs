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
        private Log.Log _log = new Log.Log( );

        public List<IPlugin> GetPluginList()
        {
            return _plugins;
        }

        public Log.Log GetManagerLog()
        {
            return _log;
        }

        public void LoadPlugin( IFactory factory, string parameters )
        {
            _plugins.Add( factory.InitilizePlugin( parameters ) );
            _log.UpdateLog( String.Format( "The following plugin was loaded: {0}", _plugins.Last( ) ) );
        }

        public void UnloadPlugin( IPlugin plugin )
        {
            _plugins.RemoveAt( _plugins.IndexOf( plugin ) );
            _log.UpdateLog( String.Format( "The following plugin was unloaded: {0}", plugin ) );
        }

        public void UnloadAllPlugins( )
        {
            _plugins.Clear( );
            _log.UpdateLog( "All plugins was unloaded" );
        }

        public void RunAllPlugins( )
        {
            foreach ( IPlugin plugin in _plugins )
            {
                _log.UpdateLog( "Started running all plugins" );
                plugin.Run( );
            }
        }
    }
}
