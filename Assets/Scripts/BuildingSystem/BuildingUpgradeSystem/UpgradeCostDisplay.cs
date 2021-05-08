using System.Collections.Generic;
using ObjectPools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeCostDisplay : MonoBehaviour
    {
        private readonly Dictionary<ResourceLabel, float> _resourceLabels = new Dictionary<ResourceLabel, float>();
        
        [SerializeField]
        private RectTransform _costLayoutGroup;
        [SerializeField]
        private Image _imagePrefab;
        [SerializeField]
        private TextMeshProUGUI _labelPrefab;

        private void Update()
        {
            UpdateUpgradeCost();
        }

        public void ShowUpgradeCost(BuildingUpgrade buildingUpgrade)
        {
            var upgradeCost = buildingUpgrade.UpgradeCost;
            var imagePool = new MonoBehaviourPool<Image>(_imagePrefab, _costLayoutGroup, upgradeCost.Count);
            var labelPool = new MonoBehaviourPool<TextMeshProUGUI>(_labelPrefab, _costLayoutGroup);
            foreach (var resource in upgradeCost)
            {
                var icon = imagePool.Take();
                icon.sprite = MainManager.IconsProvider.GetResourceSprite(resource.Type);

                var currentAmountLabel = labelPool.Take();
                var resourceLabel = new ResourceLabel {Label = currentAmountLabel, Type = resource.Type};
                _resourceLabels.Add(resourceLabel, resource.Amount);

                var requiredAmountLabel = labelPool.Take();
                requiredAmountLabel.text = "/" + resource.Amount;
            }
        }

        private void UpdateUpgradeCost()
        {
            foreach (var resource in _resourceLabels)
            {
                var key = resource.Key;
                var keyLabel = key.Label;
                var playerResource = MainManager.ResourceManager.GetResourceByType(key.Type);
                keyLabel.text = Mathf.Clamp(playerResource.Amount, 0, resource.Value).ToString();
                keyLabel.color = playerResource.Amount < resource.Value ? Color.red : Color.green;
            }
        }
    }
}
