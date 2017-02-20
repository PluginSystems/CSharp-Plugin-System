using C_sharpModule.twitchapi.api;
using Newtonsoft.Json.Linq;

namespace C_sharpModule.twitchapi.impl
{
    public class StreamImpl : Stream
    {
        private readonly JObject _jsonObject;
        private readonly PreviewImageUrls _previewImageUrls;
        private readonly Channel _channel;

        public StreamImpl(JObject jsonObject)
        {
            _jsonObject = (JObject) jsonObject.GetValue("stream");
            _previewImageUrls = PreviewImageUrlsImpl.IsAvailable(_jsonObject)
                ? new PreviewImageUrlsImpl(_jsonObject)
                : null;
            _channel = ChannelImpl.IsAvailable(_jsonObject) ? new ChannelImpl(_jsonObject) : null;
        }

        public long GetID()
        {
            return (long) _jsonObject.GetValue("_id");
        }

        public string GetGameName()
        {
            return (string) _jsonObject.GetValue("game");
        }

        public long GetViewerCount()
        {
            return (long) _jsonObject.GetValue("viewers");
        }

        public long GetVideoHeight()
        {
            return (long) _jsonObject.GetValue("video_height");
        }

        public long GetAverageFPS()
        {
            return (long) _jsonObject.GetValue("average_fps");
        }

        public long GetDelay()
        {
            return (long) _jsonObject.GetValue("delay");
        }

        public string GetCreatedAt()
        {
            return (string) _jsonObject.GetValue("created_at");
        }

        public bool IsLivePlaylist()
        {
            return (bool) _jsonObject.GetValue("is_playlist");
        }

        public PreviewImageUrls GetPreview()
        {
            return _previewImageUrls;
        }

        public Channel GetChannel()
        {
            return _channel;
        }

        public static bool IsAvailable(JObject jsonObject)
        {
            return jsonObject.GetValue("stream") != null;
        }
    }
}