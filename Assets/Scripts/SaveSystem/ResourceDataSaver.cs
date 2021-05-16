using System.Collections.Generic;
using Assets.Scripts;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    public class ResourceDataSaver : IDataSaver<List<Resource>>
    {
        public const string KEY = GlobalConstants.RESOURCE_KEY;

        [JsonProperty(KEY)]
        public List<Resource> SaveData { get; private set; } = new List<Resource>();

        public void Save()
        {
            SaveData.Clear();
            SaveData = MainManager.ResourceManager.GetResources();
        }
    }
}
