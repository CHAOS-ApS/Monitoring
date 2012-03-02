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
        public void Should_Load_Assemblies( )
        {
            PluginLoader.LoadAssemblies( "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\" );
     
            Assert.GreaterOrEqual( PluginLoader.Count,2 );
        }

        [Test, ExpectedException( typeof( ArgumentException ) )]
        public void Should_Throw_ArgumentException_Because_An_Item_With_Same_Key_Has_Already_Been_Added( )
        {
            PluginLoader.Add( "CHAOS.Monitoring.Plugin.Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
            PluginLoader.Add( "CHAOS.Monitoring.Plugin.Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
        }

        [Test]
        public void Should_Create_Instance_Based_On_Loaded_Assembly( )
        {
            PluginLoader.LoadAssemblies( "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\" );
            IPlugin plugin = PluginLoader.GetPlugin( "CHAOS.Monitoring.Plugin.Ping", "Ping" );

            Assert.IsNotNull( plugin );
        }

        [Test, ExpectedException( typeof( FileNotFoundException ) )]
        public void Should_Throw_FileNotFoundException_Because_Assembly_Does_Not_Exists( )
        {
            PluginLoader.Add( "CHAOS.Monitoring.Plugin.Ping", "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.NotExistingPlugin.dll" );
        }
         
    }
}
