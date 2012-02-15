using System;
using System.Linq;
using System.Threading;
using CHAOS.Monitoring.Core.Standard.Test;
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
            testTrigger.Start();
            Assert.IsTrue(testTrigger.Status());
        }

        [Test]
        public void Shold_Create_Trigger_With_Repetition( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, 100 );
            Assert.IsNotNull( testTrigger );
        }

        [Test]
        public void Should_Create_One_Plugin( )
        {
            Trigger testTrigger = new Trigger( DateTime.Now, -1 );

            bool fd = false;

            testTrigger.AddPlugin( "Example", "Example plugin" );
            
            testTrigger.TriggerActivatedEvent +=
                (sender, args) => fd = "Example plugin" == args.GetResults().First().ToString() ;

            testTrigger.Start();
            Timing.WaitUntil( () => fd, 10000 );

            Assert.IsTrue( fd );
        }


        //test driven development


        /*
        
        Test_Trigger_Interval_And_That_Trigger_Event_Is_Runned( )
        {
            Trigger test = new Trigger((DateTime.Now.AddSeconds( 1 ) );

            test.AddPlugin("Example","Example: Run Method");

            test.TriggerActivatedEvent += (sender, args) =>
                                              {
                                                  foreach (IPluginResult result in args.GetResults())
                                                  {
                                                      Assert.AreEqual("Example: Run Method",result.ToString());
                                                  }
                                              };
            Thread.Sleep( 1000 );
        }


        [Test]
        public void Should_Test_Trigger_Activated_At_Specific_Time_And_That_Trigger_Event_Is_Runned( )
        {
            ITrigger test = new TimeTrigger.TimeTrigger( DateTime.Now.AddSeconds( 1 ) );

            test.AddPlugin( "Example", "Example: Run Method" );

            test.TriggerActivatedEvent += (sender, args) =>
            {
                foreach ( IPluginResult result in args.GetResults( ) )
                {
                    Assert.AreEqual( "Example: Run Method", result.ToString( ) );
                }
            };
            Thread.Sleep( 5000 );
        }
         * */
    }
}
