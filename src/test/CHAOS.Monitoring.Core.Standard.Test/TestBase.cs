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

        protected ObjectKeeper TriggerManager { get; set; }

        [SetUp]
        public void SetUp( )
        {
            Ping = new Ping( "127.0.0.1" );

            //starts the trigger manager which controlls my triggers
            TriggerManager = new ObjectKeeper( );



        }

        public List<Trigger.Standard.Trigger> SimulateDatabase( )
        {
            List<Trigger.Standard.Trigger> data = new List<Trigger.Standard.Trigger>();

            data.Add( new Trigger.Standard.Trigger( 1, DateTime.Now, 100 ) );
            data.Add( new Trigger.Standard.Trigger( 1, DateTime.Now, 500 ) );
            data.Add( new Trigger.Standard.Trigger( 1, DateTime.Now, 250 ) );
            return data;
        }
    }
   
}
