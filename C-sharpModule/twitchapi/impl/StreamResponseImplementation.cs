using System.Runtime.Serialization;

namespace C_sharpModule.twitchapi.impl
{
    [DataContract]
    public class StreamResponseImplementation
    {
        [DataMember(Name = "stream")] public StreamImpl stream { get; set; }
    }
}