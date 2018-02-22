using System.Runtime.Serialization;

namespace C_sharpModule.twitchapi.impl
{
    [DataContract]
    public class PreviewImageUrlsImpl
    {
        [DataMember(Name = "small")] public string getUrlSmall { set; get; }

        [DataMember(Name = "medium")] public string getUrlMedium { set; get; }

        [DataMember(Name = "large")] public string getUrlLarge { set; get; }

        [DataMember(Name = "template")] public string getTemplate { set; get; }

        public string GetUrlWith(int width, int height)
        {
            return getTemplate.Replace("{width}", width.ToString())
                .Replace("{height}", height.ToString());
        }
    }
}