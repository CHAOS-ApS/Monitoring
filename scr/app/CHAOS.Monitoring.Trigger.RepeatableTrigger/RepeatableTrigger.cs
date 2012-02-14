using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CHAOS.Monitoring.Factory;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger.RepeatableTrigger
{
   
    public class RepeatableTrigger: ITrigger
    {
        public event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        private DateTime _DateTimeWhenTriggerIsActive;
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
            _plugins.Add( PluginFactory.CreatePlugin( pluginType, parameters ) );
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

        /// <summary>
        /// Creates a trigger with a specified delay that then runs endlessly
        /// </summary>
        /// <param name="interval">The interval in ms for the trigger</param>
        /// <param name="dateTime">The time when the trigger shall be activated</param>
        public void InitilizeTrigger( string interval, DateTime dateTime )
        {
            _runTimer = new Timer( RunPlugins, this, dateTime.Subtract( DateTime.Now ), new TimeSpan( Convert.ToInt32( interval )) );
        }
    }
}