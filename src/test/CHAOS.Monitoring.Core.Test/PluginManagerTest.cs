using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Test
{
    [TestFixture]
    public class PluginManagerTest
    {
        [Test]
        public void Should_Initilize_A_Plugin( )
        {
            PluginManager pluginManager = new PluginManager( );

            pluginManager.LoadPlugin("127.0.0.1" );
        }

        [Test]
        public void Should_Run_All_Plugins( )
        {
            PluginManager pluginManager = new PluginManager( );

            pluginManager.LoadPlugin("127.0.0.1" );

            pluginManager.RunAllPlugins( );
        }
    }
}
