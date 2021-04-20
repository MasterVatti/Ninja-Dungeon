using System;
using UnityEngine;

namespace Loot
{
    [Serializable]
    public class ItemInformation
    {
        public float DropChance => _dropChance;
        public GameObject Item => _item;
        
        [SerializeField]
        private float _dropChance;
        [SerializeField]
        private GameObject _item;
    }
}
