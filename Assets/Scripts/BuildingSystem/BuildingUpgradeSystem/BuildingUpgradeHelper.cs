using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Класс для апгрейдов
    /// </summary>
    public static class BuildingUpgradeHelper
    {
        public static void Upgrade<T>(Building<T> building)
            where T : BaseBuildingState
        {
            var settingsID = building.BuildingSettingsID;
            var settings = MainManager.BuildingManager.GetBuildingSettings(settingsID);
            var buildingLevel = building.CurrentBuildingLevel + 1;
            Upgrade(building, settings, buildingLevel);
        }

        private static void Upgrade<T>(Building<T> oldBuilding, BuildingSettings settings, int buildingLevel)
        where T : BaseBuildingState
        {
            var upgrade = settings.UpgradeList[buildingLevel];
            var upgradeCost = upgrade.UpgradeCost;

            MainManager.ResourceManager.Pay(upgradeCost);
            var newBuildingGameObject = BuildingUtils.CreateNewBuilding(settings, buildingLevel);
            var newBuilding = newBuildingGameObject.GetComponent<Building<T>>();
            newBuilding.OnUpgrade(oldBuilding.GetState());

            DestroyOldBuilding(oldBuilding.gameObject);
        }

        private static void DestroyOldBuilding(GameObject oldBuilding)
        {
            MainManager.BuildingManager.ActiveBuildings.Remove(oldBuilding);
            Object.Destroy(oldBuilding);
        }
    }
}
