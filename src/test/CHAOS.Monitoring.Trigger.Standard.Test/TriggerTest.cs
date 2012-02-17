using System;
using System.Linq;
using CHAOS.Monitoring.Core.Standard.Test;
using CHAOS.Monitoring.Plugin.Example;
using NUnit.Framework;

namespace CHAOS.Monitoring.Trigger.Standard.Test
{
    [TestFixture]
    public class TriggerTest
    {
        [Test]
        public void Should_Create_Trigger_Without_Repetition( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, -1 );

            Assert.IsNotNull( testTrigger );
        }

        [Test]
        public void Should_Create_Trigger_Without_Repetition_And_Start_Time_From_The_Past( )
        {
            Trigger testTrigger = new Trigger( new DateTime( 0001, 01, 01, 00, 00, 00 ), -1 );

            testTrigger.Start( );

            Assert.IsTrue( testTrigger.GetStatus( ) );
        }

        [Test]
        public void Should_Create_Trigger_With_Repetition( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, 100 );

            Assert.IsNotNull( testTrigger );
        }

        [Test]
        public void Should_Create_One_Plugin( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, -1 );

            testTrigger.AddPlugin( "Example", "Example plugin" );

            Assert.IsNotNull( testTrigger.GetPlugin( 0 ) );
        }

        [Test]
        public void Should_Run_One_Plugin( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, -1 );

            testTrigger.AddPlugin( "Example", "Example plugin" );

            bool fd = false;

            testTrigger.TriggerActivatedEvent +=
                ( sender, args ) => fd = "Example plugin" == ( ( ExampleResult )args.GetResults( ).ElementAt( 0 ) ).ExampleText;

            testTrigger.Start( );
            Timing.WaitUntil( ( ) => fd, 10000 );

            Assert.IsTrue( fd );
        }

        [Test]
        public void Should_Create_Multiple_Plugins( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, -1 );

            testTrigger.AddPlugin( "Example", "Example plugin" );
            testTrigger.AddPlugin( "Ping", "127.0.0.1" );
            testTrigger.AddPlugin( "Example", "Example plugin2" );
            testTrigger.AddPlugin( "Ping", "127.0.0.1" );

            Assert.AreEqual( 4, testTrigger.GetAllPlugins( ).Count( ) );
        }

        [Test]
        public void Should_Run_Multiple_Plugins( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, -1 );

            testTrigger.AddPlugin( "Example", "Example plugin" );
            testTrigger.AddPlugin( "Ping", "127.0.0.1" );
            testTrigger.AddPlugin( "Example", "Example plugin2" );
            testTrigger.AddPlugin( "Ping", "127.0.0.1" );

            bool fd = false;
            testTrigger.TriggerActivatedEvent +=
                ( sender, args ) => fd = 4 == args.GetResults( ).Count( );

            testTrigger.Start( );
            Timing.WaitUntil( ( ) => fd, 10000 );

            Assert.IsTrue( fd );
        }

        [Test]
        public void Should_Stop_Trigger()
        {
            Trigger testTrigger = new Trigger(DateTime.Now, 10);

            testTrigger.Start();
            testTrigger.Stop();
            Assert.IsFalse(testTrigger.GetStatus());
        }

        [Test]
        public void Should_Restart_Stopped_Trigger()
        {
            Trigger testTrigger = new Trigger( DateTime.Now, 10 );

            testTrigger.Start( );
            testTrigger.Stop( );
            testTrigger.Start( );
            Assert.IsTrue( testTrigger.GetStatus( ) );
        }

        [Test]
        public void Should_Stop_A_Stopped_Trigger( )
        {
            Trigger testTrigger = new Trigger(DateTime.Now, 10);

            testTrigger.Start();
            testTrigger.Stop();
            testTrigger.Stop();
            Assert.IsFalse(testTrigger.GetStatus());
        }

    }
}