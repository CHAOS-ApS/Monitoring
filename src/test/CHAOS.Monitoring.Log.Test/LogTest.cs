using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Core;
using CHAOS.Monitoring.Factory.Ping;
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
            PluginManager pluginManager = new PluginManager( );

            pluginManager.LoadPlugin( new PingFactory( ), "www.geckon.com" );

            pluginManager.RunAllPlugins( );

            foreach (IPlugin plugin in pluginManager.GetPluginList())
            {
                Console.WriteLine(plugin.GetLog().GetLog().First());
            }
        }
    }
}
