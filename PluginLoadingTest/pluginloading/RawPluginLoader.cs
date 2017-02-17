using System;
using System.Collections.Generic;
using System.IO;
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
                Console.Out.WriteLine("Creating directory "+_directory+"!");
                Directory.CreateDirectory(_directory);
            }

            var files = Directory.GetFiles(_directory, "*.dll");


            _rawPlugins = new List<Type>();

            foreach (var file in files)
            {
                var assemblyName = AssemblyName.GetAssemblyName(file);

                var assembly = Assembly.Load(assemblyName);

                if (assembly == null) continue;
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsInterface || type.IsAbstract) continue;


                    if (type.GetInterface(pluginType.FullName) != null)
                    {
                        _rawPlugins.Add(type);
                    }
                }
            }

            callback?.Invoke(new List<Type>(_rawPlugins));
        }
    }
}