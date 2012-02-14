using System;
using CHAOS.Monitoring.Plugin.Example;
using CHAOS.Monitoring.Plugin.Ping;

namespace CHAOS.Monitoring.Factory.PluginFactory
{
    public static class PluginFactory
    {
        ///TODO: Make dynamic!
        /// <summary>
        /// Creates a plugin
        /// </summary>
        /// <param name="pluginType">Specifies the plugin type</param>
        /// <param name="parameters">Parameters for the plugin</param>
        /// <returns>Returns  the new plugin</returns>
        public static Plugin.IPlugin CreatePlugin( string pluginType, string parameters )
        {
            switch ( pluginType )
            {
                case "Ping":
                    return new Ping( parameters );
                case "Example":
                    return new Example( parameters );
            }
            throw new NotImplementedException( string.Format( "The plugin type: {0} does not exsist", pluginType ) );
        }
    }
}
