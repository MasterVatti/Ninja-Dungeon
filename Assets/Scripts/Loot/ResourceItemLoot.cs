using ResourceSystem;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Класс отвечает за получение подобранного ресурса
    /// </summary>
    public class ResourceItemLoot : ItemLoot
    {
        [SerializeField]
        private Resource _resource;
        
        private void OnDestroy()
        {
            MainManager.ResourceManager.AddResource(_resource.Type, (int)_resource.Amount);
        }
    }
}
