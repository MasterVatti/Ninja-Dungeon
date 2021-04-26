using System.Collections.Generic;
using SaveSystem;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Класс-потомок BuildingUpgradeInfoView
    /// Представляет MinerBuildingData в виде Dictionary
    /// </summary>
    public class MinerUpgradeInfoView : BuildingUpgradeInfoView<MinerBuildingData>
    {
        private const string MINING_PER_SECOND_KEY = "Mining per second";
        private const string MAX_STORAGE_KEY = "Max storage";
        
        public override void ApplyContext(UpgradeContext<MinerBuildingData> context)
        {
            building = context.Building;
            SetBuildingSettings();
            ShowUpgradeInfo();
        }

        protected override Dictionary<string, int> GetStateDictionary(bool isNextLevelState = false)
        {
            MinerBuildingData state;
            
            if (isNextLevelState)
            {
                var buildingUpgrade = buildingSettings.UpgradeList[building.CurrentBuildingLevel + 1];
                var upgradePrefab = buildingUpgrade.UpgradePrefab;
                state = upgradePrefab.GetComponent<Building<MinerBuildingData>>().GetState();
            }
            else
            {
                state = building.GetState();
            }
            
            var resultDictionary = new Dictionary<string, int>
            {
                {
                    MINING_PER_SECOND_KEY, (int)state.MiningPerSecond
                },
                {
                    MAX_STORAGE_KEY, state.MaxStorage
                }
            };
            
            return resultDictionary;
        }
    }
}
