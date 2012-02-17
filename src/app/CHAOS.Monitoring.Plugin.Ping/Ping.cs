using System;
using System.Text;
using System.Net.NetworkInformation;

namespace CHAOS.Monitoring.Plugin.Ping
{
    public class Ping : IPlugin
    {
        /// <summary>
        /// Initilizes the plugin with the host it shall ping
        /// </summary>
        /// <param name="host">The host that shall be pinged</param>
        public Ping( string host )
        {
            _host = host;
        }

        private readonly string _host;

        public IPluginResult Run( )
        {
            PingResult result = new PingResult();
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping( );

            // Create a buffer of 32 bytes of data to be transmitted.
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[ ] buffer = Encoding.ASCII.GetBytes( data );
            const int timeout = 2500;

            PingReply reply = pingSender.Send( _host, timeout, buffer );

            if ( reply.Status == IPStatus.TimedOut )
                throw new TimeoutException( );

            result.RoundtripTime = reply.RoundtripTime;
            return (result);
        }
    }
}
