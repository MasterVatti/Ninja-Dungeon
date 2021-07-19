using Newtonsoft.Json;


namespace SaveSystem
{ 
    public class BarrackData : BaseBuildingState
    {
        [JsonProperty("createdAlly")]
        public int ID { get; set; }
    }
}