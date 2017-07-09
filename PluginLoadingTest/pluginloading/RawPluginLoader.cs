//#define Linq



using System;
using System.Collections.Generic;
using System.IO;
#if Linq
using System.Linq;    
#endif
using System.Reflection;




namespace PluginLoadingTest.pluginloading
{
    public class RawPluginLoader
    {
        public delegate void DelieverRawPlugins(List<Type> rawPlugins);

        private readonly string _directory;

        private List<Type> _rawPlugins;


        public RawPluginLoader(string directory)
        {
            _directory = directory;
        }


        public void Load(Type pluginType, DelieverRawPlugins callback)
        {
            if (!Directory.Exists(_directory))
            {
                Console.Out.WriteLine("Creating directory " + _directory + "!");
                Directory.CreateDirectory(_directory);
            }

            var files = Directory.GetFiles(_directory, "*.dll");


            _rawPlugins = new List<Type>();

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

                    if (type.GetInterface(pluginType.FullName) != null)
                    {
                        _rawPlugins.Add(type);
                    }
                }
                #endif
            }

            callback?.Invoke(new List<Type>(_rawPlugins));
        }
    }
}