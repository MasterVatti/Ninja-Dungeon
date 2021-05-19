using System;
using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    [Serializable]
    public class BuildingUpgrade
    {
        public List<Resource> UpgradeCost
        {
            get => _upgradeCost;
            set => _upgradeCost = value;
        }

        public GameObject UpgradePrefab
        {
            get => _upgradePrefab;
            set => _upgradePrefab = value;
        }
        
        [SerializeField]
        private List<Resource> _upgradeCost;
        [SerializeField]
        private GameObject _upgradePrefab;
    }
}
