using System.Threading;
using CHAOS.Monitoring.Core.Standard.Test;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Test
{
    [TestFixture]
    public class TriggerManagerTest: TestBase
    {
        [Test]
        public void Should_Start_Running_Default_Triggers( )
        {
            TriggerManager.GetTrigger(0).AddPlugin( "Ping", "www.google.se" );
            TriggerManager.GetTrigger(1).AddPlugin( "Example", "www.google.se" );

            Thread.Sleep( 5000 );
        }
    }
}
