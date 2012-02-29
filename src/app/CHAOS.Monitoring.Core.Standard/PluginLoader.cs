using System.Collections.Generic;
using System.Reflection;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Core.Standard
{
    public class PluginLoader
    {
        private readonly IDictionary<int, Assembly> _LoadedAssemblies = new Dictionary<int, Assembly>( );

        private IDictionary<int, Assembly> LoadedAssemblies
        {
            get { return _LoadedAssemblies; }
        }

        public int Count
        {
            get { return LoadedAssemblies.Count; }
        }

        public void Add( int assemblyIdentifier, string assemblyUrl )
        {
            LoadedAssemblies.Add( assemblyIdentifier, Assembly.LoadFrom( assemblyUrl ) );
        }

        public IPlugin GetPlugin( int assemblyIdentifier, string classpath, string classname )
        {
            return (IPlugin) LoadedAssemblies[assemblyIdentifier].CreateInstance(classpath + "." + classname);
        }
    }
}
