using System.Net;

namespace C_sharpModule.twitchapi.api
{
    public interface StreamResponse
    {
            Stream GetStream();
            HttpStatusCode GetConnectionStatus();
    }
}