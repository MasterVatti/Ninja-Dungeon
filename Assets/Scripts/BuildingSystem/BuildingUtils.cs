using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Класс с утилитарными методами для зданий
    /// </summary>
    public static class BuildingUtils
    {
        public static GameObject CreateNewBuilding(BuildingSettings settings, int buildingLevel = 0)
        {
            var position = settings.Position;
            var buildingUpgrade = settings.UpgradeList[buildingLevel];
            var buildingPrefab = buildingUpgrade.UpgradePrefab;
            var rotation = buildingPrefab.transform.rotation;
            
            var building = Object.Instantiate(buildingPrefab, position, rotation);

            MainManager.BuildingManager.AddNewConstructedBuilding(building, settings);
            if (building.TryGetComponent<IBuilding>(out var buildingData))
            {
                buildingData.OnStateLoaded(settings.ID, buildingLevel);
            }

            return building;
        }

        public static GameObject CreateNewPlaceHolder(BuildingSettings settings)
        {
            var position = settings.Position;
            var placeHolderPrefab = settings.PlaceHolderPrefab;
            var placeHolderRotation = placeHolderPrefab.transform.rotation;

            var placeHolder = Object.Instantiate(placeHolderPrefab, position, placeHolderRotation);
            
            placeHolder.GetComponent<BuildingController>().Initialize(settings);
            MainManager.BuildingManager.ActivePlaceHolders.Add(placeHolder);

            return placeHolder;
        }
    }
}
