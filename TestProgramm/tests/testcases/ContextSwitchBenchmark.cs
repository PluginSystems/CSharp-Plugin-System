using System;
using PluginLoader.pluginloading;

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
            StartTimer();
            var plugin = _pluginLoader.GetByName("SecondPlugin");
            var secondPlugin = plugin as SecondPlugin.SecondPlugin;
            secondPlugin?.printParameter("ContextSwitch");
            StopTimer();
            DefineBenchmarkPoint(currentCycle, "ContextSwitch");
            ResetTimer();
        }
        
        
        protected override void TearDown()
        {
            _pluginLoader.Disable();
        }
        

        public ContextSwitch(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}