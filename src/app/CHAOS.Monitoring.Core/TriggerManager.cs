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
        /// <param name="parameters">Parameters for the trigger</param>
        /// <param name="isActiveOnStartup">True if the trigger is going to be ran instantly </param>
        public void CreateTrigger( string parameters, bool isActiveOnStartup )
        {
            _triggers.Add( new Trigger.Trigger( parameters, isActiveOnStartup ) );
        }

        /// <summary>
        /// Used to delete a trigger
        /// </summary>
        /// <param name="index">Idenfies the trigger by it's position</param>
        public void RemoveTrigger( int index )
        {
            _triggers.RemoveAt( index );
        }

        public void StartTrigger( int index )
        {
            _triggers[ index ].StartTrigger( );
        }

        public void StopTrigger( int index )
        {
            _triggers[ index ].StopTrigger( ); ;
        }
    }
}
