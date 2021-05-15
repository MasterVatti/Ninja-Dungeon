using System.Collections.Generic;
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
        
        private Dictionary<string, ISaveDataLoader> _loaders = new Dictionary<string, ISaveDataLoader>();
        
        private void Awake()
        {
            Load();
        }
        
        private void Load()
        {
            var json = PlayerPrefs.GetString("save");
            var savedLoaders = JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ?? 
                       new Dictionary<string, object>();

            SetLoaders();
            
            foreach (var loader in _loaders)
            {
                var value = "";
                if (savedLoaders.ContainsKey(loader.Key))
                {
                    value = JsonConvert.SerializeObject(savedLoaders[loader.Key]);
                }
                
                _loaders[loader.Key].Load(value, _saveConfig);
            }
        }

        private void Save()
        {
            SetLoaders();
            
            var json = JsonConvert.SerializeObject(_loaders, Formatting.Indented);
            
            PlayerPrefs.SetString("save", json);
        }

        private void SetLoaders()
        {
            _loaders = new Dictionary<string, ISaveDataLoader>
            {
                {BuildingLoader.KEY, new BuildingLoader()},
                {ResourceLoader.KEY, new ResourceLoader()},
                {CharacteristicsLoader.KEY, new CharacteristicsLoader()}
            };
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
