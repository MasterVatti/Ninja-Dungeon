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
    public abstract class BuildingScreen<T> : BaseScreenWithContext<UpgradeContext<T>> where T : BaseBuildingState
    {
        protected Building<T> building;
        
        protected BuildingSettings buildingSettings;

        [SerializeField]
        private ScreenUpgradeInfo _upgradeInfo;
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
            SetBuildingSettings();
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
                _upgradeInfo.MaxLevelWarning.gameObject.SetActive(true);
                return;
            }
            _upgradeInfo.MaxLevelWarning.gameObject.SetActive(false);

            var upgradeCost = buildingSettings.UpgradeList[buildingLevel].UpgradeCost;
            _upgradeInfo.ActiveButton.gameObject.SetActive(MainManager.ResourceManager.HasEnough(upgradeCost));
        }

        public void OnUpgradeClick()
        {
            building.Upgrade();
        }

        protected abstract Dictionary<string, int> GetStateDictionary(bool isNextLevelState = false);

        protected bool IsMaxLevel()
        {
            return buildingSettings.UpgradeList.Count <= building.CurrentBuildingLevel + 1;
        }
        
        protected void ShowUpgradeInfo()
        {
            var oldState = GetStateDictionary();
            var newState = GetStateDictionary(true);
            _upgradeInfo.ShowUpgradeInfo(building, buildingSettings, oldState, newState);
        }

        protected void SetBuildingSettings()
        {
            buildingSettings = MainManager.BuildingManager.GetBuildingSettings(building.BuildingSettingsID);
        }
    }
}
