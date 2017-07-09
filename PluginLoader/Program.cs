using PluginLoader.pluginloading;

namespace PluginLoader
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var pluginloader = new PluginLoader<IPlugin>("./plugins");
            pluginloader.Enable();
            pluginloader.Disable();

        }
    }
}