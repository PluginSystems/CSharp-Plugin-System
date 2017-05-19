using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using NBench.Reporting;
using NUnit.Framework;
using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest.tests
{
    [TestFixture(TestName = "Disable/Enable/Loading test")]
    public class PerformanceTest
    {
        public int MAX_COUNT { get; private set; } = 10;

        private PluginLoader<Plugin> _loader;

        private List<long> stats;

        private Stopwatch _stopwatch;

        [SetUp]
        public void Setup()
        {
            stats = new List<long>();
            _loader = new PluginLoader<Plugin>("./bin/Debug/plugins/");

            _stopwatch = new Stopwatch();
        }

        [Test]
        public void TestLoading()
        {


            for (int i = 0; i < MAX_COUNT; i++)
            {
                _stopwatch.Start();
                _loader.Enable();
                _loader.Disable();
                _stopwatch.Stop();
                stats.Add(_stopwatch.ElapsedMilliseconds);
            }


            foreach (long stat in stats)
            {
                Console.WriteLine(stat);
            }
        }
    }
}