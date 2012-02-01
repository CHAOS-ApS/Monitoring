using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Factory.Example
{
    public class ExampleFactory : IFactory
    {
        public IPlugin InitilizePlugin( string parameters )
        {
            return ( new Plugin.Example.Example( parameters ) );
        }
    }
}
