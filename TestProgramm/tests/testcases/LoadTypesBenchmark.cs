
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class LoadTypesBenchmark : PluginTestCase
    {

        private RawPluginLoader _rawPluginLoader;
        
        protected override void SetUp()
        {
            _rawPluginLoader = _pluginLoader.GetRawPluginLoader();
        }

        protected override void RunTest(int currentCycle)
        {
           
            StartTimer();
            _rawPluginLoader.Load(typeof(IPlugin),plugins => {});
            StopTimer();
            DefineBenchmarkPoint(currentCycle,"Loading Assemblies from directory");
            ResetTimer();
            
        }
        
        protected override void TearDown()
        {
            _rawPluginLoader = null;
        }

        public LoadTypesBenchmark(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}