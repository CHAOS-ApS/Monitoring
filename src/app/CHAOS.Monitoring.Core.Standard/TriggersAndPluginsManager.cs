using System;
using System.Collections.Generic;

namespace CHAOS.Monitoring.Core.Standard
{
    public class TriggersAndPluginsManager
    {
        public void SyncAllData( string assembliesLocation )
        {
            _triggers = DataSync.SyncTriggerObjects( );
            _plugins = DataSync.SyncPluginObjects( assembliesLocation );
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

        private List<Trigger.Standard.Trigger>  _triggers = new List<Trigger.Standard.Trigger>( );

        /// <summary>
        /// Returns a trigger that has the specified ID
        /// </summary>
        /// <param name="id">The ID</param>
        /// <returns>The trigger with the ID</returns>
        public Trigger.Standard.Trigger GetTrigger( int id )
        {
            int index = -1;

            for ( int i = 0; i < _triggers.Count; i++ )
            {
                if ( _triggers[ i ].Id == id )
                    index = i;
            }

            if ( index == -1 )
                throw new ArgumentException( );

            return _triggers[ index ];
        }

        public IEnumerable<Trigger.Standard.Trigger> GetAllTriggers( )
        {
            return _triggers;
        }

        #endregion

        #region Plugin management
        private List<Plugin.IPlugin> _plugins = new List<Plugin.IPlugin>( );


        /// <summary>
        /// Returns a plugin that has the specified ID
        /// </summary>
        /// <param name="id">The ID</param>
        /// <returns>The plugin with the ID</returns>
        public Plugin.IPlugin GetPlugin( int id )
        {
            int index = -1;

            for ( int i = 0; i < _plugins.Count; i++ )
            {
                if ( _plugins[ i ].Id == id )
                    index = i;
            }

            if ( index == -1 )
                throw new ArgumentException( );

            return _plugins[ index ];
        }

        public IEnumerable<Plugin.IPlugin> GetAllPlugis( )
        {
            return _plugins;
        }

        #endregion
    }
}