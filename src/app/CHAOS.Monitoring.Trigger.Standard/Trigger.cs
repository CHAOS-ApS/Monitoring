using System;
using System.Collections.Generic;
using System.Threading;
using CHAOS.Monitoring.Plugin;
using CHAOS.Monitoring.Plugin.Standard;

namespace CHAOS.Monitoring.Trigger.Standard
{
    /// <summary>
    /// A trigger is activated once or with repetition after a specifed date & time.
    /// </summary>
    public class Trigger
    {
        public event TriggerActivatedEventHandler TriggerActivatedEvent = delegate { };

        private Timer _timer;
        private DateTime _startDateTime;
        private List<IPlugin> _plugins = new List<IPlugin>( );
        private bool _enabled;
        private int _repetition;

        /// <summary>
        /// Initilizes the trigger with it's start date & time and also the repetition time of the trigger that determines if the
        /// trigger is repeating or not.
        /// </summary>
        /// <param name="startDateTime">The date and time when the trigger is activated. Set to DateTime.Now for instant activation</param>
        /// <param name="repetition">The repetition in milliseconds between trigger activation. (-1) for no repetition.</param>
        public Trigger( DateTime startDateTime, int repetition )
        {
            _startDateTime = startDateTime;
            _repetition = repetition;
        }

        public void Start( )
        {
            TimeSpan waitTime = _startDateTime.Subtract(DateTime.Now);
            if (waitTime.TotalMilliseconds < -1)
                waitTime = new TimeSpan(0);

            _timer = new Timer(RunPlugins, null, waitTime, new TimeSpan(_repetition));
            _enabled = true;
        }

        public void Stop( )
        {
            _enabled = false;
            throw new NotImplementedException();
        }

        public bool Status()
        {
            return _enabled;
        }

        public IPlugin GetPlugin( int index )
        {
            return _plugins[ index ];
        }

        public void AddPlugin( string pluginType, string parameters )
        {
            _plugins.Add( PluginFactory.CreatePlugin( pluginType, parameters ) );
        }

        /// <summary>
        /// If the trigger is enabled then all plugins in the plugin list are ran
        /// </summary>
        /// <param name="args">A parameter that is never used to please the System.Threading.Timer class that demands method with object parameter </param>
        private void RunPlugins( object args )
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
