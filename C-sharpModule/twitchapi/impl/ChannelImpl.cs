using System.Runtime.Serialization;

namespace C_sharpModule.twitchapi.impl
{
    [DataContract]
    public class ChannelImpl
    {
        [DataMember(Name = "mature")]
        public bool isMature { get; set; }

        [DataMember(Name = "partner")]
        public bool isPartner { set; get; }

        [DataMember(Name = "status")]
        public string getStatus { set; get; }

        [DataMember(Name = "display_name")]
        public string getDisplayName { set; get; }

        [DataMember(Name = "broadcaster_language")]
        public string getBroadcasterLanguage { set; get; }

        [DataMember(Name = "game")]
        public string getGameName { set; get; }

        [DataMember(Name = "language")]
        public string getLanguage { set; get; }

        [DataMember(Name = "_id")]
        public long getID { set; get; }

        [DataMember(Name = "name")]
        public string getStreamersName { get; set; }

        [DataMember(Name = "created_at")]
        public string getCreatedAt { set; get; }

        [DataMember(Name = "updated_at")]
        public string getUpdatedAt { set; get; }
    }
}