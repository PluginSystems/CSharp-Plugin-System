
/*
using System.Collections.Concurrent;
using NBench;
using NBench.Metrics.Counters;
using NUnit.Framework;
using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest.tests
{
    public class PerformanceTest
    {

		
		public void Test(){
		    
		   

		}



        private PluginLoader<Plugin> _loader;


        [SetUp]
        public void Setup()
        {
            _loader = new PluginLoader<Plugin>("./bin/Debug/plugins/");
            
            _loader.Enable();

        }

        [PerfBenchmark(Description = "Test to check the performance of the enabling and disabling process of the pluginloader", 
            NumberOfIterations = 3, RunMode = RunMode.Throughput, 
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        public void TestLoading()
        {
            _loader.Disable();
            _loader.Enable();
        }

        [PerfCleanup]
        public void CleanUp()
        {
            
            _loader.Disable();
        }
    }
}
*/