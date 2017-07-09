using System;
using C_sharpModule;
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class HttpPluginTwitchBenchmark : TestCase
    {
        protected override void RunTest(int currentCycle)
        {
            var pluginLoader = new PluginLoader<IPlugin>("./plugins/");

            pluginLoader.Enable();


            var pluginCheck = pluginLoader.GetByName("TwitchPlugin");
            var twitchPluginCheck = pluginCheck as TwitchPlugin;
            if (twitchPluginCheck != null)
                for (var i = 0; i < 10; i++)
                {
                    StartTimer();
                    var plugin = pluginLoader.GetByName("TwitchPlugin");
                    var twitchPlugin = plugin as TwitchPlugin;
                    if (twitchPlugin != null)
                        Console.WriteLine(twitchPlugin.IsOnline());
                    StopTimer();
                    DefineBenchmarkPoint(currentCycle, "ContextSwitch_with_web", i);
                    ResetTimer();
                }

            pluginLoader.Disable();
        }
    }
}