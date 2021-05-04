using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Базовый класс для экранов-улучшений
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BuildingUpgradeInfoView<T> : BaseScreenWithContext<UpgradeContext<T>> where T : BaseBuildingState
    {
        [SerializeField]
        private UpgradeInfoDisplay _upgradeInfoDisplay;
        
        private Building<T> _building;
        private BuildingSettings _buildingSettings;

        private void Update()
        {
            if (_buildingSettings == null)
            {
                SetBuildingSettings();
            }
            
            var buildingLevel = _building.CurrentBuildingLevel + 1;

            if (IsMaxLevel())
            {
                _upgradeInfoDisplay.MaxLevelWarning.gameObject.SetActive(true);
                return;
            }

            var upgradeCost = _buildingSettings.UpgradeList[buildingLevel].UpgradeCost;
            var playerHasEnoughMoney = MainManager.ResourceManager.HasEnough(upgradeCost);
            
            _upgradeInfoDisplay.ActiveButton.gameObject.SetActive(playerHasEnoughMoney);
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        public override void ApplyContext(UpgradeContext<T> context)
        {
            _building = context.Building;
            SetBuildingSettings();
            ShowUpgradeInfo();
        }

        public void OnUpgradeClick()
        {
            _building.Upgrade();
        }

        protected abstract Dictionary<string, int> GetBuildingStateAsDictionary(T state);

        private Dictionary<string, int> GetCurrentBuildingState()
        {
            var state = _building.GetState();
            
            return GetBuildingStateAsDictionary(state);
        }

        private Dictionary<string, int> GetNextUpgradeState()
        {
            var nextLevel = _building.CurrentBuildingLevel + 1;
            var building = _buildingSettings.UpgradeList[nextLevel].UpgradePrefab;
            var state = building.GetComponent<Building<T>>().GetState();

            return GetBuildingStateAsDictionary(state);
        }

        private bool IsMaxLevel()
        {
            return _buildingSettings.UpgradeList.Count <= _building.CurrentBuildingLevel + 1;
        }
        
        private void ShowUpgradeInfo()
        {
            var oldState = GetCurrentBuildingState();
            var newState = GetNextUpgradeState();
            _upgradeInfoDisplay.ShowUpgradeInfo(_building, _buildingSettings, oldState, newState);
        }

        private void SetBuildingSettings()
        {
            _buildingSettings = MainManager.BuildingManager.GetBuildingSettings(_building.BuildingSettingsID);
        }
    }
}
