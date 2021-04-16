using System.Collections.Generic;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public abstract class BuildingUpgrader
    {
        public abstract void Upgrade();
        protected abstract void InitializeBuilding(GameObject building);

        protected bool UpgradeBuildingSucceed(BuildingSettings settings, int buildingLevel, out GameObject newBuilding)
        {
            var upgrade = settings.UpgradeList[buildingLevel];
            var upgradeCost = upgrade.UpgradeCost;

            if (HadPayedForUpgrade(upgradeCost))
            {
                newBuilding = BuildingUtils.CreateNewBuilding(settings, buildingLevel);
                InitializeBuilding(newBuilding);
                return true;
            }

            newBuilding = null;
            return false;
        }

        protected static void DestroyOldBuilding(GameObject oldBuilding)
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
