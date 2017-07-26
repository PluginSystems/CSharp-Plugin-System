using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class OnEnableBenchmark : PluginTestCase
    {


        protected  override void SetUp()
        {
            _pluginLoader.Load();
        }
        
        protected override void RunTest(int currentCycle)
        {
            StartTimer();

            _pluginLoader.Enable();

            _pluginLoader.Disable();

            StopTimer();

            DefineBenchmarkPoint(currentCycle, "Enable_Disable_Run");

            ResetTimer();
        }


        public OnEnableBenchmark(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}