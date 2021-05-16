using System.Collections.Generic;
using Assets.Scripts;
using Characteristics;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class CharacteristicsDataSaver : IDataSaver<Dictionary<CharacteristicType, int>>
    {
        public const string KEY = GlobalConstants.CHARACTERISTICS_KEY;
        
        [JsonProperty(KEY)]
        public Dictionary<CharacteristicType, int> SaveData { get; } = new Dictionary<CharacteristicType, int>();

        public void Save()
        {
            SaveData.Clear();
            
            var playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            var characteristics = playerCharacteristics.GetCharacteristics();

            foreach (var characteristic in characteristics)
            {
                SaveData.Add(characteristic.Type, characteristic.Level);
            }
        }
    }
}
