using System;
using System.Collections.Generic;
using System.Linq;
using BuildingSystem;
using Newtonsoft.Json;
using ResourceSystem;
using UnityEngine;

namespace SaveSystem
{
    /// <summary>
    /// Менеджер для сохранения и загрузки данных игры
    /// </summary>
    public class SaveLoadManager : MonoBehaviour
    {
        private void Awake()
        {
            Load();
        }
        
        private static Resource[] SaveResources() => MainManager.ResourceManager.GetResources().ToArray();


        private static IEnumerable<BuildingData> SaveBuildings()
        {
            var buildings = MainManager.BuildingManager.ActiveBuildings;
            var savedBuildings = new BuildingData[buildings.Count];
            
            for(var i = 0; i < buildings.Count; i++)
            {
                var buildingData = buildings[i].GetComponent<IBuilding>().Save();
                savedBuildings[i] = buildingData;
            }

            return savedBuildings;
        }

        private static IEnumerable<BuildingData> SavePlaceHolders()
        {
            var placeHolders = MainManager.BuildingManager.ActivePlaceHolders;
            var savedPlaceHolders = new BuildingData[placeHolders.Count];
            
            for(var i = 0; i < placeHolders.Count; i++)
            {
                var buildingController = placeHolders[i].GetComponent<BuildingController>();
                savedPlaceHolders[i] = new PlaceHolderData
                {
                    IsBuilt = false,
                    SettingsID = buildingController.BuildingSettings.ID,
                    RemainResources = buildingController.RequiredResource
                };
            }

            return savedPlaceHolders;
        }
        
        private void Load()
        {
            var json = PlayerPrefs.GetString("save");
            var save = JsonConvert.DeserializeObject<Save>(json);
            
            BuildingData[] buildings = {};
            Resource[] resources = {};
            
            if (save != null)
            {
                buildings = save.Buildings;
                resources = save.Resources;
            }

            if (buildings != null)
            {
                foreach (var building in buildings)
                {
                    var settings =  MainManager.BuildingManager.GetBuildingSettings(building.SettingsID);
                    var go = BuildingController.CreateNewBuilding(settings, building.IsBuilt);
                    
                    if (!building.IsBuilt)
                    {
                        var remainResources = new List<Resource>();
                        foreach (var resource in building.State)
                        {
                            remainResources.Add(new Resource()
                            {
                                Type = (ResourceType)Convert.ToInt32(resource.Key),
                                Amount = Convert.ToSingle(resource.Value)
                            });
                        }
                        go.GetComponent<BuildingController>().RequiredResource = remainResources;
                    }
                    
                    if(go.TryGetComponent<IBuilding>(out var buildingType))
                    {
                        buildingType.Initialize(building.State);
                    }
                }
            }

            if (resources != null)
            {
                MainManager.ResourceManager.SetResources(resources);
            }
        }

        private void Save()
        {
            var saveBuildings = SaveBuildings().Concat(SavePlaceHolders());
            var save = new Save
            {
                Resources = SaveResources(), 
                Buildings = saveBuildings.ToArray()
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
