using System.Collections.Generic;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    public class ResourceLoader : ISaveDataLoader
    {
        public const string KEY = "resources";
        public List<Resource> Resources { get; set; }

        public ResourceLoader()
        {
            Resources = MainManager.ResourceManager.GetResources();
        }

        public void Load(string loader)
        {
            var resourceLoader = JsonConvert.DeserializeObject<ResourceLoader>(loader);
            
            Resources = resourceLoader is null? Resources : resourceLoader.Resources;
            MainManager.ResourceManager.SetResources(Resources);
        }
    }
}
