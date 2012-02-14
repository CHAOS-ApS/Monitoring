using System;
using System.Threading;
using CHAOS.Monitoring.Plugin;
using NUnit.Framework;

namespace CHAOS.Monitoring.Trigger.Test
{
    [TestFixture]
    public class TriggerTest
    {
        //[Test]
        //public void Should_Run_Trigger_And_Update_Trigger_Sender( )
        //{
        //    Trigger test = new Trigger( "2000" );
        //    test.AddPlugin( "Ping", "www.google.se" );
        //    Thread.Sleep( 5000 );
        //    Assert.NotNull( test.Sender );
        //}

        [Test]
        public void Should_Test_Trigger_Interval_And_That_Trigger_Event_Is_Runned( )
        {
            ITrigger test = new TimeTrigger.TimeTrigger(DateTime.Now.AddSeconds( 1 ) );

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
    }

}
