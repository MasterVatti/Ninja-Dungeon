using Newtonsoft.Json;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Базовый класс для всех зданий, у которых есть какой-то функционал
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Building<T> : MonoBehaviour, IBuildingSaver where T : BaseBuildingState
    {
        public int BuildingSettingsID { get; set; }
        
        protected T _state;

        public void Initialize(string savedData)
        {
            _state = JsonConvert.DeserializeObject<T>(savedData);
            Initialize(_state);
        }
        
        public virtual BuildingData Save()
        {
            return new BuildingData
            {
                IsBuilt = true,
                SettingsID = BuildingSettingsID,
                State = JsonConvert.SerializeObject(_state)
            };
        }

        protected abstract void Initialize(T data);
    }
}
