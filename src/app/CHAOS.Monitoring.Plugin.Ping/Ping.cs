using System;
using System.Text;
using System.Net.NetworkInformation;

namespace CHAOS.Monitoring.Plugin.Ping
{
    public class Ping : IPlugin
    {

    public Ping(string parameters)
    {
        host = parameters;
    }

        private string host;
        public string Run( )
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping( );
            PingOptions options = new PingOptions( );

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[ ] buffer = Encoding.ASCII.GetBytes( data );
            const int timeout = 500;

            PingReply reply = pingSender.Send( host, timeout, buffer, options );

            if ( reply.Status == IPStatus.TimedOut )
                throw new TimeoutException( );

            return ( Convert.ToString( reply.RoundtripTime ));
        }
    }
}
