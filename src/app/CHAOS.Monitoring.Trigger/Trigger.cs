using System;
using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Plugin;
using CHAOS.Monitoring.Plugin.Standard;

namespace CHAOS.Monitoring.Trigger
{
    public abstract class Trigger: ITrigger
    {
        public event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        protected Timer RunTimer;
        protected DateTime TriggerActivationDateTime;
        protected List<IPlugin> Plugins = new List<IPlugin>( );

        public Trigger(DateTime dateTime, int interval)
        {
            TriggerActivationDateTime = dateTime;
            RunTimer = new Timer( RunPlugins, null, dateTime.Subtract( DateTime.Now ), new TimeSpan( interval) );
        }

        public IPlugin GetPlugin( int index )
        {
            return Plugins[ index ];
        }

        public void AddPlugin( string pluginType, string parameters )
        {
            Plugins.Add( PluginFactory.CreatePlugin( pluginType, parameters ) );
        }

        protected void RunPlugins( object sender )
        {
            PluginResultsArgs resultsArgs = new PluginResultsArgs( );

            foreach ( IPlugin plugin in Plugins )
            {
                resultsArgs.SaveResult( plugin.Run( ) );
            }

            TriggerActivatedEvent( this, resultsArgs );
        }
    }
}
