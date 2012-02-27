using System;

namespace CHAOS.Monitoring.Plugin.Standard
{
    public static class PluginFactory
    {
        /// TODO: Make dynamic!
        /// <summary>
        /// Creates a plugin
        /// </summary>
        /// <param name="id"> </param>
        /// <param name="triggerId"> </param>
        /// <param name="pluginType">Specifies the plugin type</param>
        /// <param name="host"> </param>
        /// <returns>Returns  the new plugin</returns>
        public static Plugin.IPlugin CreatePlugin(int id, int triggerId, string pluginType, string host )
        {
            switch ( pluginType )
            {
                case "Ping":
                    return new Ping.Ping( id, triggerId, host );
                case "Example":
                    return new Example.Example( id, triggerId, host );
            }
            throw new NotImplementedException( string.Format( "The plugin type: {0} does not exsist", pluginType ) );
        }
    }
}