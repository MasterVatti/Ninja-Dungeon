using Newtonsoft.Json;

namespace SaveSystem
{
    public class TowerData : BaseBuildingState
    {
        [JsonProperty("damage")]
        public int Damage { get; set; }
        [JsonProperty("attackCooldown")]
        public float AttackCooldown { get; set; }
        [JsonProperty("attackRange")]
        public float AttackRange { get; set; }
    }
}
