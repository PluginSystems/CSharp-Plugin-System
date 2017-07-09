using System;
using C_sharpModule.twitchapi;
using PluginLoader.pluginloading;


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
                                  .connectToStream("deadpine")
                                  ._streamResponseImplementation?.stream?.getGameName);
        }

        public void OnDisable()
        {
            _twitchApi = null;
        }

        public string GetName()
        {
            return "TwitchPlugin";
        }

        public bool IsOnline()
        {
            return _twitchApi._syncTwitchConnector.isStreamingOnline("deadpine");
        }

        public TwitchAPI GetAPI()
        {
            return _twitchApi;
        }
    }
}