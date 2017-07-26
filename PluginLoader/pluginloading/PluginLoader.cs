using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PluginLoader.pluginloading
{
    public class PluginLoader<T> where T : IPlugin
    {
        private readonly RawPluginLoader _rawPluginLoader;
        private readonly Type _pluginType;

        private IList<Type> _rawPlugins;
        private readonly IDictionary<string, T> _plugins;

        public PluginLoader(string directory)
        {
            _rawPluginLoader = new RawPluginLoader(directory);
            _pluginType = typeof(T);
            _rawPlugins = new List<Type>();
            _plugins = new ConcurrentDictionary<string, T>();
        }


        public void Load()
        {
            _rawPluginLoader.Load(_pluginType, rawPlugins => _rawPlugins = rawPlugins);
        }


        public void Enable()
        {
                foreach (var rawPlugin in _rawPlugins)
                {
                    var plugin = (T) Activator.CreateInstance(rawPlugin);
                    _plugins.Add(plugin.Name, plugin);
                    Console.Out.WriteLine("Enable Plugin " + plugin.Name);
                    plugin.OnEnable();
                    Console.Out.WriteLine("Plugin " + plugin.Name + " successfully enabled");
                }
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

        public RawPluginLoader GetRawPluginLoader()
        {
            return _rawPluginLoader;
        }
        
    }

    public interface IPlugin
    {
        void OnEnable();
        void OnDisable();
        string Name { get; }
    }
}