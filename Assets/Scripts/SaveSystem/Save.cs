using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    public class Save
    {
        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }
        [JsonProperty("buildings")]
        public BuildingData[] Buildings { get; set; }
    }
}
