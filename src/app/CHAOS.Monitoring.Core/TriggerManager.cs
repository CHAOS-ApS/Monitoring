using System;
using System.Collections.Generic;

namespace CHAOS.Monitoring.Core
{
    public class TriggerManager
    {
        private List<Trigger.Trigger> _triggers = new List<Trigger.Trigger>( );

        public Trigger.Trigger GetTrigger( int index )
        {
            return _triggers[ index ];
        }

        /// <summary>
        /// Used to create a trigger
        /// </summary>
        public void CreateTrigger( )
        {
            _triggers.Add( new Trigger.Trigger( ) );
        }

        public void InitilizeTrigger(int index, string parameters)
        {
            _triggers[index].InitilizeTrigger(parameters);
        }

        public void RemoveTrigger( int index )
        {
            _triggers.RemoveAt( index );
        }
    }
}
