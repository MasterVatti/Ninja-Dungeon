using System.Collections.Generic;
using System.Linq;
using ResourceSystem;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Класс управляющий ресурсами игрока
    /// </summary>
    public class ResourceManager : Singleton<ResourceManager>
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
        
        private Resource GetResourceByType(ResourceType type)
        {
            return _resources.FirstOrDefault(resource => resource.Type == type);
        }
    }
}
