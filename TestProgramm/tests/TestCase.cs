using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TestProgramm.tests
{
    public abstract class TestCase
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private IList<BenchmarkRun> _benchmarkRuns;


        public void RunTestFully(int cycles)
        {
            _benchmarkRuns = new List<BenchmarkRun>(cycles);
            SetUp();
            for (var i = 0; i < cycles; i++)
            {
                _benchmarkRuns.Add(new BenchmarkRun());
                RunTest(i);
            }
            TearDown();
        }

        protected virtual void SetUp(){}

        protected abstract void RunTest(int currentCycle);

        public abstract string getName();

        protected virtual void TearDown(){}
        

        public void PrintStats(TextWriter writer)
        {
            foreach (BenchmarkRun benbBenchmarkRun in _benchmarkRuns)
            {
                benbBenchmarkRun.PrintStats(writer);
            }
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
            _benchmarkRuns[cycle].DefineBenchmarkPoint(benchmarkPointName, GetElapsedNanos());
        }

        protected void DefineBenchmarkPoint(int cycle, string benchmarkPointName, int run)
        {
            _benchmarkRuns[cycle].DefineBenchmarkPoint(benchmarkPointName +"_"+(cycle+1)+"_"+ (run+1),GetElapsedNanos());
        }

        private double GetElapsedMicros()
        {
            return _stopwatch.Elapsed.TotalMilliseconds * 100;
        }

        private double GetElapsedNanos()
        {
            return _stopwatch.Elapsed.TotalMilliseconds * 1_000_000;
        }

    }
}