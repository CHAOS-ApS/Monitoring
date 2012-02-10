using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;

namespace CHAOS.Monitoring.Trigger.Test
{
    [TestFixture]
    public class TriggerTest
    {
        [Test]
        public void Should_Run_Trigger_And_Update_Trigger_Sender( )
        {
            Trigger test = new Trigger( "2000", true );
            test.AddPlugin( "Ping", "www.google.se" );
            Thread.Sleep( 5000 );
            Assert.NotNull( test.Sender );
        }
    }

}
