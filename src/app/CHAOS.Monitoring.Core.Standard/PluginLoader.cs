using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CHAOS.Monitoring.Plugin;

namespace CHAOS.Monitoring.Core.Standard
{
    public static class PluginLoader
    {
        private static readonly IDictionary<string, Assembly> _LoadedAssemblies = new Dictionary<string, Assembly>( );

        private static IDictionary<string, Assembly> LoadedAssemblies
        {
            get { return _LoadedAssemblies; }
        }

        public static int Count
        {
            get { return LoadedAssemblies.Count; }
        }

        public static void Add( string assemblyIdentifier, string assemblyUrl )
        {
            LoadedAssemblies.Add( assemblyIdentifier, Assembly.LoadFrom( assemblyUrl ) );
        }

        public static T GetPlugin<T>( string assemblyIdentifier, string assembly, string classname ) where T : IPlugin
        {
            return ( T )LoadedAssemblies[ assemblyIdentifier ].CreateInstance( assembly + "." + classname );
        }

        public static T GetPlugin<T>( string version, string fullname ) where T : IPlugin
        {
            string assembly = fullname.Substring( 0, fullname.LastIndexOf( "." ) );
            string key = version + ", " + assembly;

            if ( !LoadedAssemblies.ContainsKey( key ) )
                throw new KeyNotFoundException( key + " wasn't present in the dictionary" );

            return ( T )LoadedAssemblies[ key ].CreateInstance( fullname );
        }



    }
}
