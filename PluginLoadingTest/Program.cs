#define benchmark

using System;
using System.Collections.Generic;
using PluginLoadingTest.tests;
using PluginLoadingTest.tests.testcases;

namespace PluginLoadingTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var stats = new List<TestCase>();

            stats.Add(new CreatePluginInstanceBencmark());
            stats.Add(new OnEnableBenchmark());
            stats.Add(new HttpPluginTwitchBenchmark());


            stats.ForEach(testcase => testcase.RunTestFully(10));

            createSpace(5);
            
            stats.ForEach(finishedTest => finishedTest.PrintStats());
        }
        
        
        public static void createSpace(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine(" ");
            }
        }
        
    }
}