using System.Collections.Generic;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    public class ResourceLoader : ISaveDataLoader
    {
        public const string KEY = "resources";
        
        [JsonProperty(KEY)]
        public List<Resource> Resources { get; set; }

        public void Load(string loader, DefaultSaveConfig saveConfig)
        {
            var resourceLoader = JsonConvert.DeserializeObject<ResourceLoader>(loader);
            
            Resources = resourceLoader is null? saveConfig.Resources : resourceLoader.Resources;
            MainManager.ResourceManager.SetResources(Resources);
        }
    }
}
