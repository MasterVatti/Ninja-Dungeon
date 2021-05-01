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

        [Header("LinesOffsets")]
        [SerializeField]
        private float _resourceLineOffset;
        [SerializeField]
        private float _differenceLineOffset;

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
            var offset = 0f;
            foreach (var resource in buildingUpgrade.UpgradeCost)
            {
                var icon = Instantiate(_icon, _resourceParent);
                icon.gameObject.SetActive(true);
                ApplyOffset(icon, offset);
                icon.sprite = MainManager.IconsProvider.GetResourceSprite(resource.Type);

                var requiredAmount = CreateElement(_requiredAmount, _resourceParent, offset);
                requiredAmount.text = " / " + resource.Amount;

                var currentAmount = CreateElement(_currentAmount, _resourceParent, offset);
                var currentResource = MainManager.ResourceManager.GetResourceByType(resource.Type);
                currentAmount.text = currentResource.Amount.ToString();

                offset += _resourceLineOffset;
                
                _requiredResources.Add(resource);
                _currentResourceLabels.Add(currentAmount);
            }
        }

        private void ShowUpgradeDifference()
        {
            var upgradeDifference = GetUpgradeDifference(_oldStateDictionary, _newStateDictionary);

            var offset = 0f;

            foreach (var pair in upgradeDifference)
            {
                var key = CreateElement(_keyLabel, _differenceParent, offset);
                key.text = pair.Key;

                var newParameter = CreateElement(_newParameter, _differenceParent, offset);
                newParameter.text = _newStateDictionary[pair.Key].ToString();

                var newParameterDifference = CreateElement(_newParameterDifference, _differenceParent, offset);
                newParameterDifference.text = "+" + upgradeDifference[pair.Key];

                offset += _differenceLineOffset;
            }
        }

        private static void ApplyOffset(Component go, float offset)
        {
            var goTransform = go.transform;
            var goPosition = goTransform.position;
            
            goTransform.position = new Vector2(goPosition.x, goPosition.y - offset);
        }
        
        private static Dictionary<string, int> GetUpgradeDifference(IReadOnlyDictionary<string, int> oldStateDictionary, 
        IReadOnlyDictionary<string, int> newStateDictionary)
        {
            var result = oldStateDictionary.ToDictionary(pair => pair.Key, 
            pair => newStateDictionary[pair.Key] - oldStateDictionary[pair.Key]);
            
            return result;
        }

        private static TextMeshProUGUI CreateElement(TextMeshProUGUI element, Transform parent, float offset)
        {
            var go = Instantiate(element, parent);
            
            go.gameObject.SetActive(true);
            ApplyOffset(go, offset);
            
            return go;
        }
    }
}
