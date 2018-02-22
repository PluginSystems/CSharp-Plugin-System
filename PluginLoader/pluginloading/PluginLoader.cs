using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PluginLoader.pluginloading
{
    public class PluginLoader<T> where T : IPlugin
    {
        private readonly Type _pluginType;
        private readonly RawPluginLoader _rawPluginLoader;

        private IDictionary<string, T> _plugins;

        public PluginLoader(string directory)
        {
            _rawPluginLoader = new RawPluginLoader(directory);
            _pluginType = typeof(T);
            _plugins = new ConcurrentDictionary<string, T>();
        }


        public void Load()
        {
            _plugins = new ConcurrentDictionary<string, T>();
            _rawPluginLoader.Load(_pluginType, rawPlugins =>
            {
                foreach (var rawPlugin in rawPlugins)
                {
                    var plugin = (T) Activator.CreateInstance(rawPlugin);
                    _plugins.Add(plugin.Name, plugin);
                }
            });
        }


        public void Enable()
        {
            foreach (var plugin in _plugins) plugin.Value.OnEnable();
        }

        public void Disable()
        {
            foreach (var keyValuePair in _plugins) keyValuePair.Value.OnDisable();
        }


        public void Unload()
        {
            _plugins.Clear();
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
        string Name { get; }
        void OnEnable();
        void OnDisable();
    }
}