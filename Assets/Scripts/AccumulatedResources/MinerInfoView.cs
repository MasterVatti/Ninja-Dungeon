using Buildings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccumulatedResources
{
    /// <summary>
    /// Класс для показа информации о добытых ресурсах майнера
    /// </summary>
    public class MinerInfoView  : BuildingInfoView
    {
        [SerializeField]
        private TextMeshProUGUI _resources;
        
        [SerializeField]
        private Slider _progressFill;
        
        [SerializeField]
        private Image _image;
   
        private ResourceMiner _resourceMiner;

        protected override void Update()
        {
            base.Update();
            _resources.text = _resourceMiner.CurrentResourceCount + "/" + _resourceMiner.MaxStorage;
            _progressFill.value = _resourceMiner.CurrentResourceCount / (float)_resourceMiner.MaxStorage;
        }

        public override void Initialize(GameObject building, Transform uiAttachPoint, string nameBuilding)
        {
            _resourceMiner = building.GetComponent<ResourceMiner>();

            if (_image != null) // for the case when we want to use custom icon
            {
                _image.sprite = MainManager.IconsProvider.GetResourceSprite(_resourceMiner.ExtractableResource);
            }

            Update();
            
            base.Initialize(building, uiAttachPoint, nameBuilding);
        }
    }
}