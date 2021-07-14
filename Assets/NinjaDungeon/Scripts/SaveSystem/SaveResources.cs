using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    public class SaveResources
    {
        [JsonProperty("resources")]
        public Resource[] Resources { get; }

        public SaveResources(Resource[] resources)
        {
            Resources = resources;
        }
    }
}