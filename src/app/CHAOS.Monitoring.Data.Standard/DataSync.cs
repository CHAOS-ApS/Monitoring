using System.Collections.Generic;
using System;
using CHAOS.Monitoring.Core.Standard;

namespace CHAOS.Monitoring.Data.Standard
{
    public class DataSync
    {
        public List<Trigger> GetTriggerObjectsFromDatabase( this ObjectKeeper objectkeeper )
        {
            using ( var db = new MonitorLibraryEntities( ) )
            {
                var triggers = new List<Trigger>( db.Triggers_Get( ) );

                foreach ( var trigger in triggers )
                {
                    objectkeeper.CreateTrigger(trigger.ID, trigger.StartDateTime, trigger.Repetition );
                }
                return ( triggers );
            }
        }

        //extension method

        public List<Plugin> GetPluginObjectsFromDatabase( ObjectKeeper objectKeeper )
        {
            using ( var db = new MonitorLibraryEntities( ) )
            {
                var plugins = new List<Plugin>( db.Plugins_Get( ) );

                foreach ( var plugin in plugins )
                {
                    objectKeeper.CreatePlugin( Convert.ToString( plugin.PluginType ), plugin.HostAdress );
                }
                return ( plugins );
            }
        }
    }
}