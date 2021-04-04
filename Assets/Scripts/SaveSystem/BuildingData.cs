﻿using Newtonsoft.Json;

namespace SaveSystem
{
    /// <summary>
    /// Класс для сохранения зданий всех типов
    /// </summary>
    public class BuildingData
    {
        [JsonProperty("built")]
        public bool IsBuilt { get; set; }
        [JsonProperty("settingsID")]
        public int SettingsID { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}