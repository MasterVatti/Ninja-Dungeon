using System.Collections.Generic;
using BuildingSystem;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    /// <summary>
    /// Класс с утилитарными методами для сохранения
    /// </summary>
    public static class SaveCreator
    {
        public static IEnumerable<BuildingData> SaveConstructions()
        {
            var buildings = MainManager.BuildingManager.ActiveBuildings;
            var placeHolders = MainManager.BuildingManager.ActivePlaceHolders;
            var savedConstructions = new BuildingData[buildings.Count + placeHolders.Count];
            
            for(var i = 0; i < buildings.Count; i++)
            {
                if (buildings[i].TryGetComponent<IBuilding>(out var buildingData))
                {
                    savedConstructions[i] = buildingData.Save();
                    savedConstructions[i].BuildingLevel = buildingData.CurrentBuildingLevel;
                }
            }
            
            for(var i = 0; i < placeHolders.Count; i++)
            {
                var buildingController = placeHolders[i].GetComponent<BuildingController>();
                var placeHolderData = new PlaceHolderData
                {
                RemainResources = buildingController.RequiredResource
                };
                savedConstructions[i] = new BuildingData
                {
                SettingsID = buildingController.BuildingSettings.ID,
                State = JsonConvert.SerializeObject(placeHolderData)
                };
            }

            return savedConstructions;
        }

        public static IEnumerable<Resource> SaveResources()
        {
            return MainManager.ResourceManager.GetResources();
        }
    }
}
