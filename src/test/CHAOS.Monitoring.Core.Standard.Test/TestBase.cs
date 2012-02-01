﻿using CHAOS.Monitoring.Plugin.Ping;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TestBase
    {
        public Ping Ping { get; set; }

        [SetUp]
        public void SetUp()
        {
            Ping = new Ping( "127.0.0.1" );
            //Ping.ID = "1";
            //Ping.Name = "Ping";
            //Ping.PluginTypeID = "1";

        }
    }
}
