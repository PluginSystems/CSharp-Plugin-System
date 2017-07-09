#define benchmark

using System;
using System.Collections.Generic;
using System.IO;
using PluginLoadingTest.tests;
using PluginLoadingTest.tests.testcases;

namespace PluginLoadingTest
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
        
        
        public static void CreateSpace(TextWriter writer,int lines)
        {
            for (var i = 0; i < lines; i++)
            {
                writer.WriteLine(" ");
            }
        }
        
    }
}