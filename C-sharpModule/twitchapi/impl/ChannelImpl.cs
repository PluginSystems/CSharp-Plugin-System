using System;
using C_sharpModule.twitchapi.api;

namespace C_sharpModule.twitchapi.impl
{
    public class ChannelImpl : Channel
    {
        private JSONObject jsonObject;
        private PreviewImageUrls previewImageUrls;
        private Channel channel;
        public StreamImpl(JSONObject jsonObject) {
            this.jsonObject = (JSONObject) jsonObject.get("stream");
            previewImageUrls= PreviewImageUrlsImpl.isAvailable(this.jsonObject)?new PreviewImageUrlsImpl(this.jsonObject):null;
            channel = isAvailable(this.jsonObject)?new ChannelImpl(this.jsonObject):null;
        }
        public long getID() {
            return (long) jsonObject.get("_id");
        }
        public string getGameName() {
            return (string) jsonObject.get("game");
        }
        public long getViewerCount() {
            return (long) jsonObject.get("viewers");
        }
        public long getVideoHeight() {
            return (long)jsonObject.get("video_height");
        }
        public long getAverageFPS() {
            return (long)jsonObject.get("average_fps");
        }
        public long getDelay() {
            return (long)jsonObject.get("delay");
        }
        public string getCreatedAt() {
            return (string) jsonObject.get("created_at");
        }
        public bool isLivePlaylist() {
            return (bool)jsonObject.get("is_playlist");
        }
        public PreviewImageUrls getPreview() {
            return previewImageUrls;
        }
        public Channel getChannel() {
            return channel;
        }
        public static bool isAvailable(JSONObject jsonObject){
            return jsonObject.get("stream")!=null;
        }


        private JSONObject jsonObject;
        public ChannelImpl(JSONObject jsonObject) {
            this.jsonObject= jsonObject!=null?(JSONObject) jsonObject.get("channel"):null;
        }
        public bool IsMature() {
            return (bool) jsonObject.get("mature");
        }
        public bool IsPartner() {
            return (bool) jsonObject.get("partner");
        }
        public string GetStatus() {
            return (string) jsonObject.get("status");
        }
        public string GetBroadcasterLanguage() {
            return (string) jsonObject.get("broadcaster_language");
        }
        public string GetDisplayname() {
            return jsonObject.get("display_name") as string;
        }
        public string GetGameName() {
            return (string) jsonObject.get("game");
        }
        public string GetLanguage() {
            return (string) jsonObject.get("language");
        }
        public long GetID() {
            return (long) jsonObject.get("_id");
        }
        public string GetStreamersName() {
            return (string) jsonObject.get("name");
        }
        public string GetCreatedAt() {
            return (string) jsonObject.get("created_at");
        }
        public string GetUpdatedAt() {
            return (string) jsonObject.get("updated_at");
        }
        public JSONObject Unsafe(){
            return (JSONObject) jsonObject.clone();
        }
        public static bool IsAvailable(JSONObject jsonObject){
            return jsonObject.get("channel")!=null;
        }




    }
}