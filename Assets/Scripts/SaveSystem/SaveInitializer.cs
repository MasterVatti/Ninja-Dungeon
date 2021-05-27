using System.Collections.Generic;
using BuildingSystem;
using Characteristics;
using ExperienceSystem;
using Newtonsoft.Json;
using ResourceSystem;

namespace SaveSystem
{
    /// <summary>
    /// Класс с утилитарными методами для инициализации сохраненных данных
    /// </summary>
    public static class SaveInitializer
    {
        public static void InitializeBuildings(IEnumerable<BuildingData> buildings)
        {
            foreach (var building in buildings)
            {
                var settings =  MainManager.BuildingManager.GetBuildingSettings(building.SettingsID);

                var placeHolderData = JsonConvert.DeserializeObject<PlaceHolderData>(building.State);
                if (placeHolderData?.RemainResources != null)
                {
                    var newPlaceHolder = BuildingUtils.CreateNewPlaceHolder(settings);
                    var buildingController = newPlaceHolder.GetComponent<BuildingController>();
                    buildingController.RequiredResource = placeHolderData.RemainResources;
                }
                else
                {
                    var newBuilding = BuildingUtils.CreateNewBuilding(settings, building.BuildingLevel);
                    if (newBuilding.TryGetComponent<IBuilding>(out var buildingData))
                    {
                        buildingData.LoadState(building.State);
                    }
                }
            }
        }

        public static void InitializePlayer(PlayerData playerData)
        {
            var player = (PlayerCharacteristics)MainManager.Player.PersonCharacteristics;

            player.ExperienceUpperWorld = playerData.ExperienceUpperWorld;
            player.LevelUpperWorld = playerData.LevelUpperWorld;
            player.MaximumExperienceLevelUpperWorld = playerData.MaximumExperienceLevelUpperWorld;
        }

        public static void InitializeResources(IEnumerable<Resource> resources)
        {
            MainManager.ResourceManager.SetResources(resources);
        }
    }
}
