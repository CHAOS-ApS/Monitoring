using CHAOS.Monitoring.Plugin.Example;
using CHAOS.Monitoring.Plugin.Ping;

namespace CHAOS.Monitoring.Factory
{
    public static class Factory
    {
        public static Plugin.IPlugin CreatePlugin(string parameters)
        {
            int pluginType = DeterminePluginType(parameters);
 
            switch(pluginType)
            {
                case 0:
                    return new Ping(parameters);
                case 1:
                    return new Example(parameters);
                default:
                    return (null);
            }
        }

        private static int DeterminePluginType(string parameters)
        {
            return (0);
        }
    }
}

