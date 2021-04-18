using System;
using BuildingSystem;
using ResourceSystem;
using SaveSystem;
using UnityEngine;

namespace Buildings
{
    /// <summary>
    /// Класс возвращает количество ресурса, добытого к данному моменту
    /// через свойство CurrentResourceCount.
    /// Выдает ресурс игроку, если подойти.
    /// </summary>
    public class ResourceMiner : Building<MinerBuildingData>
    {
        //Свойства для UI
        public ResourceType ExtractableResource => _miningResource;
        public float MaxStorage => _maxStorage;
        public int CurrentResourceCount
        {
            get
            {
                if (_currentResourceCount < _maxStorage)
                {
                    var minedResourceCount = GetMinedResourceCount(MiningStartTime, _miningPerSecond);
                    var count = StartAmount + minedResourceCount;
                    
                    _currentResourceCount = Mathf.Clamp(count, 0, _maxStorage);
                }

                return _currentResourceCount;
            }
        }
        
        private DateTime MiningStartTime { get; set; }
        private int StartAmount { get; set; }
        
        [SerializeField]
        private ResourceType _miningResource;
        [SerializeField]
        private float _miningPerSecond;
        [SerializeField]
        private int _maxStorage;
        
        private int _currentResourceCount;

        private void Awake()
        {
            if (!_stateWasLoaded)
            {
                MiningStartTime = DateTime.UtcNow;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Upgrade();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (_currentResourceCount != 0)
            {
                MainManager.ResourceManager.AddResource(_miningResource, _currentResourceCount);
                MiningStartTime = DateTime.UtcNow;
                _currentResourceCount = 0;
            }
        }

        private int GetMinedResourceCount(DateTime startTime, float miningPerSecond)
        {
            var minedSeconds = (float)DateTime.UtcNow.Subtract(startTime).TotalSeconds;
            return Mathf.FloorToInt(minedSeconds * miningPerSecond);
        }
        
        public override void OnUpgrade(MinerBuildingData oldBuildingState)
        {
            var minedResourceCount = GetMinedResourceCount(oldBuildingState.StartTime, oldBuildingState.MiningPerSecond);
            StartAmount = oldBuildingState.StartAmount + minedResourceCount;
            MiningStartTime = DateTime.UtcNow;
        }

        protected override void OnStateLoaded(MinerBuildingData data)
        {
            if (data != null)
            {
                var minedResourceWhileWasOffline = GetMinedResourceCount(data.StartTime, data.MiningPerSecond);
                StartAmount = data.StartAmount + minedResourceWhileWasOffline;
                MiningStartTime = DateTime.UtcNow;

                // TODO : take it from config
                _maxStorage = data.MaxStorage;
                _miningPerSecond = data.MiningPerSecond;
                _miningResource = data.Resource;
            }
        }

        public override MinerBuildingData GetState()
        {
            return new MinerBuildingData
            {
                MaxStorage = _maxStorage,
                MiningPerSecond = _miningPerSecond,
                Resource = _miningResource,
                StartTime = MiningStartTime
            };
        }
    }
}
