using System.Runtime.Serialization;

namespace C_sharpModule.twitchapi.impl
{
    [DataContract]
    public class DummyStream
    {
        [DataMember(Name = "stream")] public StreamImpl stream { protected set; get; }

        [DataMember(Name = "_links")] public Links links { set; get; }
    }
}