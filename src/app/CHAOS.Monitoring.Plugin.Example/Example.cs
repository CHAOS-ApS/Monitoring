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
            return ( "hey... i am a method" );
        }
    }
}
