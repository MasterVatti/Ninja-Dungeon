using Newtonsoft.Json;

namespace SaveSystem
{
    public class SaveBuildings
    {
        [JsonProperty("buildings")]
        public BuildingData[] Buildings { get; }

        public SaveBuildings(BuildingData[] buildings)
        {
            Buildings = buildings;
        }
    }
}