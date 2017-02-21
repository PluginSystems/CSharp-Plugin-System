using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace C_sharpModule.twitchapi.impl
{
    public class StreamReader
    {
        public DummyStream _streamResponseImplementation { get; }

        public StreamReader(HttpWebResponse httpResponse)
        {
            if (httpResponse.StatusCode != HttpStatusCode.OK) return;
            System.IO.StreamReader reader = new System.IO.StreamReader(httpResponse.GetResponseStream());
            MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(reader.ReadToEnd())) {Position = 0};

            var jss = new DataContractJsonSerializer(typeof(DummyStream));
            _streamResponseImplementation = (DummyStream) jss.ReadObject(memoryStream);
            httpResponse.Close();
        }
    }
}