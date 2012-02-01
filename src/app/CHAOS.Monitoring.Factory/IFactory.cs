using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Factory
{
    public interface IFactory
    {
        IPlugin InitilizePlugin(string parameters);
    }
}
