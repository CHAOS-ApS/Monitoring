using System;
using System.Threading;

namespace CHAOS.Monitoring.Trigger.RepeatingTrigger
{
    public class RepeatingTrigger: Trigger
    {
        public RepeatingTrigger(DateTime dateTime, int interval)
        {
            TriggerActivationDateTime = dateTime;
            RunTimer = new Timer( RunPlugins, null, dateTime.Subtract( DateTime.Now ), new TimeSpan( interval) );
        }
    }
}
