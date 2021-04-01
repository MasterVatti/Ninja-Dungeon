using Newtonsoft.Json;

namespace SaveSystem
{
    public class MinerBuildingData : BuildingData
    {
        [JsonIgnore]
        public float StartTime
        {
            set => State.Add("startTime", value);
        }
    }
}
