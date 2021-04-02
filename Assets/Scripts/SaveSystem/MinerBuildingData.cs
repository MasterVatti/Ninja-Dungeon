using System;
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
            get => Convert.ToSingle(State["startTime"]);
            set => State.Add("startTime", value);
        }
        [JsonIgnore]
        public int ResourceCount
        {
            get => Convert.ToInt32(State["resourceCount"]);
            set => State.Add("resourceCount", value);
        }
        [JsonIgnore]
        public float MiningPerSecond
        {
            get => Convert.ToSingle(State["perSecond"]);
            set => State.Add("perSecond", value);
        }
        [JsonIgnore]
        public int MaxStorage
        {
            get => Convert.ToInt32(State["storage"]);
            set => State.Add("storage", value);
        }
        
    }
}
