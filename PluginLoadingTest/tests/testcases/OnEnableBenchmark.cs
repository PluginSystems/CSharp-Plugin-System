using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest.tests.testcases
{
    public class OnEnableBenchmark : TestCase
    {
        protected override void RunTest(int currentCycle)
        {

            var pluginLoader = new PluginLoader<IPlugin>("./plugins/");

            for (int i = 0; i < 10; i++)
            {
                StartTimer();

                pluginLoader.Enable();


                pluginLoader.Disable();

                StopTimer();

                DefineBenchmarkPoint(currentCycle, "Enable_Disable_Run", i);

                ResetTimer();
            }
        }
    }
}