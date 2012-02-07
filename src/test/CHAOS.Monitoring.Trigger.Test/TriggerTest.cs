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
        public void Should_Run_Trigger_Endlessly( )
        {
            Trigger test = new Trigger( "2000" );
            test.AddPlugin( "Ping", "www.google.se" );

            Thread.Sleep( 11000 );
        }
    }
}
