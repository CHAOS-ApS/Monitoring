using System;
using System.Collections.Generic;
using CHAOS.Monitoring.Trigger.TimeTrigger;

namespace CHAOS.Monitoring.Core
{
    public class TriggerManager
    {
        private List<Trigger.ITrigger> _triggers = new List<Trigger.ITrigger>( );

        public Trigger.ITrigger GetTrigger( int index )
        {
            return _triggers[ index ];
        }

        /// <summary>
        /// Used to create a trigger
        /// </summary>
        public void CreateTrigger( DateTime dateTime )
        {
            _triggers.Add( new TimeTrigger( dateTime ) );
        }

        public void RemoveTrigger( int index )
        {
            _triggers.RemoveAt( index );
        }
    }
}
