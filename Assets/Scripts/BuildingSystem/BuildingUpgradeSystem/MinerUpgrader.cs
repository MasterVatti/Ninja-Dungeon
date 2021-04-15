using Buildings;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class MinerUpgrader : IUpgrader
    {
        public GameObject Upgrade<T>(T state, BuildingSettings settings, int buildingLevel) where T : BaseBuildingState
        {
            if (BuildingUtils.UpgradeBuilding(settings, buildingLevel, out var newBuilding))
            {
                var resourceMiner = newBuilding.GetComponent<ResourceMiner>();
                resourceMiner.MiningStartTime = (state as MinerBuildingData).StartTime;
            }
            
            return newBuilding;
        }
    }
}
