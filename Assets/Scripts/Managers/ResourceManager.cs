using System;
using System.Collections.Generic;
using System.Linq;
using ResourceSystem;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Класс управляющий ресурсами игрока
    /// </summary>
    public class ResourceManager : MonoBehaviour
    {
        public float OldAmount => _oldAmount;
        
        public float NewAmount => _newAmount;

        public event Action<float> OnResourceChanged; 
        
        [SerializeField]
        private List<Resource> _resources;

        private ResourcesView _resourcesView;

        private float _substracting;

        private float _oldAmount;

        private float _newAmount;
        
        public bool HasEnough(ResourceType type, float value)
        {
            return _resources[GetResourceIndexByType(type)].Amount >= value;
        }

        public bool HasEnough(List<Resource> resources)
        {
            return resources.TrueForAll(resource => HasEnough(resource.Type, resource.Amount));
        }

        public void Pay(ResourceType type, float value)
        {
            var index = GetResourceIndexByType(type);
            var resource = _resources[index];
            resource.Amount -= value;
            _resources[index] = resource;
        }

        public void Pay(IEnumerable<Resource> resources)
        {
            foreach (var resource in resources) 
            {
                Pay(resource.Type, resource.Amount);
            }
        }

        public void AddResource(ResourceType type, int value)
        {
            var index = GetResourceIndexByType(type);
            var resource = _resources[index];
            resource.Amount += value;
            _substracting = value;
            var newAmount = resource.Amount;
            _resources[index] = resource;
            OnResourceChanged?.Invoke(_substracting);
            
        }

        public List<Resource> GetResources()
        {
            return _resources;
        }

        public void SetResources(IEnumerable<Resource> resources)
        {
            _resources = new List<Resource>(resources.ToList());
        }

        private int GetResourceIndexByType(ResourceType type)
        {
            var index = _resources.FindIndex(resource => resource.Type == type);
            return index;
        }
    }
}
