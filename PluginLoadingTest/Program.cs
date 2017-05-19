using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            List<long> stats = new List<long>();
            Stopwatch stopwatch = new Stopwatch();



            stopwatch.Start();
            var pluginLoader = new PluginLoader<IPlugin>("./plugins/");
            stopwatch.Stop();

            //stats.Add(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                pluginLoader.Enable();

                pluginLoader.Disable();

                stopwatch.Stop();

                stats.Add(stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
            }

            Console.WriteLine("AVG(ms/op): "+ stats.Average());

            stats.Clear();

            pluginLoader.Enable();



            for (int i = 0; i < 10; i++)
            {
                stopwatch.Start();
                Console.WriteLine(pluginLoader.GetByName("TwitchPlugin").IsOnline());
                stopwatch.Stop();
                stats.Add(stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
            }


            Console.WriteLine("AVH(ms/op): " + stats.Average());

            pluginLoader.Disable();



        }
    }
}
