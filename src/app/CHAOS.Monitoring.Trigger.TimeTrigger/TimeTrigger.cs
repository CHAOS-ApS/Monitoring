using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CHAOS.Monitoring.Trigger.TimeTrigger
{
    /// <summary>
    /// A trigger that starts a task at a specific date and time.
    /// </summary>

    public class TimeTrigger: Trigger.Trigger
    {
        /// <summary>
        /// Creates a trigger that is activated once at a specific time
        /// </summary>
        /// <param name="dateTime"></param>
        public void InitilizeTrigger( DateTime dateTime )
        {
            _runTimer = new Timer( RunPlugins, null, dateTime.Subtract( DateTime.Now ), new TimeSpan( -1 ) );
        }
    }
}
