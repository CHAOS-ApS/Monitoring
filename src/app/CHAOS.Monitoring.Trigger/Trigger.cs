using System;
using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
{
    public delegate void TriggerActivatedEventHandler( object sender );

    public class Trigger
    {
        private event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        private void OnTriggerActivatedEvent( object sender )
        {
            if ( _isTriggerActive )
            {
                TriggerActivatedEvent(sender);
                _sender = sender;
            }
        }

        private void SomeLogMethod( object sender )
        {
            Console.WriteLine( "SomeLogMethod" );
        }

        private void SomeOtherMethod( object sender )
        {
            Console.WriteLine( "SomeDataSyncMethod" );
        }

        public Trigger( string interval, bool status )
        {
            TriggerActivatedEvent += SomeLogMethod;
            TriggerActivatedEvent += SomeOtherMethod;
            _runTimer = new Timer( OnTriggerActivatedEvent, this, 0, Convert.ToInt32( interval ) );
            _isTriggerActive = status;
        }

        private object _sender;
        public object Sender { get { return _sender; } }

        private Timer _runTimer;
        private bool _isTriggerActive;
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
            _isTriggerActive = true;
        }

        public void StopTrigger( )
        {
            _isTriggerActive = false;
        }
    }


}
