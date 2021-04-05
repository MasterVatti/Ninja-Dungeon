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
        [SerializeField]
        private List<Resource> _resources;

        public bool HasEnough(ResourceType type, int value)
        {
            return _resources[GetResourceIndexByType(type)].Amount >= value;
        }

        public void Pay(ResourceType type, int value)
        {
            var index = GetResourceIndexByType(type);
            var resource = _resources[index];
            resource.Amount -= value;
            _resources[index] = resource;
        }

        public void AddResource(ResourceType type, int value)
        {
            var index = GetResourceIndexByType(type);
            var resource = _resources[index];
            resource.Amount += value;
            _resources[index] = resource;
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
