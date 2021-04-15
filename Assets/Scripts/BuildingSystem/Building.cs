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
        public T State { get; protected set; }

        public int BuildingSettingsID { get; set; }

        public void Initialize(string savedData)
        {
            State = JsonConvert.DeserializeObject<T>(savedData);
            Initialize(State);
        }

        public void Initialize(int buildingSettingsID)
        {
            BuildingSettingsID = buildingSettingsID;
        }

        protected abstract void StateInitialize();

        public BuildingData Save()
        {
            StateInitialize();
            return new BuildingData
            {
                SettingsID = BuildingSettingsID,
                State = JsonConvert.SerializeObject(State)
            };
        }

        protected abstract void Initialize(T data);
    }
}
