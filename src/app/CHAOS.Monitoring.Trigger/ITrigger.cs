using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Trigger
{
    public interface ITrigger
    {
        IPlugin GetPlugin( int index );
        void AddPlugin( string pluginType, string parameters );
        event TriggerActivatedEventHandler TriggerActivatedEvent;
    }
}
