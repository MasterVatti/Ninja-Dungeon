using System.Collections.Generic;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class BuildingData
    {
        [JsonProperty("built")]
        public bool IsBuilt { get; set; }
        [JsonProperty("settingsID")]
        public int SettingsID { get; set; }

        [JsonProperty("state")]
        public Dictionary<object, object> State { get; protected set; } = new Dictionary<object, object>();
    }
}
