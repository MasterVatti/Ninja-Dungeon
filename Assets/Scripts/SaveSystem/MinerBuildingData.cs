using System;
using Newtonsoft.Json;

namespace SaveSystem
{
    /// <summary>
    /// Информация для сохранения здания типа Miner
    /// </summary>
    public class MinerBuildingData : BaseBuildingState
    {
        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }
        [JsonProperty("startAmount")]
        public int StartAmount { get; set; }
        [JsonProperty("miningPerSecond")]
        public float MiningPerSecond { get; set; }
        [JsonProperty("maxStorage")]
        public int MaxStorage { get; set; }
    }
}
