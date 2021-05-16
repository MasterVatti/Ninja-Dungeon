using System.Collections;
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

        private Dictionary<string, ISaveDataLoader> _loaders;
        private Dictionary<string, IDataSaver<IEnumerable>> _savers;
        
        private void Awake()
        {
            Load();
        }
        
        private void Load()
        {
            var json = PlayerPrefs.GetString("save");
            var savers = JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ?? 
                       new Dictionary<string, object>();

            SetLoaders();

            foreach (var loader in _loaders)
            {
                var value = "";
                if (savers.ContainsKey(loader.Key))
                {
                    value = JsonConvert.SerializeObject(savers[loader.Key]);
                }
                
                loader.Value.Load(value, _saveConfig);
            }
        }

        private void Save()
        {
            SetLoaders();
            SetSavers();

            foreach (var saver in _savers)
            {
                saver.Value.Save();
            }

            var json = JsonConvert.SerializeObject(_savers, Formatting.Indented);
            
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

        private void SetSavers()
        {
            _savers = new Dictionary<string, IDataSaver<IEnumerable>>
            {
                {ResourceDataSaver.KEY, new ResourceDataSaver()},
                {CharacteristicsDataSaver.KEY, new CharacteristicsDataSaver()},
                {BuildingDataSaver.KEY, new BuildingDataSaver()}
            };
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}
