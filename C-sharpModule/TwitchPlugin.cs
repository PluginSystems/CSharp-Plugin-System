using System;
using PluginLoadingTest.pluginloading;

namespace C_sharpModule
{
    public class TwitchPlugin : IPlugin

    {
        public void OnEnable()
        {
            // todo rewriting TwichAPI for C#
            Console.Out.WriteLine("Hey Ho from TwitchPlugin");
        }

        public void OnDisable()
        {
            Console.Out.WriteLine("Goodbye from TwichPlugin");
        }

        public string GetName()
        {
            return "TwitchPlugin";
        }
    }
}