using Buildings;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class MinerUpgrader : IUpgrader
    {
        private readonly MinerBuildingData _state;
        public MinerUpgrader(MinerBuildingData state)
        {
            _state = state;
        }
        
        public GameObject Upgrade(BuildingSettings settings, int buildingLevel)
        {
            if (BuildingUtils.UpgradeBuilding(settings, buildingLevel, out var newBuilding))
            {
                var resourceMiner = newBuilding.GetComponent<ResourceMiner>();
                resourceMiner.MiningStartTime = _state.StartTime;
            }
            
            return newBuilding;
        }
    }
}
