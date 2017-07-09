using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProgramm.tests
{
    public class BenchmarkRun
    {
        private readonly IDictionary<string, double> _stats = new ConcurrentDictionary<string, double>();
        
        
        public void DefineBenchmarkPoint(string benchmarkPointName, double microsElapsed)
        {
            _stats.Add(benchmarkPointName, microsElapsed);
        }

        public void DefineBenchmarkPoint(string benchmarkPointName, int run, double microsElapsed)
        {
            _stats.Add(benchmarkPointName + run, microsElapsed);
        }
        
        public IList<string> GetStatsCommaSeperatedList()
        {
            
            return _stats.Select(stat => stat.Key + "; " + stat.Value).ToList();
        }
        
        public void PrintStats(TextWriter writer)
        {
            foreach (var stat in GetStatsCommaSeperatedList())
            {
                writer.WriteLine(stat);
            }
        }
        
        
    }
}