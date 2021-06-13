using Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace AccumulatedResources
{
    /// <summary>
    /// Класс для показа информации о добытых ресурсах майнера
    /// </summary>
    public class MinerInfoView  : BuildingInfoView
    {
        [FormerlySerializedAs("_resources")]
        [SerializeField]
        private TextMeshProUGUI _collectedAmount;
        
        [SerializeField]
        private Slider _progressFill;
        
        [FormerlySerializedAs("_image")]
        [SerializeField]
        private Image _resourceIcon;
   
        private ResourceMiner _resourceMiner;

        protected override void Update()
        {
            base.Update();
            _collectedAmount.text = _resourceMiner.CurrentResourceCount + "/" + _resourceMiner.MaxStorage;
            _progressFill.value = _resourceMiner.CurrentResourceCount / (float)_resourceMiner.MaxStorage;
        }

        public override void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
        {
            _resourceMiner = building.GetComponent<ResourceMiner>();

            if (_resourceIcon != null) // for the case when we want to use custom icon
            {
                _resourceIcon.sprite = MainManager.IconsProvider.GetResourceSprite(_resourceMiner.ExtractableResource);
            }

            Update();
            
            base.Initialize(building, uiAttachPoint, nameBuilding);
        }
    }
}