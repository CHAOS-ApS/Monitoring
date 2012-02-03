using System.Threading;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Test
{
    [TestFixture]
    public class PluginManagerTest
    {
        [Test]
        public void Should_Create_A_Plugin( )
        {
            PluginManager pluginManager = new PluginManager( );

            pluginManager.LoadPlugin( "Ping","127.0.0.1" );
        }

        [Test]
        public void Should_Create_A_Plugin_And_Run_All_Plugins( )
        {
            PluginManager pluginManager = new PluginManager( );

            pluginManager.LoadPlugin( "Ping","127.0.0.1" );

            pluginManager.RunAllPlugins( );
        }

        [Test]
        public void Should_Create_A_Plugin_And__Run_All_Plugins_With_Fixed_Interval( )
        {
            using ( PluginManager pluginManager = new PluginManager( ) )
            {
                pluginManager.LoadPlugin( "Pingj","www.flashback.org" );

                pluginManager.RunAllPlugins( 5, 500 );

                Thread.Sleep( 2500 );

                pluginManager.Dispose( );
            }
        }
    }
}
