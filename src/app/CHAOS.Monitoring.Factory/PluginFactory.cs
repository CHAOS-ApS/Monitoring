using System;
using CHAOS.Monitoring.Plugin.Example;
using CHAOS.Monitoring.Plugin.Ping;

namespace CHAOS.Monitoring.Factory
{
    public static class PluginFactory
    {
        public static Plugin.IPlugin CreatePlugin(string pluginType, string parameters)
        {
            switch(pluginType)
            {
                case "Ping":
                    return new Ping(parameters);
                case "Example":
                    return new Example(parameters);
            }
            throw new NotImplementedException(string.Format("The plugin type: {0} does not exsist", pluginType));
        }
    }
}
