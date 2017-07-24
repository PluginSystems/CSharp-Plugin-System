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
                new HttpPluginTwitchBenchmark(pluginLoader),
                new ContextSwitch(pluginLoader),
                new ContextSwitchReturnType(pluginLoader)
            };

            // 10, 50, 70, 100, 250
            int[] count = {10, 50, 70, 100, 250};

            var currentTimeMillis = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;


            foreach (var cycle in count)
            {
                stats.ForEach(testcase =>
                {
                    testcase.RunTestFully(cycle);
                });

                stats.ForEach(finishedTest =>
                {
                    var streamWriter = new StreamWriter("./results_"+cycle+"_"+finishedTest.GetName()+"_nanoseconds_"+currentTimeMillis+".csv");
                    finishedTest.PrintStats(streamWriter);
                
                    streamWriter.Flush();
                    streamWriter.Close();
                
                });
            }
            
            Console.Out.WriteLine("Test finished");
            
        }
    }
}