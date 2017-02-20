namespace C_sharpModule.twitchapi.api
{
    public interface PreviewImageUrls
    {
        string GetUrlSmall();
        string GetUrlMedium();
        string GetUrlLarge();
        string GetUrlWith(int width, int height);
    }
}