using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PluginLoader.pluginloading
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
                    _plugins.Add(plugin.Name, plugin);
                    Console.Out.WriteLine("Enable Plugin " + plugin.Name);
                    plugin.OnEnable();
                    Console.Out.WriteLine("Plugin " + plugin.Name + " successfully enabled");
                }
            });
        }

        public void Disable()
        {
            foreach (var keyValuePair in _plugins)
            {
                Console.Out.WriteLine("Disable Plugin " + keyValuePair.Value.Name);
                keyValuePair.Value.OnDisable();
                Console.Out.WriteLine("Plugin " + keyValuePair.Value.Name + " successfully disabled");
                _plugins.Remove(keyValuePair);
            }
        }

        public T GetByName(string name)
        {
            return _plugins.ContainsKey(name) ? _plugins[name] : default(T);
        }
    }

    public interface IPlugin
    {
        void OnEnable();
        void OnDisable();
        string Name { get; };
    }
}