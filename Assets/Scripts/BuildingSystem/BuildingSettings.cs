using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Настройки для зданий
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuildingSettings", order = 1)]
    public class BuildingSettings : ScriptableObject
    {
        public List<BuildingSettings> ConnectedPlaceHolders => _connectedPlaceHolders;

        public GameObject BuildingPrefab => _buildingPrefab;

        public GameObject PlaceHolderPrefab => _placeHolderPrefab;

        public List<Resource> RequiredResources => _requiredResources;

        public float TimeToBuild => _timeToBuild;
        
        public Vector3 PlaceHolderPosition => _placeHolderPosition;
        
        [SerializeField]
        private List<BuildingSettings> _connectedPlaceHolders = new List<BuildingSettings>();
        [SerializeField]
        private List<Resource> _requiredResources;
        [SerializeField]
        private GameObject _buildingPrefab;
        [SerializeField]
        private GameObject _placeHolderPrefab;
        [SerializeField]
        private float _timeToBuild;
        [SerializeField]
        private Vector3 _placeHolderPosition;
        
    }
}
