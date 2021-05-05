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
        [Header("ElementPrefabs")]
        [SerializeField]
        private GameObject _textLabel;
        [SerializeField]
        private GameObject _image;

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

        private ObjectPool _labelPool;
        private ObjectPool _imagePool;

        public void ShowUpgradeInfo<T>(Building<T> building, BuildingSettings buildingSettings, Dictionary<string, int> 
        oldStateDictionary, Dictionary<string, int> newStateDictionary) where T : BaseBuildingState
        {
            InitializeObjectPools();
            
            _nameLabel.text = buildingSettings.BuildingName;
            
            var buildingLevel = building.CurrentBuildingLevel;
            _currentLevelLabel.text = buildingLevel.ToString();
            var buildingNextLevel = buildingLevel + 1;
            _nextLevelLabel.text = buildingNextLevel.ToString();

            var buildingUpgrade = buildingSettings.UpgradeList[buildingNextLevel];
            _costDisplay.Initialize(_imagePool, _labelPool);
            _costDisplay.ShowUpgradeCost(buildingUpgrade);
            
            _differenceDisplay.Initialize(_labelPool);
            _differenceDisplay.ShowUpgradeDifference(oldStateDictionary, newStateDictionary);
        }

        private void InitializeObjectPools()
        {
            _labelPool = new ObjectPool(_textLabel);
            _imagePool = new ObjectPool(_image, 1);
        }
    }
}
