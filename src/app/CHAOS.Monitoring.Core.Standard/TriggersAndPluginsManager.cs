using System.Collections.Generic;

namespace CHAOS.Monitoring.Core.Standard
{
    public class TriggersAndPluginsManager
    {
        public void StartUpSync( )
        {
            _triggers = DataSync.SyncTriggerObjects( );
            _plugins = DataSync.SyncPluginObjects( );
            AddPluginsToTriggers( );
        }

        private void AddPluginsToTriggers( )
        {
            foreach ( var plugin in _plugins )
            {
                GetTrigger( plugin.TriggerId ).AddPlugin( plugin );
            }
        }

        #region Trigger management

        private List<Trigger.Standard.Trigger> _triggers = new List<Trigger.Standard.Trigger>( );

        public Trigger.Standard.Trigger GetTrigger( int index )
        {
            return _triggers[ index ];
        }

        public IEnumerable<Trigger.Standard.Trigger> GetAllTriggers( )
        {
            return _triggers;
        }

        #endregion

        #region Plugin management
        private List<Plugin.IPlugin> _plugins = new List<Plugin.IPlugin>( );

        public Plugin.IPlugin GetPlugin( int index )
        {
            return _plugins[ index ];
        }

        public IEnumerable<Plugin.IPlugin> GetAllPlugis( )
        {
            return _plugins;
        }
        #endregion
    }
}