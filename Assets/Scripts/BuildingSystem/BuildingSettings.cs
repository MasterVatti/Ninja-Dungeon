using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Настройки для зданий:
    /// стоимость, префаб, связанные плейс-холдеры
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Building", order = 1)]
    public class BuildingSettings : ScriptableObject
    {
        public List<GameObject> ConnectedPlaceHolders => _connectedPlaceHolders;

        public GameObject Prefab => _prefab;

        public List<Resource> RequiredResources => _requiredResources;

        public float TimeToBuild => _timeToBuild;

        [SerializeField]
        private List<GameObject> _connectedPlaceHolders = new List<GameObject>();
        [SerializeField]
        private List<Resource> _requiredResources;
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private float _timeToBuild;
    }
}
