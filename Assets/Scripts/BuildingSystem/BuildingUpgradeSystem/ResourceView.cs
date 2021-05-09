using System;
using ResourceSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _playerAmountLabel;
        [SerializeField]
        private TextMeshProUGUI _requiredAmountLabel;

        private ResourceType _resourceType;
        private float _requiredAmount;

        public void Initialize(ResourceType type, float costAmount)
        {
            _resourceType = type;
            _requiredAmount = costAmount;
            _requiredAmountLabel.text = "/" + costAmount;
            _image.sprite = MainManager.IconsProvider.GetResourceSprite(type);
        }

        private void Update()
        {
            var playerResource = MainManager.ResourceManager.GetResourceByType(_resourceType).Amount;
            _playerAmountLabel.text = Mathf.Clamp(playerResource, 0, _requiredAmount).ToString();
            _playerAmountLabel.color = _requiredAmount > playerResource ? Color.red : Color.green;
        }
    }
}
