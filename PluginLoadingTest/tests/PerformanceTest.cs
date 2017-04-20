using NUnit.Framework;
using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest.tests
{
    using NBench.Util;
    using NBench;

    [TestFixture]
    public class PerformanceTest
    {
        /// <summary>
        /// Test to see if we can achieve max throughput on a <see cref="AtomicCounter"/>
        /// </summary>
        /*private Counter _counter;

        [PerfSetup]
        [TestCase]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 3, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
        public void Benchmark()
        {
            _counter.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }*/



        [TestCase]
        public void TestLoading()
        {
           PluginLoader<Plugin> pl = new  PluginLoader<Plugin>("plugins/");

            pl.Enable();



            pl.Disable();



        }



    }
}