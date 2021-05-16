using System;
using System.Collections.Generic;
using BuildingSystem.BuildingUpgradeSystem;
using ObjectPools;
using ResourceSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Buildings.PlayerCharacteristicsImprove
{
    public class ImprovePurchaseView : MonoBehaviour
    {
        public List<Resource> Resources { get; private set; }
        
        private readonly List<ResourceView> _resourceViews = new List<ResourceView>();
        
        [SerializeField]
        private Button _button;
        [SerializeField]
        private ResourceView _resourceViewPrefab;
        
        private MonoBehaviourPool<ResourceView> _resourceViewPool;

        private void Awake()
        {
            _resourceViewPool = new MonoBehaviourPool<ResourceView>(_resourceViewPrefab, gameObject.transform, 1);
        }

        private void Update()
        {
            _button.interactable = MainManager.ResourceManager.HasEnough(Resources);
        }

        public void Initialize(List<Resource> resources)
        {
            Resources = resources;
            
            _resourceViewPool.ReleaseAll();
            for(var i = 0; i < Resources.Count; i++)
            {
                _resourceViews.Add(_resourceViewPool.Take());
            }
            
            UpdateView();
        }
        
        public void SetButtonOnClick(Action action)
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(action.Invoke);
        }
        
        public void SetResources(List<Resource> resources)
        {
            Resources = resources;
            UpdateView();
        }
        
        private void UpdateView()
        {
            for(var i = 0; i < Resources.Count; i++)
            {
                _resourceViews[i].Initialize(Resources[i].Type, Resources[i].Amount);
            }
        }
    }
}
