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
            for (var i = 0; i < cycles; i++)
            {
                _benchmarkRuns.Add(new BenchmarkRun());
                RunTest(i);
            }
        }


        protected abstract void RunTest(int currentCycle);

        public void PrintStats(TextWriter writer)
        {
            writer.WriteLine("Benchmark " + GetType().Name+";microseconds/op");
            for (var i = 0; i < _benchmarkRuns.Count; i++)
            {
                writer.WriteLine("Run: " + (i+1));
                _benchmarkRuns[i].PrintStats(writer);
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
            _benchmarkRuns[cycle].DefineBenchmarkPoint(benchmarkPointName, GetElapsedMicros());
        }

        protected void DefineBenchmarkPoint(int cycle, string benchmarkPointName, int run)
        {
            _benchmarkRuns[cycle].DefineBenchmarkPoint(benchmarkPointName + run,GetElapsedMicros());
        }

        private double GetElapsedMicros()
        {
            return _stopwatch.Elapsed.TotalMilliseconds * 100;
        }

    }
}