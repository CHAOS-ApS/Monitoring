using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Core
{
    public class PluginManager : IDisposable
    {
        private List<IPlugin> _plugins = new List<IPlugin>( );
      
        public List<IPlugin> GetPluginList( )
        {
            return _plugins;
        }


        public void LoadPlugin( string parameters )
        {
            _plugins.Add( Factory.Factory.CreatePlugin( parameters ) );
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

        /// <summary>
        /// Run all plugins for a specified amount of times
        /// </summary>
        /// <param name="runTimes">Amount of times to run plugins</param>
        public void RunAllPlugins( int runTimes )
        {
            foreach ( IPlugin plugin in _plugins )
            {
                for ( int i = 0; i < runTimes; i++ )
                    plugin.Run( );
            }
        }

        private Timer runTimer;

        /// <summary>
        /// Run all plugins for a specified amount of times and with a specified interval
        /// </summary>
        /// <param name="timesToRun">Amount of times to run plugins</param>
        /// <param name="interval">The interval in Milliseconds between each run of all plugins </param>
        public void RunAllPlugins( int timesToRun, int interval )
        {
            runTimer = new Timer( IntervalTimerElapsed, timesToRun, 0, 500 );
        }


        private void IntervalTimerElapsed( object state )
        {
            int enemiesOf = ( int ) state;

            foreach ( IPlugin plugin in _plugins )
            {
                plugin.Run( );
            }
        }

        public void Dispose()
        {
            runTimer.Dispose();
        }
    }
}
