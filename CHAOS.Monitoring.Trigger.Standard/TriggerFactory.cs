using System;

namespace CHAOS.Monitoring.Trigger.Standard
{
    class TriggerFactory
    {
        public static ITrigger CreateTrigger( string triggerType, DateTime dateTime, int interval )
        {
            switch ( triggerType )
            {
                case "TimeTrigger":
                    return new TimeTrigger.TimeTrigger( dateTime );
                case "RepeatingTrigger":
                     return new RepeatingTrigger.RepeatingTrigger( dateTime, interval );
            }
            throw new NotImplementedException( string.Format( "The plugin type: {0} does not exsist", triggerType ) );
        }
    }
}
