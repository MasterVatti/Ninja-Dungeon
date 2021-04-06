using UnityEngine;

namespace BuildingSystem
{
    public static class BuildingUtils
    {
        public static GameObject CreateNewConstruction(BuildingSettings buildingSettings, bool isBuilding,
        int buildingLevel = 0)
        {
            var placeHolderPosition = buildingSettings.Position;
            if (isBuilding)
            {
                var buildingUpgrade = buildingSettings.UpgradeList[buildingLevel];
                var buildingPrefab = buildingUpgrade.UpgradePrefab;
                var building = Object.Instantiate(buildingPrefab, placeHolderPosition,
                buildingPrefab.transform.rotation);

                MainManager.BuildingManager.AddNewConstructedBuilding(building);
                building.GetComponent<IBuildingSaver>().Initialize(buildingSettings.ID);

                return building;
            }

            var placeHolderPrefab = buildingSettings.PlaceHolderPrefab;
            var placeHolderRotation = placeHolderPrefab.transform.rotation;

            var placeHolder = Object.Instantiate(placeHolderPrefab, placeHolderPosition, placeHolderRotation);
            placeHolder.GetComponent<BuildingController>().Initialize(buildingSettings);
            MainManager.BuildingManager.ActivePlaceHolders.Add(placeHolder);

            return placeHolder;
        }

        public static bool UpgradeBuilding(BuildingSettings buildingSettings, int upgradeLevel)
        {
            if (buildingSettings.UpgradeList.Count > upgradeLevel)
            {
                var upgrade = buildingSettings.UpgradeList[upgradeLevel];
                var upgradeCost = upgrade.UpgradeCost;

                if (upgradeCost.TrueForAll(resource =>
                MainManager.ResourceManager.HasEnough(resource.Type, resource.Amount)))
                {
                    upgradeCost.ForEach(resource =>
                    MainManager.ResourceManager.Pay(resource.Type, resource.Amount));

                    var go = CreateNewConstruction(buildingSettings, true, upgradeLevel);
                    go.GetComponent<IUpgradable>().CurrentBuildingLevel = upgradeLevel;

                    return true;
                }
            }

            return false;
        }
    }
}
