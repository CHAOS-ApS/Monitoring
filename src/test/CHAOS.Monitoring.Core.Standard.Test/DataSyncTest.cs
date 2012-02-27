using System.Linq;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class DataSyncTest
    {
        [Test]
        public void Should_Create_Trigger_Objects_Based_On_Data_From_Database()
        {
            Assert.IsNotEmpty(DataSync.SyncTriggerObjects());
        }

        public void Should_Create_Plugin_Objects_Based_On_Data_From_Database( )
        {
            Assert.IsNotEmpty( DataSync.SyncPluginObjects( ) );
        }
    }
}



//no references to plugins, only interfaces

//then work with assemblies to load .dll files from a folder

//this shall be done at the startup of the app

//maybe at runtime too if i get that far :)