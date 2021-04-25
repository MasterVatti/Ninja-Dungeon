﻿using BuildingSystem.BuildingUpgradeSystem;
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

        protected bool stateWasLoaded;

        [SerializeField]
        private Transform _positionUI;

        public void OnStateLoaded(int buildingSettingsID, int level)
        {
            stateWasLoaded = true;
            BuildingSettingsID = buildingSettingsID;
            CurrentBuildingLevel = level;
        }
        
        public void Upgrade()
        {
            BuildingUpgradeHelper.Upgrade(this);
        }
        
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

        public void LoadState(string savedData)
        {
            var state = JsonConvert.DeserializeObject<T>(savedData);
            OnStateLoaded(state);
        }
        
        public abstract void OnUpgrade(T oldBuildingState);

        public abstract T GetState();
        
        protected abstract void OnStateLoaded(T data);
    }
}
