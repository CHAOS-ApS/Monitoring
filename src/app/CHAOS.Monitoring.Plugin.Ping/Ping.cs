using System;
using System.Text;
using System.Net.NetworkInformation;

namespace CHAOS.Monitoring.Plugin.Ping
{
    public class Ping : IPlugin
    {
        private string _threshold;
        public string Threshold
        {
            get;
            set;
        }

        private int _interval;
        public int Interval
        {
            get;
            set;
        }

        public long PingHost(string host)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 2500;

            PingReply reply = pingSender.Send(host, timeout, buffer, options);
            
            if (reply.Status == IPStatus.TimedOut)
                throw new TimeoutException();

            return (reply.RoundtripTime);
        }
    }
}
