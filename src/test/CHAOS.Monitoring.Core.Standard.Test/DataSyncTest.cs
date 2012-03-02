using System.Linq;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class DataSyncTest:TestBase
    {
        [Test]
        public void Should_Create_Trigger_Objects_Based_On_Data_From_Database()
        {
            Assert.IsNotEmpty(DataSync.SyncTriggerObjects());
        }

        public void Should_Create_Plugin_Objects_Based_On_Data_From_Database( )
        {
            Assert.IsNotEmpty( DataSync.SyncPluginObjects( "C:\\Users\\Stoffe\\Desktop\\Repo\\Monitoring\\PluginLoadTest\\" ) );
        }
    }
}
