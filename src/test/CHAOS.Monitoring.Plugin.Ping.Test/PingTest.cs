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
        public void Should_Create_Instance_Of_Ping()
        {
            Ping ping = new Ping();

            Assert.GreaterOrEqual(0,ping.PingHost("127.0.0.1"));
        }

        [Test, ExpectedException(typeof(TimeoutException))]
        public void Should_Throw_TimeoutException_If_IP_Is_Unreachable()
        {
            Ping ping = new Ping();
            ping.PingHost("134.0.0.21");
        }

        [Test]
        public void Should_Return_PingTime_From_Pinging_Real_Site()
        {
            Ping ping = new Ping();

            Assert.Greater(ping.PingHost("www.geckon.com"), 0);
        }
    }
}
