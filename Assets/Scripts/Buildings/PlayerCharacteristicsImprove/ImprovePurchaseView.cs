using System.Collections.Generic;
using BuildingSystem.BuildingUpgradeSystem;
using Characteristics;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Buildings.PlayerCharacteristicsImprove
{
    public class ImprovePurchaseView : MonoBehaviour
    {
        [SerializeField]
        private List<ResourceView> _resourceViews;
        [SerializeField]
        private Button _button;

        private List<Resource> _resources;
        
        public void Initialize(CharacteristicType type, List<Resource> resources)
        {
            _resources = resources;
            
            for(var i = 0; i < resources.Count; i++)
            {
                _resourceViews[i].Initialize(resources[i].Type, resources[i].Amount);
            }

            var playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            _button.onClick.AddListener(delegate
            {
                playerCharacteristics.ImproveCharacteristic(type);
                MainManager.ResourceManager.Pay(_resources);
            });
        }

        private void Update()
        {
            _button.interactable = MainManager.ResourceManager.HasEnough(_resources);
        }
    }
}
