using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    /// <summary>
    /// Представление объекта сохранения
    /// </summary>
    public class Save
    {
        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }
        [JsonProperty("buildings")]
        public BuildingData[] Buildings { get; set; }
    }
}
