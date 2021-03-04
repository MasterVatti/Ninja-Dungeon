using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Building", order = 1)]
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
        private GameObject _model;
        public List<GameObject> ConnectedPlaceHolders => _connectedPlaceHolders;
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