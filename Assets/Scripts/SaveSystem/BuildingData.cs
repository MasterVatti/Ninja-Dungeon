using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    /// <summary>
    /// Класс для сохранения зданий всех типов
    /// </summary>
    [Serializable]
    public class BuildingData
    {
        [JsonProperty("built")]
        public bool IsBuilt
        {
            get => _isBuilt;
            set => _isBuilt = value;
        }

        [JsonProperty("settingsID")]
        public int SettingsID
        {
            get => _settingsID;
            set => _settingsID = value;
        }

        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonIgnore]
        [SerializeField]
        private bool _isBuilt;
        [JsonIgnore]
        [SerializeField]
        private int _settingsID;
    }
}
