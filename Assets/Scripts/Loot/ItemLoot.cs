using System;
using UnityEngine;

namespace Loot
{
    /// <summary>
    /// Базовый класс для заполнения информации о предмете
    /// </summary>
    [Serializable]
    public class ItemLoot 
    {
        public float DropChance => _dropChance;
        public GameObject Item => _item;
        
        [SerializeField]
        private float _dropChance;
        [SerializeField]
        private GameObject _item;
    }
}
