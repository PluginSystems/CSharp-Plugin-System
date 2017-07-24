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

        
        public string ReturnParameter(string par)
        {
            return par;
        }

        public void printParameter(string par)
        {
            Console.WriteLine(par);
        }
        
        public string Name => "SecondPlugin";
    }
}