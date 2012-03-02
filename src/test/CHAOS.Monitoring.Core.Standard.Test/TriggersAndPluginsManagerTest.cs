
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TriggersAndPluginsManagerTest
    {
        [Test]
        public void Should_Add_Plugins_To_Triggers()
        {
            var triggersAndPluginsManager = new TriggersAndPluginsManager( );

            triggersAndPluginsManager.SyncAllData( "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\" );

            Assert.IsNotEmpty(triggersAndPluginsManager.GetTrigger(1).GetAllPlugins());
        }
    }
}
