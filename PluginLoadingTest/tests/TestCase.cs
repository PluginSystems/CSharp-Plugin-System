using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PluginLoadingTest.tests
{
    public abstract class TestCase
    {
        private Stopwatch _stopwatch = new Stopwatch();
        private IList<BenchmarkRun> _benchmarkRuns;


        public void RunTestFully(int cycles)
        {
            _benchmarkRuns = new List<BenchmarkRun>(cycles);
            for (int i = 0; i < cycles; i++)
            {
                _benchmarkRuns.Add(new BenchmarkRun());
                RunTest(i);
            }
        }


        protected abstract void RunTest(int currentCycle);

        public void PrintStats()
        {
            Console.WriteLine("Benchmark " + GetType().Name);
            for (int i = 0; i < _benchmarkRuns.Count; i++)
            {
                Console.WriteLine("Run: " + (i+1));
                _benchmarkRuns[i].PrintStats();
            }
            
            Program.createSpace(5);
            
        }

        protected double getTimeForRun()
        {
            return _stopwatch.Elapsed.TotalMilliseconds;
        }

        protected void StartTimer()
        {
            _stopwatch.Start();
        }

        protected void StopTimer()
        {
            _stopwatch.Stop();
        }

        protected void ResetTimer()
        {
            _stopwatch.Reset();
        }

        protected void DefineBenchmarkPoint(int cycle, string benchmarkPointName)
        {
            _benchmarkRuns[cycle].DefineBenchmarkPoint(benchmarkPointName, getTimeForRun());
        }

        protected void DefineBenchmarkPoint(int cycle, string benchmarkPointName, int run)
        {
            _benchmarkRuns[cycle].DefineBenchmarkPoint(benchmarkPointName + run, getTimeForRun());
        }

    }
}