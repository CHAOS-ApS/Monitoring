using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
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
