using Newtonsoft.Json;

namespace SaveSystem
{
    /// <summary>
    /// Информация для сохранения здания типа Miner
    /// </summary>
    public class MinerBuildingData : BuildingData
    {
        [JsonIgnore]
        public float StartTime
        {
            set => State.Add("startTime", value);
        }

        [JsonIgnore]
        public int ResourceCount
        {
            set => State.Add("resourceCount", value);
        }

        [JsonIgnore]
        public float MiningPerSecond
        {
            set => State.Add("perSecond", value);
        }

        [JsonIgnore]
        public int MaxStorage
        {
            set => State.Add("storage", value);
        }
        
    }
}
