using System;
using ResourceSystem;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за настройку листа союзников.
    /// </summary>
    
    [Serializable]
    public class AlliesListSetting
    {
        public ResourceType FirstType
        {
            get => _firstType;
            set => _firstType = value;
        }
        public float FirstPrice
        {
            get => _firstPrice;
            set => _firstPrice = value;
        }
        public ResourceType SecondType
        {
            get => _secondType;
            set => _secondType = value;
        }
        public float SecondPrice
        {
            get => _secondPrice;
            set => _secondPrice = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        public GameObject AllyPrefab
        {
            get => _allyPrefab;
            set => _allyPrefab = value;
        }
        public Sprite AllyIcon
        {
            get => _allyIcon;
            set => _allyIcon = value;
        }
        public Transform SpawnPoint
        {
            get => _spawnPoint;
            set => _spawnPoint = value;
        }
        public Transform[] PatrolPoints
        {
            get => _patrolPoints;
            set => _patrolPoints = value;
        }
        
        

        [SerializeField]
        private ResourceType _firstType;
        [SerializeField]
        private float _firstPrice;
        [SerializeField]
        private ResourceType _secondType;
        [SerializeField]
        private float _secondPrice;
        [SerializeField]
        private Sprite _allyIcon;
        [SerializeField]
        private string _description;
        [SerializeField]
        private GameObject _allyPrefab;
        [SerializeField]
        private Transform _spawnPoint;
        [SerializeField]
        private Transform[] _patrolPoints;
    }
}

