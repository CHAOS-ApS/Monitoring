using System;
using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
{
    public delegate void TriggerActivatedEventHandler( object sender, PluginResultsArgs args );

    public class Trigger
    {
        public event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        private Timer _runTimer;
        private List<IPlugin> _plugins = new List<IPlugin>( );

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
        public void RunPlugins( object sender )
        {
            PluginResultsArgs resultsArgs = new PluginResultsArgs( );

            foreach ( IPlugin plugin in _plugins )
            {
                resultsArgs.SaveResult( plugin.Run( ) );
            }

            TriggerActivatedEvent( this, resultsArgs );
        }

        public void InitilizeTrigger( string interval )
        {
            _runTimer = new Timer( RunPlugins, this, 0, Convert.ToInt32( interval ) );
        }
    }
}
