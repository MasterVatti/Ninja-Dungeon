using System.Collections.Generic;
using BuildingSystem;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class BuildingLoader : ISaveDataLoader
    {
        public const string KEY = "buildings";
        public BuildingData[] BuildingData { get; set; }

        public BuildingLoader()
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

            BuildingData = savedConstructions.ToArray();
        }
        
        public void Load(string loader)
        {
            var buildingLoader = JsonConvert.DeserializeObject<BuildingLoader>(loader);
            
            BuildingData = buildingLoader is null ? BuildingData : buildingLoader.BuildingData;
            
            foreach (var building in BuildingData)
            {
                var settings = MainManager.BuildingManager.GetBuildingSettings(building.SettingsID);

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
    }
}
