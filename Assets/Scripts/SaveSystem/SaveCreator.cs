using System.Collections.Generic;
using BuildingSystem;
using Characteristics;
using ExperienceSystem;
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
            var savedConstructions = new List<BuildingData>();

            foreach (var building in buildings)
            {
                if (building.TryGetComponent<IBuilding>(out var buildingData))
                {
                    savedConstructions.Add(buildingData.Save());
                }
            }

            foreach (var placeHolder in placeHolders)
            {
                var buildingController = placeHolder.GetComponent<BuildingController>();
                var placeHolderData = new PlaceHolderData
                {
                RemainResources = buildingController.RequiredResource
                };
                savedConstructions.Add(new BuildingData
                {
                SettingsID = buildingController.BuildingSettings.ID,
                State = JsonConvert.SerializeObject(placeHolderData)
                });
            }

            return savedConstructions;
        }

        public static PlayerData SavePlayer()
        {
            var player = (PlayerCharacteristics)MainManager.Player.PersonCharacteristics;

            var playerData = new PlayerData
            {
                ExperienceUpperWorld = player.ExperienceUpperWorld,
                LevelUpperWorld = player.LevelUpperWorld,
                MaximumExperienceLevelUpperWorld = player.MaximumExperienceLevelUpperWorld
            };

            return playerData;
        }

        public static IEnumerable<Resource> SaveResources()
        {
            return MainManager.ResourceManager.GetResources();
        }
    }
}
