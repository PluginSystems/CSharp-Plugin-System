//#define Linq


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

#if Linq
using System.Linq;    
#endif


namespace PluginLoader.pluginloading
{
    public class RawPluginLoader
    {
        public delegate void DelieverRawPlugins(HashSet<Type> rawPlugins);

        private readonly string _directory;

        private HashSet<Type> _rawPlugins;


        public RawPluginLoader(string directory)
        {
            _directory = directory;
        }


        public void Load(Type pluginType, DelieverRawPlugins callback)
        {
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
                
            }

            var files = Directory.GetFiles(_directory, "*.dll");


            _rawPlugins = new HashSet<Type>();

            foreach (var file in files)
            {
                var assemblyName = AssemblyName.GetAssemblyName(file);

                var assembly = Assembly.Load(assemblyName);

                if (assembly == null) continue;


                
                
                #if Linq
                foreach (var type in assembly.GetTypes().Where(t=> pluginType.IsAssignableFrom(t) && !t.IsAbstract))
                {
                    _rawPlugins.Add(type);
                }

                #else
                
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsInterface || type.IsAbstract) continue;

                    if (type.GetInterfaces().Contains(pluginType))
                    {
                        _rawPlugins.Add(type);
                    }
                }
                #endif
            }

            callback?.Invoke(_rawPlugins);
        }
    }
}