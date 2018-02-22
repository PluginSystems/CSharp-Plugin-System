using System.Net;

namespace C_sharpModule.twitchapi.impl
{
    public class SyncTwitchConnector
    {
        private readonly string clientID;

        public SyncTwitchConnector(string clientID)
        {
            this.clientID = clientID;
        }

        public bool isStreamingOnline(string twitchUserName)
        {
            return connectToStream(twitchUserName)._streamResponseImplementation != null;
        }

        public StreamReader connectToStream(string twitchUserName)
        {
            var request = WebRequest.CreateHttp(
                "https://api.twitch.tv/kraken/streams/" + twitchUserName + "?client_id=" +
                clientID);
            var response = (HttpWebResponse) request.GetResponse();

            return new StreamReader(response);
        }
    }
}