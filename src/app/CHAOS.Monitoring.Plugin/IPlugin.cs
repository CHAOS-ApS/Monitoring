using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CHAOS.Monitoring.Plugin
{
    public interface IPlugin
    {
        string Threshold
        {
            get; 
            set;
        }

        int Interval 
        { 
            get;
            set;
        }

        /*TODO:
         * all plugings shall have some method for reading xml
         * so that they can take in an xml document as a parameter
         * and then select just the good parts that the plugin needs.
         * */
    }
}
