namespace SaveSystem
{
    public interface ISaveDataLoader
    {
        void Load(string loader, DefaultSaveConfig saveConfig);
    }
}
