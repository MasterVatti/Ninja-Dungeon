using System.Collections.Generic;
using ResourceSystem;
using SaveSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    /// <summary>
    /// Базовый класс для апгрейдеров
    /// </summary>
    public abstract class BuildingUpgraderBase
    {
        protected abstract void InitializeBuilding(GameObject building);
        
        protected void Upgrade<T>(Building<T> building) where T : BaseBuildingState
        {
            var settingsID = building.BuildingSettingsID;
            var settings = MainManager.BuildingManager.GetBuildingSettings(settingsID);
            var buildingLevel = building.CurrentBuildingLevel + 1;
            
            if (settings.UpgradeList.Count <= buildingLevel)
            {
                return;
            }

            var newBuilding = Upgrade(settings, buildingLevel);
            if (newBuilding != null)
            {
                DestroyOldBuilding(building.gameObject);
            }
        }

        private GameObject Upgrade(BuildingSettings settings, int buildingLevel)
        {
            var upgrade = settings.UpgradeList[buildingLevel];
            var upgradeCost = upgrade.UpgradeCost;

            if (HadPayedForUpgrade(upgradeCost))
            {
                var newBuilding = BuildingUtils.CreateNewBuilding(settings, buildingLevel);
                InitializeBuilding(newBuilding);
                return newBuilding;
            }
            
            return null;
        }

        private static void DestroyOldBuilding(GameObject oldBuilding)
        {
            MainManager.BuildingManager.ActiveBuildings.Remove(oldBuilding);
            Object.Destroy(oldBuilding);
        }

        private static bool HadPayedForUpgrade(List<Resource> upgradeCost)
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
