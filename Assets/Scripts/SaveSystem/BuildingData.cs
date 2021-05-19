using System;
using Newtonsoft.Json;

namespace SaveSystem
{
    /// <summary>
    /// Класс для сохранения зданий всех типов
    /// </summary>
    [Serializable]
    public class BuildingData
    {
        [JsonProperty("settingsID")]
        public int SettingsID { get; set; }
        
        [JsonProperty("buildingLvl")]
        public int BuildingLevel { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
