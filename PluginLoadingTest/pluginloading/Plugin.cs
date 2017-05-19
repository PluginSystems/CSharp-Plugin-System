using System;

namespace PluginLoadingTest.pluginloading
{
    public class Plugin : IPlugin
    {
        public void OnEnable()
        {
            Console.Out.WriteLine("A enable testMessage from "+ GetName());
        }

        public void OnDisable()
        {
            Console.Out.WriteLine("A disable testMessage from "+GetName());
        }

        public string GetName()
        {
            return "First C# Plugin";
        }

        public bool IsOnline()
        {
            throw new NotImplementedException();
        }
    }
}