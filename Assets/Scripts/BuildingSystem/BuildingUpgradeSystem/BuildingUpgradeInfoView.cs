using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField]
        private Button _activeButton;
        [SerializeField]
        private Image _maxLevelWarningImage;
        
        private Building<T> _building;
        private BuildingSettings _buildingSettings;

        private void Update()
        {
            if (_buildingSettings == null)
            {
                SetBuildingSettings();
            }

            if (IsMaxLevel())
            {
                _maxLevelWarningImage.gameObject.SetActive(true);
                return;
            }
            
            var buildingLevel = _building.CurrentBuildingLevel + 1;
            var upgradeCost = _buildingSettings.UpgradeList[buildingLevel].UpgradeCost;
            var playerHasEnoughMoney = MainManager.ResourceManager.HasEnough(upgradeCost);
            
            _activeButton.gameObject.SetActive(playerHasEnoughMoney);
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
            MainManager.ScreenManager.CloseTopScreen();
        }

        protected abstract Dictionary<string, int> ParseStateToDictionary(T state);

        private Dictionary<string, int> ParseCurrentBuildingState()
        {
            var state = _building.GetState();
            
            return ParseStateToDictionary(state);
        }

        private Dictionary<string, int> ParseNextUpgradeState()
        {
            var nextLevel = _building.CurrentBuildingLevel + 1;
            var building = _buildingSettings.UpgradeList[nextLevel].UpgradePrefab;
            var state = building.GetComponent<Building<T>>().GetState();

            return ParseStateToDictionary(state);
        }

        private bool IsMaxLevel()
        {
            return _buildingSettings.UpgradeList.Count <= _building.CurrentBuildingLevel + 1;
        }
        
        private void ShowUpgradeInfo()
        {
            if (!IsMaxLevel())
            {
                var oldState = ParseCurrentBuildingState();
                var newState = ParseNextUpgradeState();
                _upgradeInfoDisplay.ShowUpgradeInfo(_building, _buildingSettings, oldState, newState);
            }
        }

        private void SetBuildingSettings()
        {
            _buildingSettings = MainManager.BuildingManager.GetBuildingSettings(_building.BuildingSettingsID);
        }
    }
}