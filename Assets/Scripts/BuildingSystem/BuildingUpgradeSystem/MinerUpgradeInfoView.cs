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

        protected override Dictionary<string, int> ParseStateToDictionary(MinerBuildingData state)
        {
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
