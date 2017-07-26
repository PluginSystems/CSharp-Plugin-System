using System;
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class ContextSwitchReturnType : PluginTestCase
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
            Console.WriteLine(secondPlugin?.ReturnParameter("ContextSwitch_ReturnType"));
            StopTimer();
            DefineBenchmarkPoint(currentCycle, "ContextSwitch_ReturnType");
            ResetTimer();
        }
        
        
        protected override void TearDown()
        {
            _pluginLoader.Disable();
        }

        public ContextSwitchReturnType(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}