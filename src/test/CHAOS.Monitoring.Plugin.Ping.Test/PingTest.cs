using System;
using CHAOS.Monitoring.Core.Standard.Test;
using NUnit.Framework;

namespace CHAOS.Monitoring.Plugin.Ping.Test
{
    [TestFixture]
    public class PingTest
    {
        [Test]
        public void Should_Ping_An_IP( )
        {
            Ping ping = new Ping(1, 1, "127.0.0.1");
            Assert.GreaterOrEqual( 0, ((PingResult) ping.Run() ).RoundtripTime );
        }

        [Test, ExpectedException( typeof( TimeoutException ) )]
        public void Should_Throw_TimeoutException_If_IP_Is_Unreachable( )
        {
            Ping ping = new Ping(1,1, "137.0.0.0" );
            ping.Run( );
        }
    }
}
