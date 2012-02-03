using System;

namespace CHAOS.Monitoring.Plugin.Example
{
    public class Example : IPlugin
    {
        public Example(String parameters)
        {

        }

        public string Run( )
        {
            return ( "" );
        }

        private Log.Log _log = new Log.Log( );

        public Log.Log GetLog( )
        {
            return _log;
        }
    }
}
