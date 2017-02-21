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
            // todo rewriting TwichAPI for C#
            Console.Out.WriteLine("Hey Ho from TwitchPlugin");

            Console.WriteLine("Spiel: "+GetAPI().getSyncTwitchConnector().connectToStream("gronkh")._streamResponseImplementation.stream.GetGameName());
        }

        public void OnDisable()
        {
            _twitchApi = null;
            Console.Out.WriteLine("Goodbye from TwichPlugin");
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