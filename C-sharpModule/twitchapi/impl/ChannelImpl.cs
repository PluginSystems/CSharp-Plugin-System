using System;
using C_sharpModule.twitchapi.api;
using Newtonsoft.Json.Linq;

namespace C_sharpModule.twitchapi.impl
{
    public class ChannelImpl : Channel
    {

        private JObject jsonObject;
        public ChannelImpl(JObject jsonObject) {
            this.jsonObject= (JObject) jsonObject?.GetValue("channel");
        }
        public bool IsMature() {
            return (bool) jsonObject.GetValue("mature");
        }
        public bool IsPartner() {
            return (bool) jsonObject.GetValue("partner");
        }
        public string GetStatus() {
            return (string) jsonObject.GetValue("status");
        }
        public string GetBroadcasterLanguage() {
            return (string) jsonObject.GetValue("broadcaster_language");
        }
        public string GetDisplayname() {
            return (string) jsonObject.GetValue("display_name");
        }
        public string GetGameName() {
            return (string) jsonObject.GetValue("game");
        }
        public string GetLanguage() {
            return (string) jsonObject.GetValue("language");
        }
        public long GetID() {
            return (long) jsonObject.GetValue("_id");
        }
        public string GetStreamersName() {
            return (string) jsonObject.GetValue("name");
        }
        public string GetCreatedAt() {
            return (string) jsonObject.GetValue("created_at");
        }
        public string GetUpdatedAt() {
            return (string) jsonObject.GetValue("updated_at");
        }
        public JObject Unsafe()
        {
            return (JObject) jsonObject.DeepClone();
        }
        public static bool IsAvailable(JObject jsonObject){
            return jsonObject.GetValue("channel")!=null;
        }
    }
}