﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CHAOS.Monitoring.Plugin
{
    public interface IPlugin
    {
        string Run( );
        Log.Log GetLog();
        //bool Stop()
    }
}
