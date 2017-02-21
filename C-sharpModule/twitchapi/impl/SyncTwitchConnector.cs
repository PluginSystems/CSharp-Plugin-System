using System;
using System.Net;

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
            return connectToStream(twitchUserName)._streamResponseImplementation != null;
        }

        public StreamReader connectToStream(string twitchUserName)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(
                "https://api.twitch.tv/kraken/streams/" + twitchUserName + "?client_id=" +
                clientID);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();


            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());

            Console.WriteLine(reader.ReadToEnd());
            return new StreamReader(response);
        }
    }
}