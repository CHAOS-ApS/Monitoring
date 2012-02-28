using System;
using CHAOS.Monitoring.Plugin;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class PluginLoaderTest: TestBase
    {
        [Test]
        public void Should_Load_One_Plugin()
        {
            
            pluginLoader.Add("Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll");
            Assert.AreEqual(1, pluginLoader.Count);
        }

        [Test]
        public void Should_Load_Multiple_Plugins( )
        {
            var pluginLoader = new PluginLoader( );
            pluginLoader.Add( "Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
            pluginLoader.Add( "Example", "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Example.dll" );
            
            Assert.AreEqual( 2, pluginLoader.Count );
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Argument_ArgumentException_Because_An_Item_With_Same_Key_Has_Already_Been_Added( )
        {
            var pluginLoader = new PluginLoader( );
            pluginLoader.Add( "Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
            pluginLoader.Add( "Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
        }

        [Test]
        public void Should_Create_Instance_Based_On_Loaded_Assembly()
        {
            var pluginLoader = new PluginLoader( );

            pluginLoader.Add( "Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );

            IPlugin plugin = pluginLoader.GetPlugin( "Ping","CHAOS.Monitoring.Plugin.Ping","Ping");

            Assert.IsNotNull( plugin );
        }
    }
}
