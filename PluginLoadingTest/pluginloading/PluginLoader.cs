using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PluginLoadingTest.pluginloading
{
    public class PluginLoader<T> where T : IPlugin
    {
        private readonly RawPluginLoader _rawPluginLoader;
        private readonly Type _pluginType;

        private readonly IDictionary<string, T> _plugins;

        public PluginLoader(string directory)
        {
            _rawPluginLoader = new RawPluginLoader(directory);
            _pluginType = typeof(T);
            _plugins = new ConcurrentDictionary<string, T>();
        }


        public void Enable()
        {
            _rawPluginLoader.Load(_pluginType, rawPlugins =>
            {
                foreach (var rawPlugin in rawPlugins)
                {
                    var plugin = (T) Activator.CreateInstance(rawPlugin);
                    _plugins.Add(plugin.GetName(), plugin);
                    Console.Out.WriteLine("Enable Plugin " + plugin.GetName());
                    plugin.OnEnable();
                    Console.Out.WriteLine("Plugin " + plugin.GetName() + " successfully enabled");
                }
            });
        }

        public void Disable()
        {
            foreach (var keyValuePair in _plugins)
            {
                Console.Out.WriteLine("Disable Plugin " + keyValuePair.Value.GetName());
                keyValuePair.Value.OnDisable();
                Console.Out.WriteLine("Plugin " + keyValuePair.Value.GetName() + " successfully disabled");
                _plugins.Remove(keyValuePair);
            }
        }

        public T GetByName(string name)
        {
            return _plugins[name];
        }

    }

    public interface IPlugin
    {
        void OnEnable();
        void OnDisable();
        string GetName();
        bool IsOnline();
    }
}