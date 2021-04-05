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
    public class ResourceMiner : Building<MinerBuildingData>, IUpgradable
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
                    var count = Mathf.FloorToInt((Time.time - _startMiningTime) / _miningPerSecond);
                    _currentResourceCount = Mathf.Clamp(count, 0, _maxStorage);
                }

                return _currentResourceCount;
            }
        }

        public int CurrentBuildingLevel { get; set; }
        public BuildingUpgrader Upgrader { get; set; } = new BuildingUpgrader();
        public Transform PositionUI => _positionUI;

        [SerializeField]
        private ResourceType _miningResource;
        [SerializeField]
        private float _miningPerSecond;
        [SerializeField]
        private int _maxStorage;
        [SerializeField]
        private Transform _positionUI;
        
        private int _currentResourceCount;
        private float _startMiningTime;

        private void Start()
        {
            _startMiningTime = Time.time;
        }

        private void OnTriggerStay(Collider other)
        {
            if (_currentResourceCount != 0)
            {
                MainManager.ResourceManager.AddResource(_miningResource, _currentResourceCount);
                _startMiningTime = Time.time;
            }
        }

        public void Upgrade()
        {
            var buildingSettings = MainManager.BuildingManager.GetBuildingSettings(BuildingSettingsID);
            if (Upgrader.UpgradeBuilding(buildingSettings, CurrentBuildingLevel + 1))
            {
                MainManager.BuildingManager.ActiveBuildings.Remove(gameObject);
                Destroy(gameObject);
            }
        }

        public override BuildingData Save()
        {
            _state = new MinerBuildingData
            {
                StartTime = Time.time,
                MaxStorage = _maxStorage,
                MiningPerSecond = _miningPerSecond,
                ResourceCount = _currentResourceCount,
                Resource = _miningResource
            };
            return base.Save();
        }

        protected override void Initialize(MinerBuildingData data)
        {
            if (data != null)
            {
                _startMiningTime = data.StartTime;
                _maxStorage = data.MaxStorage;
                _currentResourceCount = data.ResourceCount;
                _miningPerSecond = data.MiningPerSecond;
                _miningResource = data.Resource;
            }
        }
    }
}
