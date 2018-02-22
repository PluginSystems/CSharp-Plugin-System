using C_sharpModule.twitchapi.impl;

namespace C_sharpModule.twitchapi
{
    public class TwitchAPI
    {
        private readonly string _clientId;

        public TwitchAPI(string clientID)
        {
            _clientId = clientID;
            _syncTwitchConnector = new SyncTwitchConnector(_clientId);
        }

        public SyncTwitchConnector _syncTwitchConnector { get; }

        public bool hasConnectedTwitchAcount(string twitchUserName)
        {
            return _syncTwitchConnector.connectToStream(twitchUserName)._streamResponseImplementation != null;
        }
    }
}