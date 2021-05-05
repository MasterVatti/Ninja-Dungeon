using System.Collections.Generic;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeCostDisplay : MonoBehaviour
    {
        private readonly List<Resource> _requiredResources = new List<Resource>();
        private readonly List<TextMeshProUGUI> _currentResourceLabels = new List<TextMeshProUGUI>();
        
        [SerializeField]
        private RectTransform _costLayoutGroup;

        private ObjectPool _imagePool;
        private ObjectPool _labelPool;

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

        public void Initialize(ObjectPool imagePool, ObjectPool labelPool)
        {
            _imagePool = imagePool;
            _labelPool = labelPool;
        }
        
        public void ShowUpgradeCost(BuildingUpgrade buildingUpgrade)
        {
            foreach (var resource in buildingUpgrade.UpgradeCost)
            {
                var icon = _imagePool.Get();
                var image = icon.GetComponent<Image>();
                image.sprite = MainManager.IconsProvider.GetResourceSprite(resource.Type);
                icon.transform.SetParent(_costLayoutGroup, false);
                
                var currentAmountLabel = _labelPool.Get();
                var currentResource = MainManager.ResourceManager.GetResourceByType(resource.Type);
                UpgradeLabelHandler.SetLabelText(currentAmountLabel, currentResource.Amount.ToString());
                currentAmountLabel.transform.SetParent(_costLayoutGroup, false);
                
                _requiredResources.Add(resource);
                _currentResourceLabels.Add(currentAmountLabel.GetComponent<TextMeshProUGUI>());

                var requiredAmountLabel = _labelPool.Get();
                UpgradeLabelHandler.SetLabelText(requiredAmountLabel, "/" + resource.Amount);
                requiredAmountLabel.transform.SetParent(_costLayoutGroup, false);
            }
        }
    }
}
