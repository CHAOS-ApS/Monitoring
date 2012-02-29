using System;
using System.Linq;
using CHAOS.Monitoring.Core.Standard.Test;
using CHAOS.Monitoring.Plugin.Example;
using CHAOS.Monitoring.Plugin.Ping;
using NUnit.Framework;

namespace CHAOS.Monitoring.Trigger.Standard.Test
{
    [TestFixture]
    public class TriggerTest
    {
        [Test]
        public void Should_Create_Trigger_Without_Repetition( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, -1 );
            
            Console.WriteLine(testTrigger.GetType().FullName);
            
            Assert.IsNotNull( testTrigger );
        }

        [Test]
        public void Should_Create_Trigger_Without_Repetition_And_Start_Time_From_The_Past( )
        {
            Trigger testTrigger = new Trigger( 1, new DateTime( 0001, 01, 01, 00, 00, 00 ), -1 );

            testTrigger.Start( );

            Assert.IsNotNull( testTrigger );
        }

        [Test, ExpectedException( typeof( ArgumentOutOfRangeException ) )]
        public void Should_Throw_Argument_Out_Of_Range_Exception_Because_Of_Wrong_Date( )
        {
            Trigger testTrigger = new Trigger( 1, new DateTime( 2012, 02, 35, 00, 00, 00 ), -1 );
        }

        [Test, ExpectedException( typeof( ArgumentOutOfRangeException ) )]
        public void Should_Throw_Argument_Out_Of_Range_Exception_Because_Of_Wrong_Time( )
        {
            Trigger testTrigger = new Trigger( 1, new DateTime( 2012, 02, 01, 25, 57, 61 ), -1 );
        }

        [Test]
        public void Should_Create_Trigger_With_Repetition( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, 100 );

            Assert.IsNotNull( testTrigger );
        }

        [Test, ExpectedException( typeof( ArgumentOutOfRangeException ) )]
        public void Should_Throw_Argument_Out_Of_Range_Exception_Because_Of_Wrong_Repetition( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, -50 );
            testTrigger.Start( );
        }

        [Test]
        public void Should_Create_One_Plugin( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, -1 );

            testTrigger.AddPlugin(new Example(1, 1, "Example plugin"));
                                                    
            Assert.IsNotNull( testTrigger.GetPlugin( 0 ) );
        }

        [Test]
        public void Should_Run_One_Plugin( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, -1 );

            testTrigger.AddPlugin( new Example( 1, 1, "Example plugin" ) );

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
            Trigger testTrigger = new Trigger( 1, DateTime.Now, -1 );

            testTrigger.AddPlugin( new Example( 1, 1, "Example plugin" ) );
            testTrigger.AddPlugin( new Ping( 1, 1, "127.0.0.1" ) );
            testTrigger.AddPlugin( new Example( 1, 1, "Example plugin2" ) );
            testTrigger.AddPlugin( new Ping( 1, 1, "127.0.0.1" ) );

            Assert.AreEqual( 4, testTrigger.GetAllPlugins( ).Count( ) );
        }

        [Test]
        public void Should_Run_Multiple_Plugins( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, -1 );

            testTrigger.AddPlugin( new Example( 1, 1, "Example plugin" ) );
            testTrigger.AddPlugin( new Ping( 1, 1, "127.0.0.1" ) );
            testTrigger.AddPlugin( new Example( 1, 1, "Example plugin2" ) );
            testTrigger.AddPlugin( new Ping( 1, 1, "127.0.0.1" ) );

            bool fd = false;
            testTrigger.TriggerActivatedEvent +=
                ( sender, args ) => fd = 4 == args.GetResults( ).Count( );

            testTrigger.Start( );
            Timing.WaitUntil( ( ) => fd, 10000 );

            Assert.IsTrue( fd );
        }

        [Test]
        public void Should_Stop_Trigger( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, 10 );

            testTrigger.Start( );
            Assert.IsTrue( testTrigger.Stop( ) );
        }

        [Test]
        public void Should_Restart_Stopped_Trigger( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, 10 );

            testTrigger.Start( );
            testTrigger.Stop( );
            Assert.IsTrue( testTrigger.Start( ) );
        }

        [Test]
        public void Should_Remove_Plugin( )
        {
            Trigger testTrigger = new Trigger( 1, DateTime.Now, 10 );


            testTrigger.AddPlugin( new Example( 1, 1, "Example plugin" ) );
            testTrigger.RemovePlugin( 0 );

            Assert.IsEmpty( testTrigger.GetAllPlugins( ) );
        }
    }
}