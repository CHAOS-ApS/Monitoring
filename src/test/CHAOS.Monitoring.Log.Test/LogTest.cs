using System;
using System.Threading;
using CHAOS.Monitoring.Core;
using CHAOS.Monitoring.Plugin;
using NUnit.Framework;

namespace CHAOS.Monitoring.Log.Test
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void Should_Update_Plugins_Log_And_Then_Read_It()
        {
            using( PluginManager pluginManager = new PluginManager( ) )
            {
                pluginManager.LoadPlugin( "www.flashback.org" );

                pluginManager.RunAllPlugins( 5, 500 );

                Thread.Sleep( 2500 );

                foreach ( String message in pluginManager.GetPluginManagerLog( ).GetLog( ) )
                    Console.WriteLine( message );

                foreach ( IPlugin plugin in pluginManager.GetPluginList( ) )
                {
                    foreach ( String message in plugin.GetLog( ).GetLog( ) )
                    {
                        Console.WriteLine( message );
                    }
                }

                pluginManager.Dispose();
            }

            
        }
    }
}
