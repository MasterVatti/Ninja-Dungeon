using System.Collections.Generic;
using BuildingSystem.BuildingUpgradeSystem;
using Characteristics;
using ObjectPools;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Buildings.PlayerCharacteristicsImprove
{
    public class ImprovePurchaseView : MonoBehaviour
    {
        private readonly List<ResourceView> _resourceViews = new List<ResourceView>();
        
        [SerializeField]
        private Button _button;
        [SerializeField]
        private ResourceView _resourceViewPrefab;
        
        private MonoBehaviourPool<ResourceView> _resourceViewPool;
        private CharacteristicImproveSettings _settings;
        private CharacteristicType _type;
        private List<Resource> _resources;
        private bool _useVariantCost;

        private void Awake()
        {
            _resourceViewPool = new MonoBehaviourPool<ResourceView>(_resourceViewPrefab, gameObject.transform, 2);
        }

        private void Update()
        {
            _button.interactable = MainManager.ResourceManager.HasEnough(_resources);
        }

        public void Initialize(CharacteristicImproveSettings settings, bool useVariantCost = false)
        {
            _settings = settings;
            _useVariantCost = useVariantCost;
            _type = _settings.CharacteristicType;
            SetResources();

            _resourceViewPool.ReleaseAll();
            for(var i = 0; i < _resources.Count; i++)
            {
                _resourceViews.Add(_resourceViewPool.Take());
            }
            
            UpdateView();
        }
        
        private void SetResources()
        {
            _resources = _useVariantCost ? _settings.VariantCost : _settings.Cost;
        }

        private void UpdateView()
        {
            for(var i = 0; i < _resources.Count; i++)
            {
                _resourceViews[i].Initialize(_resources[i].Type, _resources[i].Amount);
            }

            var playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(delegate
            {
                playerCharacteristics.ImproveCharacteristic(_type);
                MainManager.ResourceManager.Pay(_resources);
                SetResources();
                UpdateView();
            });
        }
    }
}
