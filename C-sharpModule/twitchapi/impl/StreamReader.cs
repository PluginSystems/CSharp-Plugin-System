using System.Net;
using System.Runtime.Serialization.Json;

namespace C_sharpModule.twitchapi.impl
{
    public class StreamReader
    {
        private HttpWebResponse _httpWebResponse;
        public StreamResponseImplementation _streamResponseImplementation { get; }

        public StreamReader(HttpWebResponse httpResponse)
        {

            _httpWebResponse = httpResponse;
            if (httpResponse.StatusCode != HttpStatusCode.Accepted) return;

            var jss = new DataContractJsonSerializer(typeof(StreamResponseImplementation));
            _streamResponseImplementation = (StreamResponseImplementation) jss.ReadObject(_httpWebResponse.GetResponseStream());
            httpResponse.Close();
        }
    }
}