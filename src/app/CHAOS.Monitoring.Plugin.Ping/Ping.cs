using System;
using System.Text;
using System.Net.NetworkInformation;

namespace CHAOS.Monitoring.Plugin.Ping
{
    public class Ping : IPlugin
    {
        public Ping()
        {
                
        }

        public Ping(int id, int triggerId, string host )
        {
            Id = id;
            TriggerId = triggerId;
            Host = host;
        }

        public int TriggerId { get; set; }
        public string Host { get; set; }
        public int Id { get; set; }

        public IPluginResult Run( )
        {
            var result = new PingResult();
            var pingSender = new System.Net.NetworkInformation.Ping();

            // Create a buffer of 32 bytes of data to be transmitted.
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            const int timeout = 2500;

            PingReply reply = pingSender.Send(Host, timeout, buffer);

            if (reply.Status == IPStatus.TimedOut)
                throw new TimeoutException();

            result.RoundtripTime = reply.RoundtripTime;
            return (result);
        }
    }
}
