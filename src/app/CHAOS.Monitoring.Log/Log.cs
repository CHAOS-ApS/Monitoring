using System;
using System.Collections.Generic;

namespace CHAOS.Monitoring.Log
{
    public class Log
    {
        private List<String> _log = new List<string>(); 

        public void UpdateLog(string appEvent)
        {
            _log.Add(appEvent);
        }

        public List<String> GetLog()
        {
            return (_log);
        }
    }
}
