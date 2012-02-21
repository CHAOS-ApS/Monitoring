using System.Linq;
using CHAOS.Monitoring.Core.Standard;
using NUnit.Framework;

namespace CHAOS.Monitoring.Data.Standard.Test
{
    [TestFixture]
    public class DataSyncTest
    {
        [Test] public void Should_Create_Trigger_Objects_Based_On_Data_From_Database()
        {
            DataSync dataSync = new DataSync();
            ObjectKeeper keeper = new ObjectKeeper();
            dataSync.GetTriggerObjectsFromDatabase(keeper);

            Assert.IsNotEmpty(keeper.GetAllTriggers());
        }
    }
}
