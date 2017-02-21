using System.Runtime.Serialization;

namespace C_sharpModule.twitchapi.impl
{
    [DataContract(Name = "stream")]
    //[KnownType(typeof(StreamImpl))]
    public class StreamImpl
    {
        [DataMember(Name = "channel")]
        public ChannelImpl channel { set; get; }

        [DataMember(Name = "preview")]
        public PreviewImageUrlsImpl previewImages { get; set; }

        [DataMember(Name = "_id")]
        public long getID { get; set; }

        [DataMember(Name = "game")]
        public string getGameName { set; get; }


        [DataMember(Name = "viewers")]
        public long getViewerCount { set; get; }

        [DataMember(Name = "video_height")]
        public long getVideoHeight { set; get; }

        [DataMember(Name = "average_fps")]
        public long getAverageFPS { set; get; }

        [DataMember(Name = "delay")]
        public long getDelay { set; get; }

        [DataMember(Name = "created_at")]
        public string getCreatedAt { set; get; }

        [DataMember(Name = "is_playlist")]
        public bool isLivePlaylist { set; get; }
    }
}