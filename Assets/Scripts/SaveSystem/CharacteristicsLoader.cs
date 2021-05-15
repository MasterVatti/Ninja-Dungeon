using System.Collections.Generic;
using System.Linq;
using Characteristics;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class CharacteristicsLoader : ISaveDataLoader
    {
        public const string KEY = "characteristics";

        [JsonProperty(KEY)]
        public Dictionary<CharacteristicType, int> Characteristics { get; private set; }

        public void Load(string loader, DefaultSaveConfig saveConfig)
        {
            var characteristicLoader = JsonConvert.DeserializeObject<CharacteristicsLoader>(loader);

            Characteristics = characteristicLoader is null
            ? GetCharacteristicsDictionary(saveConfig.Characteristics) : characteristicLoader.Characteristics;
            
            MainManager.UserData.Characteristics = Characteristics;
        }

        private Dictionary<CharacteristicType, int> GetCharacteristicsDictionary(IEnumerable<CharacteristicType> 
        characteristicTypes)
        {
            return characteristicTypes.ToDictionary(characteristicType => characteristicType, characteristicType => 0);
        }
    }
}
