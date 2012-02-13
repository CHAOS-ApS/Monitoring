using System;
using System.Collections.Generic;
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
        public void Should_Run_Trigger_And_Create_And_Run_Example_Plugin( )
        {
            Trigger test = new Trigger();

            test.AddPlugin("Example","Example: Run Method");

            test.TriggerActivatedEvent += (object sender, PluginResultsArgs args) =>
                                              {
                                                  foreach (IPluginResult result in args.GetResults())
                                                  {
                                                      Assert.AreEqual("Example: Run Method",result.ToString());
                                                  }
                                              };
            test.InitilizeTrigger("10");
            Thread.Sleep( 1000 );
        }
    }

}
