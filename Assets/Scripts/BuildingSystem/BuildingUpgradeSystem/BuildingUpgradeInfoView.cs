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
        protected Building<T> building;
        
        protected BuildingSettings buildingSettings;

        [SerializeField]
        private UpgradeInfoDisplay _upgradeInfoDisplay;
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
        }

        private void Update()
        {
            if (buildingSettings == null)
            {
                SetBuildingSettings();
            }
            
            var buildingLevel = building.CurrentBuildingLevel + 1;

            if (IsMaxLevel())
            {
                _upgradeInfoDisplay.MaxLevelWarning.gameObject.SetActive(true);
                return;
            }

            var upgradeCost = buildingSettings.UpgradeList[buildingLevel].UpgradeCost;
            var playerHasEnoughMoney = MainManager.ResourceManager.HasEnough(upgradeCost);
            
            _upgradeInfoDisplay.ActiveButton.gameObject.SetActive(playerHasEnoughMoney);
        }

        public void OnUpgradeClick()
        {
            building.Upgrade();
        }

        protected abstract Dictionary<string, int> GetStateDictionary(bool isNextLevelState = false);

        private bool IsMaxLevel()
        {
            return buildingSettings.UpgradeList.Count <= building.CurrentBuildingLevel + 1;
        }
        
        protected void ShowUpgradeInfo()
        {
            var oldState = GetStateDictionary();
            var newState = GetStateDictionary(true);
            _upgradeInfoDisplay.ShowUpgradeInfo(building, buildingSettings, oldState, newState);
        }

        protected void SetBuildingSettings()
        {
            buildingSettings = MainManager.BuildingManager.GetBuildingSettings(building.BuildingSettingsID);
        }
    }
}
