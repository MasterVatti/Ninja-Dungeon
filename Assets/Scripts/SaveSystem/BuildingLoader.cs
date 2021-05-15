using BuildingSystem;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class BuildingLoader : ISaveDataLoader
    {
        public const string KEY = "buildings";
        
        [JsonProperty(KEY)]
        public BuildingData[] Buildings { get; set; }
        
        public void Load(string loader, DefaultSaveConfig saveConfig)
        {
            var buildingLoader = JsonConvert.DeserializeObject<BuildingLoader>(loader);
            
            Buildings = buildingLoader is null ? saveConfig.Buildings : buildingLoader.Buildings;
            
            foreach (var building in Buildings)
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
