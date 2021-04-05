using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Настройки для зданий
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuildingSettings", order = 1)]
    public class BuildingSettings : ScriptableObject
    {
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public List<BuildingSettings> ConnectedBuildings => _connectedBuildings;
        public List<BuildingUpgrade> UpgradeList => _upgradeList;
        public GameObject PlaceHolderPrefab => _placeHolderPrefab;
        public float TimeToBuild => _timeToBuild;
        public Vector3 Position => _position;
        
        [SerializeField]
        private List<BuildingSettings> _connectedBuildings = new List<BuildingSettings>();
        [SerializeField]
        private List<BuildingUpgrade> _upgradeList = new List<BuildingUpgrade>();
        [SerializeField]
        private GameObject _placeHolderPrefab;
        [SerializeField]
        private float _timeToBuild;
        [SerializeField]
        private Vector3 _position;
        [SerializeField] private int _id;
    }
}
