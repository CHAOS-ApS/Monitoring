using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Factory.PluginFactory;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
{
    public abstract class Trigger: ITrigger
    {
        public event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        protected Timer RunTimer;
        protected List<IPlugin> Plugins = new List<IPlugin>( );

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
