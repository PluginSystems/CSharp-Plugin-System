using PluginLoader.pluginloading;

namespace SecondPlugin
{
    public class SecondPlugin : IPlugin, StringFace
    {
        public string Name => "SecondPlugin";

        public void test()
        {
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }
    }
}