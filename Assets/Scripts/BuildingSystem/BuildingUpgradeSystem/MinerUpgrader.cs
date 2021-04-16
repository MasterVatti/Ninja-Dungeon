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
        
        public override void Upgrade()
        {
            var settingsID = _building.BuildingSettingsID;
            var settings = MainManager.BuildingManager.GetBuildingSettings(settingsID);
            var buildingLevel = _building.CurrentBuildingLevel + 1;
            
            if (settings.UpgradeList.Count <= buildingLevel)
            {
                return;
            }

            if (UpgradeBuildingSucceed(settings, buildingLevel, out var newBuilding) && newBuilding != null)
            {
                DestroyOldBuilding(_building.gameObject);
            }
        }

        protected override void InitializeBuilding(GameObject building)
        {
            var resourceMiner = building.GetComponent<ResourceMiner>();
            resourceMiner.MiningStartTime = _building.State.StartTime;
        }
    }
}
