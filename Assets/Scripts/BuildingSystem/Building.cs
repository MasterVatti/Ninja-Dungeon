using Newtonsoft.Json;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Базовый класс для всех зданий, у которых есть какой-то функционал
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Building<T> : MonoBehaviour, IBuilding where T : BuildingData
    {
        protected T state;

        public virtual void Initialize(string savedData)
        {
            state = JsonConvert.DeserializeObject<T>(savedData);
        }

        public virtual BuildingData Save()
        {
           return new BuildingData
               {
                   IsBuilt = state.IsBuilt,
                   SettingsID = state.SettingsID,
                   State = state.State
               };
        }
    }
}
