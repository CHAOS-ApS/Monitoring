using System;
using System.IO;
using CHAOS.Monitoring.Plugin;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class PluginLoaderTest : TestBase
    {

        [Test]
        public void Should_Load_One_Plugin( )
        {
            pluginLoader.Add( 1, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
            Assert.GreaterOrEqual(pluginLoader.Count,1 );
        }

        [Test]
        public void Should_Load_Multiple_Plugins( )
        {
            pluginLoader.Add( 2, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Example.dll" );
            pluginLoader.Add( 3, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );

            Assert.Greater( pluginLoader.Count,2 );
        }

     
        [Test, ExpectedException( typeof( ArgumentException ) )]
        public void Should_Throw_ArgumentException_Because_An_Item_With_Same_Key_Has_Already_Been_Added( )
        {
            pluginLoader.Add( 4, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
            pluginLoader.Add( 4, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
        }

        [Test]
        public void Should_Create_Instance_Based_On_Loaded_Assembly( )
        {
            pluginLoader.Add( 5, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
            IPlugin plugin = pluginLoader.GetPlugin( 5, "CHAOS.Monitoring.Plugin.Ping", "Ping" );

            Assert.IsNotNull( plugin );
        }

        [Test, ExpectedException( typeof( FileNotFoundException ) )]
        public void Should_Throw_FileNotFoundException_Because_Assembly_Does_Not_Exists( )
        {
            pluginLoader.Add( 6, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.NotExisting.dll" );
        }
    }
}
