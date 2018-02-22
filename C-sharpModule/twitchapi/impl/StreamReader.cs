using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace C_sharpModule.twitchapi.impl
{
    public class StreamReader
    {
        public StreamReader(HttpWebResponse httpResponse)
        {
            if (httpResponse.StatusCode != HttpStatusCode.OK) return;
            var reader = new System.IO.StreamReader(httpResponse.GetResponseStream());
            var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(reader.ReadToEnd())) {Position = 0};

            var jss = new DataContractJsonSerializer(typeof(DummyStream));
            _streamResponseImplementation = (DummyStream) jss.ReadObject(memoryStream);
            httpResponse.Close();
        }

        public DummyStream _streamResponseImplementation { get; }
    }
}