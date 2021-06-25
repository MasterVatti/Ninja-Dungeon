using System;
using ResourceSystem;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Класс для заполнения информации о предмете-ресурсе
    /// </summary>
    [Serializable]
    public class ResourceItem : ItemLoot
    {
        public Resource Resource => _resource;
        
        [SerializeField]
        private Resource _resource;
    }
}
