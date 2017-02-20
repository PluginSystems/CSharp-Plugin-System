using System.Net;
using C_sharpModule.twitchapi.api;
using Newtonsoft.Json.Linq;

namespace C_sharpModule.twitchapi.impl
{
    public class StreamResponseImplementation : StreamResponse
    {
        private JObject jsonObject;
        private readonly Stream _stream;
        private HttpWebResponse _httpWebResponse;

        public StreamResponseImplementation(HttpWebResponse httpResponse)
        {
            _httpWebResponse = httpResponse;
            if (httpResponse.StatusCode != HttpStatusCode.Accepted) return;

            jsonObject = JObject.Parse(httpResponse.GetResponseStream().ToString());
            if (StreamImpl.IsAvailable(jsonObject))
            {
                _stream = new StreamImpl(jsonObject);
            }

            httpResponse.Close();
        }

        public Stream GetStream()
        {
            return _stream;
        }

        public HttpStatusCode GetConnectionStatus()
        {
            return _httpWebResponse.StatusCode;
        }
    }
}