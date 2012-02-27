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
        /// <param name="id"> </param>
        /// <param name="triggerId"> </param>
        /// <param name="host">The host that shall be pinged</param>
        public Ping(int id, int triggerId, string host )
        {
            Id = id;
            TriggerId = triggerId;
            Host = host;
        }

        public string Host { get; set; }
        public int Id { get; set; }

        public IPluginResult Run( )
        {
            var result = new PingResult();
            var pingSender = new System.Net.NetworkInformation.Ping( );

            // Create a buffer of 32 bytes of data to be transmitted.
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[ ] buffer = Encoding.ASCII.GetBytes( data );
            const int timeout = 2500;

            PingReply reply = pingSender.Send( Host, timeout, buffer );

            if ( reply.Status == IPStatus.TimedOut )
                throw new TimeoutException( );

            result.RoundtripTime = reply.RoundtripTime;
            return (result);
        }

        public int TriggerId { get; set; }

    }
}
