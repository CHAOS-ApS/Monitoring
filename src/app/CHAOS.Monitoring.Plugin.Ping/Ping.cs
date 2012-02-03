using System;
using System.Text;
using System.Net.NetworkInformation;

namespace CHAOS.Monitoring.Plugin.Ping
{
    public class Ping : IPlugin
    {
        public Ping( string host )
        {
            _host = host;
        }

        public Log.Log GetLog()
        {
            return _log;
        }

        private Log.Log _log = new Log.Log( );
        private readonly string _host;

        public string Run( )
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping( );

            // Create a buffer of 32 bytes of data to be transmitted.
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[ ] buffer = Encoding.ASCII.GetBytes( data );
            const int timeout = 10000;

            PingReply reply = pingSender.Send( _host, timeout, buffer );

            if ( reply.Status == IPStatus.TimedOut )
                throw new TimeoutException( );

            _log.UpdateLog( String.Format( "{0} was pinged and it took {1} MS", _host, reply.RoundtripTime ) );
            
            return ( Convert.ToString( reply.RoundtripTime ) );
        }
    }
}
