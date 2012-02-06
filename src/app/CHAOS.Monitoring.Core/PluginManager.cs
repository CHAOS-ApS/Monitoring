using System;
using System.Collections.Generic;
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

        public void LoadPlugin( string pluginType, string parameters )
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

        /// <summary>
        /// Run all plugins for a specified amount of times using thread sleep
        /// </summary>
        /// <param name="timesToRun">Amount of times to run plugins</param>
        /// <param name="interval">The interval in Milliseconds between each run of all plugins </param>
        public void RunAllPlugins( int timesToRun, int interval )
        {
            foreach ( IPlugin plugin in _plugins )
            {
                for ( int i = 0; i < timesToRun; i++ )
                {
                    plugin.Run( );
                    Thread.Sleep( interval );
                }
            }
        }

        /// <summary>
        /// Run all plugins for a specified amount of times using timers
        /// </summary>
        /// <param name="timesToRun">Amount of times to run plugins</param>
        /// <param name="interval">The interval in Milliseconds between each run of all plugins </param>
        /// <param name="isBlocking">True if you want to use another method with equal funcitonality but that uses thread sleep insted </param>
        public void RunAllPlugins( int timesToRun, int interval, bool isBlocking )
        {
            if ( isBlocking )
                RunAllPlugins( timesToRun, interval );

            Timer runTimer = new Timer( IntervalTimerEventHandler, timesToRun, 0, interval );

            runTimer.Dispose();
        }

        private void IntervalTimerEventHandler( object timesToRun )
        {
            foreach ( IPlugin plugin in _plugins )
            {
                for ( int i = 0; i < (int)timesToRun; i++ )
                {
                    plugin.Run( );
                    Console.WriteLine("intervalTimeEventHandler was runned... {0}",i);
                }
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
