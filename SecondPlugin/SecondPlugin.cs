using PluginLoader.pluginloading;

namespace SecondPlugin
{
    public class SecondPlugin : IPlugin, StringFace
    {
        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        
       
        
        public string Name => "SecondPlugin";
        
        public void test()
        {
            
        }
    }
}