
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class LoadTypesBenchmark : TestCase
    {
        protected override void RunTest(int currentCycle)
        {
            var pluginLoader = new RawPluginLoader("./plugins/");
            StartTimer();
            pluginLoader.Load(typeof(IPlugin),plugins => {});
            StopTimer();
            DefineBenchmarkPoint(currentCycle,"Loading Assemblies from directory");
            ResetTimer();
            
        }
    }
}