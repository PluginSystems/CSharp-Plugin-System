﻿using C_sharpModule.twitchapi.impl;

namespace C_sharpModule.twitchapi
{
    public class TwitchAPI
    {
        public SyncTwitchConnector _syncTwitchConnector { get; }
        private string _clientId;

        public TwitchAPI(string clientID)
        {
            _clientId = clientID;
            _syncTwitchConnector = new SyncTwitchConnector(_clientId);
        }

        public bool hasConnectedTwitchAcount(string twitchUserName)
        {
            return _syncTwitchConnector.connectToStream(twitchUserName)._streamResponseImplementation != null;
        }
    }
}