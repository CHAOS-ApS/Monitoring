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
            ExampleResult result = new ExampleResult { ExampleText = _parameters };
            return ( result );
        }
    }
}
