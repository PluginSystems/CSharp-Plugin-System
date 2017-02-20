namespace C_sharpModule.twitchapi.api
{
    public interface Channel
    {
        bool isMature();
        bool isPartner();
        string getStatus();
        string getBroadcasterLanguage();
        string getDisplayname();
        string getGameName();
        string getLanguage();
        long getID();
        string getStreamersName();
        string getCreatedAt();
        string getUpdatedAt();
    }
}