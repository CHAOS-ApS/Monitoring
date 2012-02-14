﻿using System;
using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
{
    public abstract class Trigger
    {
        public event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        protected Timer _runTimer;
        protected List<IPlugin> _plugins = new List<IPlugin>( );

        public IPlugin GetPlugin( int index )
        {
            return _plugins[ index ];
        }

        /// <summary>
        /// Adds a plugin to being activated by this trigger
        /// </summary>
        /// <param name="pluginType">Which type of plugin</param>
        /// <param name="parameters">The parameters for the plugin</param>
        public void AddPlugin( string pluginType, string parameters )
        {
            _plugins.Add( Factory.PluginFactory.CreatePlugin( pluginType, parameters ) );
        }

        /// <summary>
        /// Run all plugins that has been added to the plugin list
        /// </summary>
        /// <param name="sender"></param>
        protected void RunPlugins( object sender )
        {
            PluginResultsArgs resultsArgs = new PluginResultsArgs( );

            foreach ( IPlugin plugin in _plugins )
            {
                resultsArgs.SaveResult( plugin.Run( ) );
            }

            TriggerActivatedEvent( this, resultsArgs );
        }
    }
}
