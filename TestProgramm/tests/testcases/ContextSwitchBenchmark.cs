using PluginLoader.pluginloading;
using SecondPlugin;

namespace TestProgramm.tests.testcases
{
    public class ContextSwitch : PluginTestCase
    {
        
        protected override void SetUp()
        {
            _pluginLoader.Load();
            _pluginLoader.Enable(); 
        }
        
        protected override void RunTest(int currentCycle)
        {
            var plugin = _pluginLoader.GetByName("SecondPlugin");
            var secondPlugin = plugin as StringFace;
            StartTimer();
            secondPlugin?.test();
            StopTimer();
            DefineBenchmarkPoint(currentCycle, "ContextSwitch");
            ResetTimer();
        }
        
        
        protected override void TearDown()
        {
            _pluginLoader.Disable();
            _pluginLoader.Unload();
        }
        

        public ContextSwitch(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}