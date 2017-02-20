using C_sharpModule.twitchapi.api;
using Newtonsoft.Json.Linq;

namespace C_sharpModule.twitchapi.impl
{
    public class PreviewImageUrlsImpl : PreviewImageUrls
    {
        private JObject jsonObject;

        public PreviewImageUrlsImpl(JObject jsonObject)
        {
            this.jsonObject = (JObject) jsonObject?.GetValue("preview");
        }

        public string GetUrlSmall()
        {
            return (string) jsonObject.GetValue("small");
        }

        public string GetUrlMedium()
        {
            return (string) jsonObject.GetValue("medium");
        }

        public string GetUrlLarge()
        {
            return (string) jsonObject.GetValue("large");
        }

        public string GetUrlWith(int width, int height)
        {
            return ((string) jsonObject.GetValue("template")).Replace("{width}", width.ToString())
                .Replace("{height}", height.ToString());
        }

        public static bool IsAvailable(JObject jsonObject)
        {
            return jsonObject.GetValue("preview") != null;
        }
    }
}