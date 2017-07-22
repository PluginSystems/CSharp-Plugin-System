using PluginLoader.pluginloading;

namespace TestProgramm.tests
{
    public abstract class PluginTestCase : TestCase
    {

        protected PluginLoader<IPlugin> _pluginLoader;
        
        protected PluginTestCase(PluginLoader<IPlugin> pluginLoader)
        {
            _pluginLoader = pluginLoader;
        }
        
        
    }
}