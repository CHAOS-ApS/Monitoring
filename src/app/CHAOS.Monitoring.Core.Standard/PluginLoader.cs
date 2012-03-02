using System.Collections.Generic;
using System.IO;
using System;
using System.Reflection;
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

        public static void Clear( )
        {
            LoadedAssemblies.Clear( );
        }

        public static bool IsAssemblyLoaded( string assemblyIdentifier )
        {
            return LoadedAssemblies.ContainsKey( assemblyIdentifier );
        }

        public static void LoadAssemblies( string assembliesLocation )
        {
            foreach ( var fullName in  Directory.GetFiles(@assembliesLocation ))
            {
                int startValueOfAssemblyName = fullName.LastIndexOf("\\") + 1;
                int lenghtOfAssemblyName = fullName.Length - startValueOfAssemblyName -4;

                string assembly = fullName.Substring( startValueOfAssemblyName, lenghtOfAssemblyName);
                Add( assembly, fullName );
            }
        }

        public static void Add( string assemblyIdentifier, string assemblyUrl )
        {
            LoadedAssemblies.Add( assemblyIdentifier, Assembly.LoadFrom( assemblyUrl ) );
        }

        public static IPlugin GetPlugin( string assemblyIdentifier, string classname )
        {
            return ( IPlugin )LoadedAssemblies[ assemblyIdentifier ].CreateInstance( assemblyIdentifier + "." + classname );
        }
    }
}
