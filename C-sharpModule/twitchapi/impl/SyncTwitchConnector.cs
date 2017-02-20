using System.Net;
using C_sharpModule.twitchapi.api;

namespace C_sharpModule.twitchapi.impl
{
    public class SyncTwitchConnector
    {
        private string clientID;

        public SyncTwitchConnector(string clientID)
        {
            this.clientID = clientID;
        }

        public bool isStreamingOnline(string twitchUserName)
        {
            return connectToStream(twitchUserName).GetStream() != null;
        }

        public StreamResponse connectToStream(string twitchUserName)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(
                "https://api.twitch.tv/kraken/streams/" + twitchUserName + "?client_id=" +
                clientID);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

            return new StreamResponseImplementation(response);
        }
    }
}