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
    public class ResourceMiner : UpgradableBuilding<MinerBuildingData>
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
                    
                    _currentResourceCount = ClampToMaxStorage(count);
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

        private void OnTriggerStay(Collider other)
        {
            if (_currentResourceCount != 0)
            {
                MainManager.ResourceManager.AddResource(_miningResource, _currentResourceCount);
                MiningStartTime = DateTime.UtcNow;
                StartAmount = 0;
                _currentResourceCount = 0;
            }
        }
        
        public override void OnUpgrade(MinerBuildingData oldBuildingState)
        {
            base.OnUpgrade(oldBuildingState);
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
                
                _maxStorage = data.MaxStorage;
                _miningPerSecond = data.MiningPerSecond;
            }
        }

        public override MinerBuildingData GetState()
        {
            return new MinerBuildingData
            {
                StartTime = MiningStartTime,
                StartAmount = _currentResourceCount,
                MaxStorage = _maxStorage,
                MiningPerSecond = _miningPerSecond
            };
        }
        
        private int GetMinedResourceCount(DateTime startTime, float miningPerSecond)
        {
            var minedSeconds = (float)DateTime.UtcNow.Subtract(startTime).TotalSeconds;
            var minedResourceCount = Mathf.FloorToInt(minedSeconds * miningPerSecond);
            return ClampToMaxStorage(minedResourceCount);
        }

        private int ClampToMaxStorage(int value)
        {
            return Mathf.Clamp(value, 0, _maxStorage);
        }
    }
}
