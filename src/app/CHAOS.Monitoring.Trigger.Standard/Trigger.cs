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

        /// <summary>
        /// The repetition in milliseconds between each trigger activation. Set to (1-) for no repetition.
        /// </summary>
        public int Repetition { get; set; }

        /// <summary>
        /// The start time of the trigger
        /// </summary>
        public DateTime StartDateTime { get; set; }
        
        /// <summary>
        /// The unique ID that each trigger has for easly paring Triggers with Plugins
        /// </summary>
        public int Id { get;set; }

        /// <summary>
        /// Initilizes the trigger with it's start date & time and also the repetition time of the trigger that determines if the
        /// trigger is repeating or not.
        /// </summary>
        /// <param name="id">The ID of the trigger used for identifying triggers </param>
        /// <param name="startDateTime">The date and time when the trigger is activated. (DateTime.Now) for instant activation</param>
        /// <param name="repetition">The repetition in milliseconds between trigger activation. (-1) for no repetition.</param>
        public Trigger( int id , DateTime startDateTime, int repetition )
        {
            _startDateTime = startDateTime;
            Repetition = repetition;
            Id = id;
        }

        public bool Start( )
        {
            TimeSpan waitTime = _startDateTime.Subtract( DateTime.Now );
            if ( waitTime.TotalMilliseconds < -1 )
                waitTime = new TimeSpan( 0 );

            _timer = new Timer( RunPlugins, null, waitTime, new TimeSpan( 0, 0, 0, 0, Repetition ) );
            return true;
        }

        public bool Stop( )
        {
            _timer.Dispose();
            return true;
        }

        public IPlugin GetPlugin( int index )
        {
            return _plugins[ index ];
        }

        public IEnumerable<IPlugin> GetAllPlugins( )
        {
            return _plugins;
        }

        public void AddPlugin( IPlugin plugin )
        {
            _plugins.Add( plugin );
        }

        public void RemovePlugin( int index )
        {
            _plugins.RemoveAt( index );
        }

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
