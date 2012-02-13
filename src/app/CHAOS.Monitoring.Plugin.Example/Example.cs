using System;

namespace CHAOS.Monitoring.Plugin.Example
{
    public class Example : IPlugin
    {
        public Example( String parameters )
        {
             _parameters = parameters;
        }

        private readonly string _parameters;

        public IPluginResult Run( )
        {
            ExampleResult result = new ExampleResult( );
            result.Result = _parameters;
            return ( result );
        }
    }
}
