using System.Collections.Generic;
using BuildingSystem.BuildingUpgradeSystem;
using ResourceSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace BuildingSystem
{
    /// <summary>
    /// Настройки для зданий
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuildingSettings", order = 1)]
    public class BuildingSettings : ScriptableObject
    {
        public int ID { get; set; }
        public string BuildingName => _buildingName;
        public BuildingInfoView BuildingInfoView => _buildingInfoView;
        
        public List<BuildingSettings> ConnectedBuildings => _connectedBuildings;
        public List<BuildingUpgrade> UpgradesInfo => _upgradesInfo;
        
        public GameObject PlaceHolderPrefab => _placeHolderPrefab;
        public float TimeToBuild => _timeToBuild;
        public Vector3 Position => _position;
        
        [SerializeField]
        private string _buildingName;
        [SerializeField]
        private BuildingInfoView _buildingInfoView;
        [SerializeField]
        private List<BuildingSettings> _connectedBuildings = new List<BuildingSettings>();
        [FormerlySerializedAs("_upgradeList")]
        [SerializeField]
        private List<BuildingUpgrade> _upgradesInfo = new List<BuildingUpgrade>();
        [SerializeField]
        private GameObject _placeHolderPrefab;
        [SerializeField]
        private float _timeToBuild;
        [SerializeField]
        private Vector3 _position;

        public List<Resource> GetUpgradeCost(int level)
        {
            return _upgradesInfo[level].UpgradeCost;
        }
    }
}
