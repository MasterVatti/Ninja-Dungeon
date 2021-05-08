using System.Collections.Generic;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Класс отображающий информацию об улучшении
    /// </summary>
    public class UpgradeInfoDisplay : MonoBehaviour
    {
        [Header("Displays")]
        [SerializeField]
        private UpgradeCostDisplay _costDisplay;
        [SerializeField]
        private UpgradeDifferenceDisplay _differenceDisplay;

        [Header("UI labels")]
        [SerializeField]
        private TextMeshProUGUI _nameLabel;
        [SerializeField]
        private TextMeshProUGUI _currentLevelLabel;
        [SerializeField]
        private TextMeshProUGUI _nextLevelLabel;

        public void ShowUpgradeInfo<T>(Building<T> building, BuildingSettings buildingSettings, Dictionary<string, int> 
        oldStateDictionary, Dictionary<string, int> newStateDictionary) where T : BaseBuildingState
        {
            _nameLabel.text = buildingSettings.BuildingName;
            
            var buildingLevel = building.CurrentBuildingLevel;
            _currentLevelLabel.text = buildingLevel.ToString();
            var buildingNextLevel = buildingLevel + 1;
            _nextLevelLabel.text = buildingNextLevel.ToString();

            var buildingUpgrade = buildingSettings.UpgradeList[buildingNextLevel];
            _costDisplay.ShowUpgradeCost(buildingUpgrade);
            _differenceDisplay.ShowUpgradeDifference(oldStateDictionary, newStateDictionary);
        }
    }
}
