using System;
using System.Collections.Generic;
using CHAOS.Monitoring.Plugin.Ping;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TestBase
    {
        public Ping Ping { get; set; }

        [SetUp]
        public void SetUp( )
        {
            Ping = new Ping(1,1,"127.0.0.1");
        }
    }
}
