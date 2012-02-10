using CHAOS.Monitoring.Plugin.Ping;
using NUnit.Framework;

namespace CHAOS.Monitoring.Core.Standard.Test
{
    [TestFixture]
    public class TestBase
    {
        public Ping Ping { get; set; }

        protected TriggerManager TriggerManager { get; set; }

        [SetUp]
        public void SetUp( )
        {
            Ping = new Ping( "127.0.0.1" );

            //starts the trigger manager which controlls my triggers
            TriggerManager = new TriggerManager( );

            //create 3 default triggers
            TriggerManager.CreateTrigger( "500", true );
            TriggerManager.CreateTrigger( "1000", true );
            TriggerManager.CreateTrigger( "2000", true );
        }
    }
}
