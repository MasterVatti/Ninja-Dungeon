using BuildingSystem.BuildingUpgradeSystem;
using Newtonsoft.Json;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Базовый класс для всех зданий, у которых есть какой-то функционал
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Building<T> : MonoBehaviour, IStatefulBuilding<T>, IBuildingUIPositionHolder where T : BaseBuildingState
    {
        public int BuildingSettingsID { get; private set; }
        public int CurrentBuildingLevel { get; private set; }
        public Transform PositionUI => _positionUI;

        [SerializeField]
        private Transform _positionUI;

        public void Initialize(int buildingSettingsID, int level)
        {
            BuildingSettingsID = buildingSettingsID;
            CurrentBuildingLevel = level;
        }

        public void LoadState(string savedData)
        {
            var state = JsonConvert.DeserializeObject<T>(savedData);
            Initialize(state);
        }
        
        public IBuilding Upgrade()
        {
            return BuildingUpgradeHelper.Upgrade(this);
        }

        public abstract void OnUpgrade(T oldBuildingState);

        public abstract T GetState();

        public BuildingData Save()
        {
            var state = GetState() ;
            return new BuildingData
            {
                SettingsID = BuildingSettingsID,
                BuildingLevel = CurrentBuildingLevel,
                State = JsonConvert.SerializeObject(state)
            };
        }

        protected abstract void Initialize(T data);
    }
}
