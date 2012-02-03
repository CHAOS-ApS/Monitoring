using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Core.Standard.Test;
using NUnit.Framework;

namespace CHAOS.Monitoring.Plugin.Ping.Test
{
    [TestFixture]
    public class PingTest : TestBase
    {
        [Test]
        public void Should_Ping_An_IP( )
        {
            Ping ping = new Ping( "127.0.0.1" );

            Assert.GreaterOrEqual( 0, Convert.ToInt64( ping.Run( ) ) );
        }

        [Test, ExpectedException( typeof( TimeoutException ) )]
        public void Should_Throw_TimeoutException_If_IP_Is_Unreachable( )
        {
            Ping ping = new Ping( "137.0.0.0" );
            ping.Run( );
        }

        [Test]
        public void Should_Return_PingTime_From_Pinging_IP( )
        {
            Ping ping = new Ping( "www.geckon.com" );

            Assert.Greater( Convert.ToInt64( ping.Run( )), 0  );
        }
    }
}
