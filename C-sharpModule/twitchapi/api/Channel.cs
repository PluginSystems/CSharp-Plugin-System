namespace C_sharpModule.twitchapi.api
{
    public interface Channel
    {
        bool IsMature();
        bool IsPartner();
        string GetStatus();
        string GetBroadcasterLanguage();
        string GetDisplayname();
        string GetGameName();
        string GetLanguage();
        long GetID();
        string GetStreamersName();
        string GetCreatedAt();
        string GetUpdatedAt();
    }
}