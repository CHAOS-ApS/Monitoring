using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TestBase
    {
        public PluginLoader pluginLoader = new PluginLoader( );
        public DataSync dataSync = new DataSync();
        [SetUp] 
        public void SetUp( )
        {
            pluginLoader.Add();.;
        }
    }
}
