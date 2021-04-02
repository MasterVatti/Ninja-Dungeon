﻿using System;
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


        private static IEnumerable<BuildingData> SaveConstructions()
        {
            var buildings = MainManager.BuildingManager.ActiveBuildings;
            var placeHolders = MainManager.BuildingManager.ActivePlaceHolders;
            var savedConstructions = new BuildingData[buildings.Count];
            
            for(var i = 0; i < buildings.Count; i++)
            {
                var buildingData = buildings[i].GetComponent<IBuilding>().Save();
                savedConstructions[i] = buildingData;
            }
            
            for(var i = 0; i < placeHolders.Count; i++)
            {
                var buildingController = placeHolders[i].GetComponent<BuildingController>();
                savedConstructions[i] = new PlaceHolderData
                {
                    IsBuilt = false,
                    SettingsID = buildingController.BuildingSettings.ID,
                    RemainResources = buildingController.RequiredResource
                };
            }

            return savedConstructions;
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
                    
                    if (building.IsBuilt)
                    {
                        var buildingType = go.GetComponent<IBuilding>();
                        var state = JsonConvert.SerializeObject(building);
                        buildingType.Initialize(state);
                    }
                    else
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
                    
                }
            }

            if (resources != null)
            {
                MainManager.ResourceManager.SetResources(resources);
            }
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
