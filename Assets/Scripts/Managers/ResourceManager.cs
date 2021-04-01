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
            return GetResourceByType(type).Amount >= value;
        }

        public void Pay(ResourceType type, int value)
        {
            GetResourceByType(type).Amount -= value;
        }

        public void AddResource(ResourceType type, int value)
        {
            GetResourceByType(type).Amount += value;
        }

        public Resource GetResourceByType(ResourceType type)
        {
            var resource = _resources.FirstOrDefault(res => res.Type == type);
            return resource ?? new Resource() {Amount = 0, Type = type};

        }
    }
}
