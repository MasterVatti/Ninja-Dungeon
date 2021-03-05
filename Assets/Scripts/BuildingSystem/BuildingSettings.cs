using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Настройки для зданий:
    /// стоимость, префаб, связанные плейс-холдеры
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BuildingBase", order = 1)]
    public class BuildingSettings : ScriptableObject
    {
        [SerializeField]
        private List<GameObject> _connectedPlaceHolders = new List<GameObject>();
        [Header("Resources")]
        [SerializeField]
        private int _goldCost;
        [SerializeField]
        private int _lumberCost;
        [SerializeField]
        private GameObject _prefab;
        public List<GameObject> ConnectedPlaceHolders => _connectedPlaceHolders;

        public GameObject Prefab => _prefab;

        public int[] RequiredResources
        {
            get => new[] {_goldCost, _lumberCost};
            set
            {
                _goldCost = value[0];
                _lumberCost = value[1];
            }
        }
    }
}
