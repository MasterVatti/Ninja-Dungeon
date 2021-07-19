using System;
using System.Linq;
using Energy;
using Newtonsoft.Json;
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
            LoadResources();
        }

        public void LoadAll()
        {
            LoadBuildings();
            LoadPlayer();
            LoadResources();
        }

        public void SaveAll()
        {
            SaveBuildings();
            SavePlayer();
            SaveResources();
        }
        
        private void LoadBuildings()
        {
            var json = PlayerPrefs.GetString("saveBuildings");
            var save = JsonConvert.DeserializeObject<SaveBuildings>(json) ?? _saveConfig.DefaultSaveBuildings;
           
            var buildings = save.Buildings;
            
            if (buildings != null)
            {
                SaveInitializer.InitializeBuildings(buildings.ToList());
            }
        }
        
        private void LoadPlayer()
        {
            var json = PlayerPrefs.GetString("savePlayer");
            var save = JsonConvert.DeserializeObject<SavePlayer>(json) ?? _saveConfig.DefaultSavePlayer;
            var player = save.Player;

            if (player != null)
            {
                SaveInitializer.InitializePlayer(player);
            }
        }     
        private void LoadResources()
        {
            var json = PlayerPrefs.GetString("saveResources");
            var save = JsonConvert.DeserializeObject<SaveResources>(json) ?? _saveConfig.DefaultSaveResources;
            var resources = save.Resources;

            if (resources != null)
            {
                SaveInitializer.InitializeResources(resources.ToList());
            }
        }
        
        private void SaveBuildings()
        {
            var save = new SaveBuildings(SaveCreator.SaveConstructions().ToArray());
            var json = JsonConvert.SerializeObject(save, Formatting.Indented);
            PlayerPrefs.SetString("saveBuildings", json);
        }

        public void SavePlayer()
        {
            var save = new SavePlayer(SaveCreator.SavePlayer());
            var json = JsonConvert.SerializeObject(save, Formatting.Indented);
            PlayerPrefs.SetString("savePlayer", json);
        }

        public void SaveResources()
        {
            var save = new SaveResources(SaveCreator.SaveResources().ToArray());
            var json = JsonConvert.SerializeObject(save, Formatting.Indented);
            PlayerPrefs.SetString("saveResources", json);
        }
        
        private void OnApplicationQuit()
        {
            SaveAll();
        }
    }
}
