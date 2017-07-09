using System;
using System.Collections.Generic;
using System.IO;
using TestProgramm.tests;
using TestProgramm.tests.testcases;


namespace TestProgramm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var stats = new List<TestCase>
            {
                new LoadTypesBenchmark(),
                new OnEnableBenchmark(),
                new HttpPluginTwitchBenchmark()
            };


            var streamWriter = new StreamWriter("./performanceTest.csv");

            stats.ForEach(testcase => testcase.RunTestFully(10));

            stats.ForEach(finishedTest => finishedTest.PrintStats(streamWriter));
            
            streamWriter.Flush();
            streamWriter.Close();
            
            Console.Out.WriteLine("Test finished");
            
        }
    }
}