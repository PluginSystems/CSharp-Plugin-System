using System;
using C_sharpModule.twitchapi;
using PluginLoadingTest.pluginloading;

namespace C_sharpModule
{
    public class TwitchPlugin : IPlugin

    {
        private TwitchAPI _twitchApi;

        public void OnEnable()
        {
            // twitch api key
            _twitchApi = new TwitchAPI("iiwsu6n5r8qiu1cug6zwupldjkfyn3");

            Console.WriteLine("Spiel: " + _twitchApi
                                  ._syncTwitchConnector
                                  .connectToStream("reabendet")
                                  ._streamResponseImplementation?.getGameName);
        }

        public void OnDisable()
        {
            _twitchApi = null;
        }

        public string GetName()
        {
            return "TwitchPlugin";
        }

        public TwitchAPI GetAPI()
        {
            return _twitchApi;
        }
    }
}