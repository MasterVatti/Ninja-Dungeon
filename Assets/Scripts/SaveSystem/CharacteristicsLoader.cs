using System.Collections.Generic;
using Characteristics;
using Newtonsoft.Json;

namespace SaveSystem
{
    public class CharacteristicsLoader : ISaveDataLoader
    {
        public const string KEY = "characteristics";

        public Dictionary<CharacteristicType, int> Characteristics { get; private set; }

        public CharacteristicsLoader()
        {
            Characteristics = MainManager.UserData.Characteristics;
        }

        public void Load(string loader)
        {
            var characteristicLoader = JsonConvert.DeserializeObject<CharacteristicsLoader>(loader);
            
            Characteristics = characteristicLoader is null? Characteristics : characteristicLoader.Characteristics;
            MainManager.UserData.Characteristics = Characteristics;
        }

        public void Initialize(IEnumerable<CharacteristicType> characteristicTypes)
        {
            var characteristics = new Dictionary<CharacteristicType, int>();
            foreach (var characteristicType in characteristicTypes)
            {
                characteristics.Add(characteristicType, 0);
            }

            Characteristics = characteristics;
        }
    }
}
