using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PluginLoadingTest.tests
{
    public class BenchmarkRun
    {
        private IDictionary<string, double> _stats = new ConcurrentDictionary<string, double>();
        
        
        public void DefineBenchmarkPoint(string benchmarkPointName, double millisElapsed)
        {
            _stats.Add(benchmarkPointName, millisElapsed);
        }

        public void DefineBenchmarkPoint(string benchmarkPointName, int run, double millisElapsed)
        {
            _stats.Add(benchmarkPointName + run, millisElapsed);
        }
        
        public IList<string> GetStatsCommaSeperatedList()
        {
            
            return _stats.Select(stat => stat.Key + "; " + stat.Value +"; miliseconds/op").ToList();
        }
        
        public void PrintStats()
        {
            foreach (string stat in GetStatsCommaSeperatedList())
            {
                Console.WriteLine(stat);
            }
        }
        
        
    }
}