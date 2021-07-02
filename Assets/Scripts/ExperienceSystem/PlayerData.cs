using System;
using Newtonsoft.Json;

namespace ExperienceSystem
{
    [Serializable]
    public class PlayerData
    {
        [JsonProperty("levelUpperWorld")] 
        public int LevelUpperWorld { get; set; }
        [JsonProperty("MaximumExperienceLevelUpperWorld")]
        public int MaximumExperienceLevelUpperWorld { get; set; }
        [JsonProperty("ExperienceUpperWorld")]
        public int ExperienceUpperWorld { get; set; }
    }
}