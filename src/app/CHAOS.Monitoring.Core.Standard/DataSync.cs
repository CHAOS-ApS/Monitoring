using System.Collections.Generic;
using CHAOS.Monitoring.Data.Standard;
using CHAOS.Monitoring.Plugin.Standard;

namespace CHAOS.Monitoring.Core.Standard
{
    public static class DataSync
    {
        public static List<Trigger.Standard.Trigger> SyncTriggerObjects()
        {
            var triggers = new List<Trigger.Standard.Trigger>();
            using (var db = new MonitorLibraryEntities())
            {
                foreach (var trigger in db.Trigger_Get())
                {
                    triggers.Add(new Trigger.Standard.Trigger(trigger.ID, trigger.StartDateTime, trigger.Repetition));
                }
            }
            return triggers;
        }

        public static List<Plugin.IPlugin> SyncPluginObjects()
        {
            var plugins = new List<Plugin.IPlugin>();
            using (var db = new MonitorLibraryEntities())
            {
                foreach (var plugin in db.PluginInfo_Get())
                {
                    plugins.Add(PluginFactory.CreatePlugin(plugin.ID,plugin.TriggerID,plugin.Type,plugin.HostAdress));
                }
            }
            return plugins;
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    }
}