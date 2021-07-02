using System.Collections.Generic;
using JetBrains.Annotations;
using NinjaDungeon.Scripts.Managers;
using ResourceSystem;
using UnityEngine;

namespace BuildingSystem
{
    /// <summary>
    /// Класс с утилитарными методами для зданий
    /// </summary>
    public static class BuildingUtils
    {
        public static GameObject CreateNewBuilding([CanBeNull]GameObject placeHolder,
            BuildingSettings settings, int buildingLevel = 0)
        {
            var position = settings.Position;
            var buildingUpgrade = settings.UpgradesInfo[buildingLevel];
            var buildingPrefab = buildingUpgrade.UpgradePrefab;
            var rotation = buildingPrefab.transform.rotation;
            
            var building = Object.Instantiate(buildingPrefab, position, rotation);

            UpperWorldManager.BuildingManager.AddNewConstructedBuilding(placeHolder, building, settings);
            if (building.TryGetComponent<IBuilding>(out var buildingData))
            {
                buildingData.OnStateLoaded(settings.ID, buildingLevel);
            }

            return building;
        }

        public static void CreatePlaceHolder(BuildingSettings settings, List<Resource> requiredResources)
        {
            var position = settings.Position;
            var placeHolderPrefab = settings.PlaceHolderPrefab;
            var placeHolderRotation = placeHolderPrefab.transform.rotation;

            var placeHolder = Object.Instantiate(placeHolderPrefab, position, placeHolderRotation);
            var buildingController = placeHolder.GetComponent<BuildingPlaceholder>();
            buildingController.Initialize(settings, requiredResources);
            
            UpperWorldManager.BuildingManager.AddPlaceholder(placeHolder);
        }
    }
}
