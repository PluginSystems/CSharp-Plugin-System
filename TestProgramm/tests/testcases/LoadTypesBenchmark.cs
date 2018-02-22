using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class LoadTypesBenchmark : PluginTestCase
    {
        public LoadTypesBenchmark(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }


        protected override void SetUp()
        {
        }

        protected override void RunTest(int currentCycle)
        {
            StartTimer();
            _pluginLoader.Load();
            _pluginLoader.Unload();
            StopTimer();
            DefineBenchmarkPoint(currentCycle, "Loading Assemblies from directory");
            ResetTimer();
        }
    }
}