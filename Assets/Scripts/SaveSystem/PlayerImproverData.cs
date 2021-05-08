using Newtonsoft.Json;

namespace SaveSystem
{
    public class PlayerImproverData : BaseBuildingState
    {
        [JsonProperty("hpPerPoint")]
        public int HpPerPoint { get; set; }
        [JsonProperty("attackPerPoint")]
        public int AttackPerPoint { get; set; }
        [JsonProperty("attackSpeedPerPoint")]
        public float AttackSpeedPerPoint { get; set; }
        [JsonProperty("movementSpeedPerPoint")]
        public float MovementSpeedPerPoint { get; set; }
    }
}
