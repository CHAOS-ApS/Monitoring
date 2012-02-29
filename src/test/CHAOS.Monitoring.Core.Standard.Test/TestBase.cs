using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TestBase
    {
        public PluginLoader pluginLoader = new PluginLoader( );
        
        [SetUp] 
        public void SetUp( )
        {
            pluginLoader.Add( 0, "C:\\Users\\Stoffe\\Desktop\\Repo\\\\Monitoring\\PluginLoadTest\\CHAOS.Monitoring.Plugin.Ping.dll" );
        }
    }
}
