
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TriggersAndPluginsManagerTest:TestBase
    {
        [Test]
        public void Should_Add_Plugins_To_Triggers()
        {
            var triggersAndPluginsManager = new TriggersAndPluginsManager( );
            
            triggersAndPluginsManager.StartUpSync(pluginLoader);

            Assert.IsNotEmpty(triggersAndPluginsManager.GetTrigger(0).GetAllPlugins());
        }
    }
}
