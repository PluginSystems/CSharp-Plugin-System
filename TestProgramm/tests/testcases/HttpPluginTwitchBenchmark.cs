using System;
using C_sharpModule;
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class HttpPluginTwitchBenchmark : PluginTestCase
    {
        protected override void SetUp()
        {
            _pluginLoader.Enable(); 
        }

        protected override void RunTest(int currentCycle)
        {
            for (var i = 0; i < 10; i++)
            {
                StartTimer();
                var plugin = _pluginLoader.GetByName("TwitchPlugin");
                var twitchPlugin = plugin as TwitchPlugin;
                Console.WriteLine("TwitchPlugin isOnline(true/false/empty -> plugin null):"+twitchPlugin?.IsOnline());
                StopTimer();
                DefineBenchmarkPoint(currentCycle, "ContextSwitch_with_web", i);
                ResetTimer();
            }
        }

        public override string getName()
        {
            return GetType().Name;
        }


        protected override void TearDown()
        {
            _pluginLoader.Disable();
        }

        public HttpPluginTwitchBenchmark(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}