using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHAOS.Monitoring.Plugin.Example
{
    public class ExampleResult : IPluginResult
    {
        public string Result { get; set; }

        public override string ToString( )
        {
            return Result;
        } 
    }
}
