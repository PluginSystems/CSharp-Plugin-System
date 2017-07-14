using System;
using PluginLoader.pluginloading;

namespace SecondPlugin
{
    public class SecondPlugin : IPlugin
    {
        public void OnEnable()
        {
            Console.WriteLine("Enabled: Text only plugin");
        }

        public void OnDisable()
        {
            Console.WriteLine("Disabled: Text only plugin");
        }

        public string Name => "SecondPlugin";
    }
}