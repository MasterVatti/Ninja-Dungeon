using Buildings;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Класс-апгрейдер для ResourceMiner
    /// </summary>
    public class MinerUpgrader : BuildingUpgraderBase
    {
        private readonly Building<MinerBuildingData> _building;
        public MinerUpgrader(Building<MinerBuildingData> building)
        {
            _building = building;
            _building.StateInitialize();
        }
        
        public void Upgrade()
        {
            base.Upgrade(_building);
        }

        protected override void InitializeBuilding(GameObject building)
        {
            var resourceMiner = building.GetComponent<ResourceMiner>();
            resourceMiner.MiningStartTime = _building.State.StartTime;
        }
    }
}
