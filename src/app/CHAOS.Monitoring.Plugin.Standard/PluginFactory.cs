using System;

namespace CHAOS.Monitoring.Plugin.Standard
{
    public static class PluginFactory
    {
        /// TODO: Make dynamic!
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
                    return new Ping.Ping( parameters );
                case "Example":
                    return new Example.Example( parameters );
            }
            throw new NotImplementedException( string.Format( "The plugin type: {0} does not exsist", pluginType ) );
        }
    }
}
