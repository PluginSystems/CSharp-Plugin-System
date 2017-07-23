﻿
using PluginLoader.pluginloading;

namespace TestProgramm.tests.testcases
{
    public class OnEnableBenchmark : PluginTestCase
    {
       
        protected override void RunTest(int currentCycle)
        {
            for (var i = 0; i < 10; i++)
            {
                StartTimer();

                _pluginLoader.Enable();

                _pluginLoader.Disable();

                StopTimer();

                DefineBenchmarkPoint(currentCycle, "Enable_Disable_Run", i);

                ResetTimer();
            }
        }

        
      public OnEnableBenchmark(PluginLoader<IPlugin> pluginLoader) : base(pluginLoader)
        {
        }
    }
}