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
        private TextMeshProUGUI _requiredAmountLabel;

        private ResourceType _resourceType;
        private float _requiredAmount;

        public void Initialize(ResourceType type, float costAmount)
        {
            _resourceType = type;
            _requiredAmount = costAmount;
            _requiredAmountLabel.text = costAmount.ToString();
            _image.sprite = MainManager.IconsProvider.GetResourceSprite(type);
        }

        private void Update()
        {
            var hasEnough = MainManager.ResourceManager.HasEnough(_resourceType, _requiredAmount);
            _requiredAmountLabel.color = hasEnough? Color.green : Color.red;
        }
    }
}
