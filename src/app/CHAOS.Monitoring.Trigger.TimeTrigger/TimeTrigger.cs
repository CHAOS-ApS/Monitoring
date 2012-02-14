using System;
using System.Threading;

namespace CHAOS.Monitoring.Trigger.TimeTrigger
{
    /// <summary>
    /// A trigger that starts a task at a specific date and time.
    /// </summary>
    public class TimeTrigger: Trigger
    {
        public TimeTrigger(DateTime dateTime)
        {
            _triggerActivationDateTime = dateTime;
            RunTimer = new Timer( RunPlugins, null, dateTime.Subtract( DateTime.Now ), new TimeSpan( -1 ) );
        }

        private DateTime _triggerActivationDateTime;
    }
}
