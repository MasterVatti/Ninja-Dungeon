using System.Collections.Generic;
using Assets.Scripts;
using BuildingSystem;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class BuildingDataSaver : IDataSaver<BuildingData[]>
    {
        public const string KEY = GlobalConstants.BUILDING_KEY;
        
        [JsonProperty(KEY)]
        public BuildingData[] SaveData { get; private set; }

        public void Save()
        {
            var buildings = MainManager.BuildingManager.ActiveBuildings;
            var placeHolders = MainManager.BuildingManager.ActivePlaceHolders;
            var saveConstructions = new List<BuildingData>();

            foreach (var building in buildings)
            {
                if (building.TryGetComponent<IBuilding>(out var buildingData))
                {
                    saveConstructions.Add(buildingData.Save());
                }
            }

            foreach (var placeHolder in placeHolders)
            {
                var buildingController = placeHolder.GetComponent<BuildingController>();
                var placeHolderData = new PlaceHolderData
                {
                    RemainResources = buildingController.RequiredResource
                };
                
                saveConstructions.Add(new BuildingData
                {
                    SettingsID = buildingController.BuildingSettings.ID,
                    State = JsonConvert.SerializeObject(placeHolderData)
                });
            }
            
            SaveData = saveConstructions.ToArray();
        }
    }
}
