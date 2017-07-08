using System;
using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest.tests.testcases
{
    public class HttpPluginTwitchBenchmark : TestCase
    {
        protected override void RunTest(int currentCycle)
        {
            var pluginLoader = new PluginLoader<IPlugin>("./plugins/");

            pluginLoader.Enable();


            for (int i = 0; i < 10; i++)
            {
                StartTimer();
                Console.WriteLine(pluginLoader.GetByName("TwitchPlugin").IsOnline());
                StopTimer();
                DefineBenchmarkPoint(currentCycle, "ContextSwitch_with_web", i);
                ResetTimer();
            }

            pluginLoader.Disable();
        }
    }
}