using System.Collections.Generic;
using ResourceSystem;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Класс для апгрейдов
    /// </summary>
    public static class BuildingUpgradeHelper
    {
        public static Building<T> Upgrade<T>(Building<T> building)
            where T : BaseBuildingState
        {
            var settingsID = building.BuildingSettingsID;
            var settings = MainManager.BuildingManager.GetBuildingSettings(settingsID);
            var buildingLevel = building.CurrentBuildingLevel + 1;
            
            if (settings.UpgradeList.Count <= buildingLevel)
            {
                return building;
            }

            return Upgrade(building, settings, buildingLevel);
        }

        private static Building<T> Upgrade<T>(Building<T> oldBuilding, BuildingSettings settings, int buildingLevel)
            where T : BaseBuildingState
        {
            var upgrade = settings.UpgradeList[buildingLevel];
            var upgradeCost = upgrade.UpgradeCost;

            if (TryPayForUpgrade(upgradeCost))
            {
                var newBuildingGameObject = BuildingUtils.CreateNewBuilding(settings, buildingLevel);
                var newBuilding = newBuildingGameObject.GetComponent<Building<T>>();
                newBuilding.OnUpgrade(oldBuilding.GetState());
                
                DestroyOldBuilding(oldBuilding.gameObject);
                return newBuilding;
            }

            return oldBuilding;
        }

        private static void DestroyOldBuilding(GameObject oldBuilding)
        {
            MainManager.BuildingManager.ActiveBuildings.Remove(oldBuilding);
            Object.Destroy(oldBuilding);
        }

        private static bool TryPayForUpgrade(List<Resource> upgradeCost)
        {
            if (MainManager.ResourceManager.HasEnough(upgradeCost))
            {
                MainManager.ResourceManager.Pay(upgradeCost);
                return true;
            }

            return false;
        }
    }
}
