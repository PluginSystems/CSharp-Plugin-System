using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest.tests.testcases
{
    public class CreatePluginInstanceBencmark : TestCase
    {
        protected override void RunTest(int currentCycle)
        {
            StartTimer();
            var pluginLoader = new PluginLoader<IPlugin>("./plugins/");
            StopTimer();
            DefineBenchmarkPoint(currentCycle,"Creating instance with directory");
            ResetTimer();
        }
    }
}