using System;
using CHAOS.Monitoring.Trigger.DailyTrigger;
using CHAOS.Monitoring.Trigger.TimeTrigger;

namespace CHAOS.Monitoring.Factory.TriggerFactory
{
    class TriggerFactory
    {
        public static Trigger.ITrigger CreatePlugin( string triggerType, DateTime dateTime )
        {
            switch ( triggerType )
            {
                case "TimeTrigger":
                    return new TimeTrigger( dateTime );
                case "DailyTrigger":
                    return new DailyTrigger( dateTime );
            }
            throw new NotImplementedException( string.Format( "The plugin type: {0} does not exsist", triggerType ) );
        }
    }
}
