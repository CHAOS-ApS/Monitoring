using System.Collections.Generic;
using System.Reflection;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Core.Standard
{
    public class PluginLoader
    {
        private readonly IDictionary<string, Assembly> _LoadedAssemblies = new Dictionary<string, Assembly>( );

        private IDictionary<string, Assembly> LoadedAssemblies
        {
            get { return _LoadedAssemblies; }
        }

        public int Count
        {
            get { return LoadedAssemblies.Count; }
        }

        public void Add( string assemblyIdentifier, string assemblyUrl )
        {
            LoadedAssemblies.Add( assemblyIdentifier, Assembly.LoadFrom( assemblyUrl ) );
        }

        public IPlugin GetPlugin( string assemblyIdentifier, string classpath )
        {
            return ( IPlugin )LoadedAssemblies[ assemblyIdentifier ].CreateInstance( classpath );
        }
    }
}
