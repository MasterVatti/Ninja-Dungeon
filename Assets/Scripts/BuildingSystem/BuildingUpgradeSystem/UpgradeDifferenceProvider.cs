using System;
using System.Collections.Generic;
using System.Linq;
using SaveSystem;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public class UpgradeDifferenceProvider<T> where T : BaseBuildingState
    {
        private readonly Building<T> _building;
        private readonly Func<T, Dictionary<string, int>> _getStateDictionary;
        private readonly BuildingUpgrade _buildingUpgrade;

        private T OldBuildingState => GetOldBuildingState();
        private T NewBuildingState => GetNewBuildingState();

        public UpgradeDifferenceProvider(Building<T> building, BuildingUpgrade buildingUpgrade, Func<T, Dictionary<string, int>> 
        getStateDictionaryFunction)
        {
            _building = building;
            _getStateDictionary = getStateDictionaryFunction;
            _buildingUpgrade = buildingUpgrade;
        }

        public Dictionary<string, int> GetUpgradeDifference()
        {
            var oldState = _getStateDictionary(OldBuildingState);
            var newState = _getStateDictionary(NewBuildingState);

            var result = oldState.ToDictionary(pair => pair.Key, 
            pair => newState[pair.Key] - newState[pair.Key]);
            return result;
        }

        private T GetOldBuildingState()
        {
            return _building.GetState();
        }

        private T GetNewBuildingState()
        {
            var upgradeBuilding = _buildingUpgrade.UpgradePrefab.GetComponent<Building<T>>();
            
            return upgradeBuilding.GetState();
        }
    }
}
