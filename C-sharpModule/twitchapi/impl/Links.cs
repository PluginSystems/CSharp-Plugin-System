using System.Runtime.Serialization;

namespace C_sharpModule.twitchapi.impl
{
    [DataContract]
    public class Links
    {
        [DataMember(Name = "self")] public string self { set; get; }

        [DataMember(Name = "channel")] public string channel { set; get; }
    }
}