using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using SaveSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public abstract class UpgradeScreen<T> : BaseScreenWithContext<UpgradeContext<T>> where T : BaseBuildingState
    {
        protected const int TEXT_LABELS_IN_LINE = 3;

        [SerializeField]
        private TextMeshProUGUI _nameLabel;
        [SerializeField]
        private TextMeshProUGUI _currentLevelLabel;
        [SerializeField]
        private TextMeshProUGUI _nextLevelLabel;
        [SerializeField]
        private List<Image> _resourceIcons;
        [SerializeField]
        private List<TextMeshProUGUI> _resourceLabels;

        protected Building<T> _building;
        private BuildingUpgrade _buildingUpgrade;
        private BuildingSettings _buildingSettings;
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
            SetBuildingUpgrade();
            ShowUpgradeInfo();
        }

        [UsedImplicitly]
        public void OnUpgradeClick()
        {
            BuildingUpgradeHelper.Upgrade(_building);
        }

        protected abstract Dictionary<string, int> GetStateDictionary(T state);
        
        protected abstract Building<T> GetBuilding();

        protected abstract void ShowUpgradeInfo(Dictionary<string, int> upgradeDifference);

        private void ShowUpgradeInfo()
        {
            _nameLabel.text = _buildingSettings.BuildingName;
            
            var buildingLevel = _building.CurrentBuildingLevel;
            _currentLevelLabel.text = buildingLevel.ToString();
            _nextLevelLabel.text = (buildingLevel + 1).ToString();

            for(var i = 0; i < _resourceLabels.Count; i++)
            {
                var resource = _buildingUpgrade.UpgradeCost[i];
                _resourceIcons[i].sprite = MainManager.IconsProvider.GetResourceSprite(resource.Type);
                _resourceLabels[i].text = ((int)resource.Amount).ToString();
            }
            ShowUpgradeInfo(GetUpgradeDifference());
        }

        private Dictionary<string, int> GetUpgradeDifference()
        {
            if (_buildingUpgrade == null)
            {
                SetBuildingUpgrade();
            }
            var differenceProvider = new UpgradeDifferenceProvider<T>(_building, _buildingUpgrade, GetStateDictionary);
            return differenceProvider.GetUpgradeDifference();
        }

        private void SetBuildingUpgrade()
        {
            var settingsID = _building.BuildingSettingsID;
            _buildingSettings = MainManager.BuildingManager.GetBuildingSettings(settingsID);

            var buildingNextLevel = _building.CurrentBuildingLevel + 1;
            _buildingUpgrade = _buildingSettings.UpgradeList[buildingNextLevel];
        }
    }
}
