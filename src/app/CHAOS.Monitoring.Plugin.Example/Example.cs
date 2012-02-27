using System;

namespace CHAOS.Monitoring.Plugin.Example
{
    public class Example : IPlugin
    {
        public Example(int id, int triggerId, String host )
        {
            Id = id;
            TriggerId = triggerId;
            Host = host;
        }

        public int Id { get; set; }

        public IPluginResult Run( )
        {
            var result = new ExampleResult { ExampleText = Host };
            return ( result );
        }

        public int TriggerId { get; set; }

        public string Host { get; set; }
    }
}
