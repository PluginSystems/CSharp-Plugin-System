using PluginLoadingTest.pluginloading;

namespace PluginLoadingTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var pluginLoader = new PluginLoader<IPlugin>("./plugins/");

            pluginLoader.Enable();

            pluginLoader.Disable();
        }
    }
}
