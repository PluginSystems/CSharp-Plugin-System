namespace C_sharpModule.twitchapi.api
{
    public interface Stream
    {
        long GetId();
        string GetGameName();
        long GetViewerCount();
        long GetVideoHeight();
        long GetAverageFps();
        long GetDelay();
        string GetCreatedAt();
        bool IsLivePlaylist();
        PreviewImageUrls GetPreview();
        Channel GetChannel();
    }
}