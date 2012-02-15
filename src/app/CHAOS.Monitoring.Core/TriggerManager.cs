using System;
using System.Collections.Generic;

namespace CHAOS.Monitoring.Core
{
    public class TriggerManager
    {
        private List<Trigger.Standard.Trigger> _triggers = new List<Trigger.Standard.Trigger>( );

        public Trigger.Standard.Trigger GetTrigger( int index )
        {
            return _triggers[ index ];
        }

        /// <summary>
        /// Used to create a trigger
        /// </summary>
        public void CreateTrigger( DateTime dateTime, int repetition )
        {
            _triggers.Add( new Trigger.Standard.Trigger( dateTime, repetition ) );
        }

        public void RemoveTrigger( int index )
        {
            _triggers.RemoveAt( index );
        }
    }
}
