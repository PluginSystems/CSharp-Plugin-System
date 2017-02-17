using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PluginLoadingTest.pluginloading
{
    public class PluginLoader<T> where T : IPlugin
    {
        private RawPluginLoader rawPluginLoader;
        private Type pluginType;

        private IDictionary<string, T> plugins;

        public PluginLoader(string directory)
        {
            rawPluginLoader = new RawPluginLoader(directory);
            pluginType = typeof(T);
            plugins = new ConcurrentDictionary<string, T>();
        }


        public void Enable()
        {
            rawPluginLoader.Load(pluginType, rawPlugins =>
            {
                foreach (Type rawPlugin in rawPlugins)
                {
                    T plugin = (T) Activator.CreateInstance(rawPlugin);
                    plugins.Add(plugin.GetName(), plugin);
                    Console.Out.WriteLine("Enable Plugin "+plugin.GetName());
                    plugin.OnEnable();
                    Console.Out.WriteLine("Plugin "+plugin.GetName()+" successfully enabled");
                }
            });
        }

        public void Disable()
        {
            foreach (KeyValuePair<string, T> keyValuePair in plugins)
            {
                keyValuePair.Value.OnDisable();
                plugins.Remove(keyValuePair);
            }
        }
    }

    public interface IPlugin
    {
        void OnEnable();
        void OnDisable();
        string GetName();
    }
}