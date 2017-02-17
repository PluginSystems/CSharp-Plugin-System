using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginLoadingTest.pluginloading
{
    public class RawPluginLoader
    {
        public delegate void DelieverRawPlugins(List<Type> rawPlugins);

        private readonly string directory;

        private List<Type> rawPlugins;


        public RawPluginLoader(string directory)
        {
            this.directory = directory;
        }


        public void Load(Type pluginType, DelieverRawPlugins callback)
        {
            if (!Directory.Exists(directory))
            {
                Console.Out.WriteLine("Creating directory "+directory+"!");
                Directory.CreateDirectory(directory);
            }

            string[] files = Directory.GetFiles(directory, "*.dll");


            rawPlugins = new List<Type>();

            foreach (string file in files)
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(file);

                Assembly assembly = Assembly.Load(assemblyName);

                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract) continue;


                        if (type.GetInterface(pluginType.FullName) != null)
                        {
                            rawPlugins.Add(type);
                        }
                    }
                }
            }

            callback?.Invoke(new List<Type>(rawPlugins));
        }
    }
}