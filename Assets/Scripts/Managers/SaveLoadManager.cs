using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using Newtonsoft.Json;
using ResourceSystem;
using SaveSystem;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Менеджер для сохранения и загрузки данных игры
    /// </summary>
    public class SaveLoadManager : MonoBehaviour
    {
        [SerializeField]
        private DefaultSaveConfig _saveConfig;
        private void Awake()
        {
            Load();
        }
        
        private Resource[] SaveResources() => MainManager.ResourceManager.GetResources().ToArray();


        public IEnumerable<BuildingData> SaveConstructions()
        {
            var buildings = MainManager.BuildingManager.ActiveBuildings;
            var placeHolders = MainManager.BuildingManager.ActivePlaceHolders;
            var savedConstructions = new List<BuildingData>();
            
            foreach (var building in buildings)
            {
                if (building.TryGetComponent<IBuilding>(out var buildingData))
                {
                    var save = buildingData.Save();
                    if (save == null)
                    {
                        continue;
                    }

                    savedConstructions.Add(save);
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
                    IsBuilt = false,
                    SettingsID = buildingController.BuildingSettings.ID,
                    State = JsonConvert.SerializeObject(placeHolderData)
                });
            }

            return savedConstructions;
        }
        
        private void Load()
        {
            var json = PlayerPrefs.GetString("save");
            var save = JsonConvert.DeserializeObject<Save>(json);
            
            if (save == null)
            {
                save = _saveConfig.DefaultSave;
            }
            
            var buildings = save.Buildings;
            var resources = save.Resources;
            foreach (var building in buildings)
            {
                
                var settings = MainManager.BuildingManager.GetBuildingSettings(building.SettingsID);
                var go = BuildingController.CreateNewBuilding(settings, building.IsBuilt);

                if (building.IsBuilt)
                {
                    if (go.TryGetComponent<IBuilding>(out var buildingData))
                    {
                        buildingData.Initialize(building.State);
                    }
                }
                else
                {
                    var placeHolderData = JsonConvert.DeserializeObject<PlaceHolderData>(building.State);
                    if (placeHolderData != null)
                    {
                        go.GetComponent<BuildingController>().RequiredResource = placeHolderData.RemainResources;
                    }
                }
            }

            MainManager.ResourceManager.SetResources(resources);
        }

        private void Save()
        {
            var save = new Save
            {
                Resources = SaveResources(), 
                Buildings = SaveConstructions().ToArray()
            };
            var json = JsonConvert.SerializeObject(save, Formatting.Indented);
            PlayerPrefs.SetString("save", json);
        }
        
        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
