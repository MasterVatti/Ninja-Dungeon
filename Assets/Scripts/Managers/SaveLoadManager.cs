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
            Load();
        }
        
        private void Load()
        {
            var json = PlayerPrefs.GetString("save");
            var save = JsonConvert.DeserializeObject<Save>(json) ?? _saveConfig.DefaultSave;

            var buildings = save.Buildings;
            var resources = save.Resources;

            if (buildings != null)
            {
                SaveInitializer.InitializeBuildings(buildings.ToList());
            }

            if (resources != null)
            {
                SaveInitializer.InitializeResources(resources.ToList());
            }
        }

        private void Save()
        {
            var save = new Save
            {
                Resources = SaveCreator.SaveResources().ToArray(), 
                Buildings = SaveCreator.SaveConstructions().ToArray()
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
