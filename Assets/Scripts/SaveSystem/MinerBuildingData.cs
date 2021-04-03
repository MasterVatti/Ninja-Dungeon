using Newtonsoft.Json;

namespace SaveSystem
{
    /// <summary>
    /// Информация для сохранения здания типа Miner
    /// </summary>
    public class MinerBuildingData : BaseBuildingState
    {
        [JsonProperty("startTime")]
        public float StartTime { get; set; }
        [JsonProperty("miningPerSecond")]
        public float MiningPerSecond { get; set; }
        [JsonProperty("resourceCount")]
        public int ResourceCount { get; set; }
        [JsonProperty("maxStorage")]
        public int MaxStorage { get; set; }
        [JsonProperty("resourceType")]
        public ResourceSystem.ResourceType Resource { get; set; }
    }
}
