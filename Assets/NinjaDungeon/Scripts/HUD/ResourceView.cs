using System.Collections.Generic;
using System.Linq;
using ResourceSystem;
using UnityEngine;

namespace HUD
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField]
        private List<ResourceLabel> _resourceLabels;
        [Min(1)]
        [SerializeField]
        private float _animationTime;
    
        protected List<Resource> _resources;
        
        protected virtual void Start()
        {
            UpdateResourcesAmount();
        }
    
        protected void OnResourceAmountChanged(Resource resource, int newAmount)
        {
            var index = _resourceLabels.FindIndex(resourceLabel => resourceLabel.Type == resource.Type);
            _resourceLabels[index].SetAmount(newAmount , _animationTime);
        }

        private void UpdateResourcesAmount()
        {
            foreach (var resourceLabel in _resourceLabels)
            {
                foreach (var resource in _resources.Where(resource => resourceLabel.Type == resource.Type))
                {
                    resourceLabel.Label.text = resource.Amount.ToString();
                    resourceLabel.СurrentValue = resource.Amount;
                }
            }
        }
    }
}