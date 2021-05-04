using System.Collections.Generic;
using System.Linq;
using ResourceSystem;
using SaveSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Класс отображающий информацию об улучшении
    /// </summary>
    public class UpgradeInfoDisplay : MonoBehaviour
    {
        private readonly List<Resource> _requiredResources = new List<Resource>();
        private readonly List<TextMeshProUGUI> _currentResourceLabels = new List<TextMeshProUGUI>();
        
        public Button ActiveButton => _activeButton;
        public Image MaxLevelWarning => _maxLevelWarningImage;

        [SerializeField]
        private TextMeshProUGUI _nameLabel;
        [SerializeField]
        private TextMeshProUGUI _currentLevelLabel;
        [SerializeField]
        private TextMeshProUGUI _nextLevelLabel;

        [Header("UpgradeButton")]
        [SerializeField]
        private Button _activeButton;


        [Header("Resource template")]
        [SerializeField]
        private Transform _resourceParent;
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _currentAmount;
        [SerializeField]
        private TextMeshProUGUI _requiredAmount;

        [Header("Difference line template")]
        [SerializeField]
        private Transform _differenceParent;
        [SerializeField]
        private TextMeshProUGUI _keyLabel;
        [SerializeField]
        private TextMeshProUGUI _newParameter;
        [SerializeField]
        private TextMeshProUGUI _newParameterDifference;

        [Header("MaxLevelWarning")]
        [SerializeField]
        private Image _maxLevelWarningImage;

        private Dictionary<string, int> _oldStateDictionary;
        private Dictionary<string, int> _newStateDictionary;

        private void Update()
        {
            for(var i = 0; i < _requiredResources.Count; i++)
            {
                var currentResource = MainManager.ResourceManager.GetResourceByType(_requiredResources[i].Type);
                var requiredAmount = _requiredResources[i].Amount;
                var currentAmount = Mathf.Clamp(currentResource.Amount, 0, requiredAmount);
                
                _currentResourceLabels[i].text = currentAmount.ToString();
                _currentResourceLabels[i].color = Mathf.Approximately(currentAmount, requiredAmount) ? Color.green : Color.red;
            }
        }

        public void ShowUpgradeInfo<T>(Building<T> building, BuildingSettings buildingSettings, Dictionary<string, int> 
        oldStateDictionary, Dictionary<string, int> newStateDictionary) where T : BaseBuildingState
        {
            _oldStateDictionary = oldStateDictionary;
            _newStateDictionary = newStateDictionary;

            _nameLabel.text = buildingSettings.BuildingName;
            
            var buildingLevel = building.CurrentBuildingLevel;
            _currentLevelLabel.text = buildingLevel.ToString();
            var buildingNextLevel = buildingLevel + 1;
            _nextLevelLabel.text = buildingNextLevel.ToString();

            var buildingUpgrade = buildingSettings.UpgradeList[buildingNextLevel];

            ShowUpgradeCost(buildingUpgrade);
            ShowUpgradeDifference();
        }

        private void ShowUpgradeCost(BuildingUpgrade buildingUpgrade)
        {
            foreach (var resource in buildingUpgrade.UpgradeCost)
            {
                var icon = Instantiate(_icon, _resourceParent);
                icon.gameObject.SetActive(true);
                icon.sprite = MainManager.IconsProvider.GetResourceSprite(resource.Type);

                var requiredAmount = Instantiate(_requiredAmount, _resourceParent);
                requiredAmount.text = " / " + resource.Amount;
                requiredAmount.gameObject.SetActive(true);

                var currentAmount = Instantiate(_currentAmount, _resourceParent);
                var currentResource = MainManager.ResourceManager.GetResourceByType(resource.Type);
                
                currentAmount.text = currentResource.Amount.ToString();
                currentAmount.gameObject.SetActive(true);
                
                _requiredResources.Add(resource);
                _currentResourceLabels.Add(currentAmount);
            }
        }

        private void ShowUpgradeDifference()
        {
            var upgradeDifference = GetUpgradeDifference(_oldStateDictionary, _newStateDictionary);

            foreach (var pair in upgradeDifference)
            {
                var key = Instantiate(_keyLabel, _differenceParent);
                key.text = pair.Key;
                key.gameObject.SetActive(true);

                var newParameter = Instantiate(_newParameter, _differenceParent);
                newParameter.text = _newStateDictionary[pair.Key].ToString();
                newParameter.gameObject.SetActive(true);

                var newParameterDifference = Instantiate(_newParameterDifference, _differenceParent);
                newParameterDifference.text = "+" + upgradeDifference[pair.Key];
                newParameterDifference.gameObject.SetActive(true);
            }
        }
        
        private static Dictionary<string, int> GetUpgradeDifference(IReadOnlyDictionary<string, int> oldStateDictionary, 
        IReadOnlyDictionary<string, int> newStateDictionary)
        {
            var result = oldStateDictionary.ToDictionary(pair => pair.Key, 
            pair => newStateDictionary[pair.Key] - oldStateDictionary[pair.Key]);
            
            return result;
        }
    }
}
