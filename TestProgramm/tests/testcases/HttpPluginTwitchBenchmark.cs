using System;
using C_sharpModule;
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class HttpPluginTwitchBenchmark : PluginTestCase
    {
        public HttpPluginTwitchBenchmark(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }

        protected override void SetUp()
        {
            _pluginLoader.Load();
            _pluginLoader.Enable();
        }

        protected override void RunTest(int currentCycle)
        {
            StartTimer();
            var plugin = _pluginLoader.GetByName("TwitchPlugin");
            var twitchPlugin = plugin as TwitchPlugin;
            Console.WriteLine("TwitchPlugin isOnline(true/false/empty -> plugin null):" + twitchPlugin?.IsOnline());
            StopTimer();
            DefineBenchmarkPoint(currentCycle, "ContextSwitch_with_web");
            ResetTimer();
        }

        protected override void TearDown()
        {
            _pluginLoader.Disable();
        }
    }
}