using System;
using System.Collections.Generic;
using System.IO;
using PluginLoader.pluginloading;
using TestProgramm.tests;
using TestProgramm.tests.testcases;


namespace TestProgramm
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var pluginLoader = new PluginLoader<IPlugin>("./plugins");
            
            var stats = new List<TestCase>
            {
                new LoadTypesBenchmark(pluginLoader),
                new OnEnableBenchmark(pluginLoader),
                new HttpPluginTwitchBenchmark(pluginLoader)
            };

            const int count = 10;

            var currentTimeMillis = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;
            var streamWriter = new StreamWriter("./results_"+count+"_"+currentTimeMillis+".csv");

            stats.ForEach(testcase => testcase.RunTestFully(count));

            stats.ForEach(finishedTest => finishedTest.PrintStats(streamWriter));
            
            streamWriter.Flush();
            streamWriter.Close();
            
            Console.Out.WriteLine("Test finished");
            
        }
    }
}