namespace C_sharpModule.twitchapi.api
{
    public interface Stream
    {
        long GetID();
        string GetGameName();
        long GetViewerCount();
        long GetVideoHeight();
        long GetAverageFPS();
        long GetDelay();
        string GetCreatedAt();
        bool IsLivePlaylist();
        PreviewImageUrls GetPreview();
        Channel GetChannel();
    }
}