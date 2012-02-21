using System;
using System.Collections.Generic;
using CHAOS.Monitoring.Plugin.Standard;

namespace CHAOS.Monitoring.Core.Standard
{
    public class ObjectKeeper
    {
        #region Trigger management

        private List<Trigger.Standard.Trigger> _triggers = new List<Trigger.Standard.Trigger>( );

        public void CreateTrigger( int id, DateTime dateTime, int repetition )
        {
            _triggers.Add( new Trigger.Standard.Trigger( id, dateTime, repetition ) );
        }

        public void DeleteTrigger( int index )
        {
            _triggers.RemoveAt( index );
        }

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

        public void CreatePlugin( string pluginType, string parameters )
        {
            _plugins.Add( PluginFactory.CreatePlugin( pluginType, parameters ) );
        }

        public void DeletePlugin( int index )
        {
            _plugins.RemoveAt( index );
        }

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