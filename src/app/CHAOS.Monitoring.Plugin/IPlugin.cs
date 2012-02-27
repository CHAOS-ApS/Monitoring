namespace CHAOS.Monitoring.Plugin
{
    public interface IPlugin
    {
        IPluginResult Run( );

        int Id { get; set; }

        int TriggerId { get; set; }

        string Host { get; set; }
    }
}
