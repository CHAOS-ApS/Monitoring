using System;
using System.Collections.Generic;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger.Standard
{
    public class PluginResultsArgs: EventArgs
    {
        private List<IPluginResult> _results = new List<IPluginResult>( );

        public void SaveResult( IPluginResult pluginResult )
        {
            _results.Add( pluginResult );
        }

        public IEnumerable<IPluginResult> GetResults( )
        {
            return _results;
        }
    }
}
