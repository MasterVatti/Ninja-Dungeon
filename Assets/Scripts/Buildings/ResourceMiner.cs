using BuildingSystem;
using BuildingSystem.BuildingUpgradeSystem;
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
                    var count = Mathf.FloorToInt((Time.time - MiningStartTime) * _miningPerSecond);
                    _currentResourceCount = Mathf.Clamp(count, 0, _maxStorage);
                }

                return _currentResourceCount;
            }
        }
        
        public float MiningStartTime { get; set; }
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

        private void Start()
        {
            if (MiningStartTime == 0f)
            {
                MiningStartTime = Time.time;
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
                MiningStartTime = Time.time;
            }
        }

        private void Upgrade()
        {
            new MinerUpgrader(this).Upgrade();
        }

        protected override void StateInitialize()
        {
            State = new MinerBuildingData
            {
                MaxStorage = _maxStorage,
                MiningPerSecond = _miningPerSecond,
                Resource = _miningResource,
                StartTime = Time.time
            };
        }

        protected override void Initialize(MinerBuildingData data)
        {
            if (data != null)
            {
                MiningStartTime = data.StartTime;
                _maxStorage = data.MaxStorage;
                _miningPerSecond = data.MiningPerSecond;
                _miningResource = data.Resource;
            }
        }
    }
}
