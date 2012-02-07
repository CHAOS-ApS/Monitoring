using System;
using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
{
    public class Trigger
    {
        public event TriggerActivatedEventHandler TriggerActivated;

        public Trigger( string interval, bool status )
        {
            _runTimer = new Timer( TriggerActivated(), null, 0, Convert.ToInt32( interval ) );
            _isActive = status;
        }

        private bool _isActive;
        private Timer _runTimer;
        private List<IPlugin> _plugins = new List<IPlugin>( );
   
        public IPlugin GetPlugin( int index )
        {
            return _plugins[ index ];
        }

        private void TriggerActivatedEventHandler( object parameter )
        {
            if ( _isActive )
                RunAllPlugins( );
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
        /// Run all plugins once
        /// </summary>
        public void RunAllPlugins( )
        {
            foreach ( IPlugin plugin in _plugins )
            {
                plugin.Run( );
            }
        }

        public void StartTrigger( )
        {
            _isActive = true;
        }

        public void StopTrigger( )
        {
            _isActive = false;
        }
    }

    public delegate void TriggerActivatedEventHandler(object sender, TriggerActivatedEventHandlerArgs args);
}
