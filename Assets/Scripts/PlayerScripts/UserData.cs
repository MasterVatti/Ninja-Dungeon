using System.Collections.Generic;
using Buildings.PlayerCharacteristicsImprove;
using Characteristics;
using Newtonsoft.Json;
using UnityEngine;

namespace PlayerScripts
{
    public class UserData : MonoBehaviour
    {
        [JsonProperty("playerCharacteristics")]
        public Dictionary<CharacteristicType, int> Characteristics { get; set; } =
            new Dictionary<CharacteristicType, int>();

        [SerializeField]
        private DefaultCharacteristics _defaultCharacteristics;

        private void Awake()
        {
            if (Characteristics.Count == 0)
            {
                foreach (var characteristic in _defaultCharacteristics.Characteristics)
                {
                    Characteristics.Add(characteristic, 0);
                }
            }
        }

        public List<Characteristic> GetCharacteristics()
        {
            var resultList = new List<Characteristic>();
            foreach (var characteristicPair in Characteristics)
            {
                var characteristic = GetCharacteristic(characteristicPair.Key);
                if (characteristic != null)
                {
                    characteristic.Level = characteristicPair.Value;
                    resultList.Add(characteristic);
                }
            }

            return resultList;
        }

        private Characteristic GetCharacteristic(CharacteristicType type)
        {
            var allCharacteristics = MainManager.CharacteristicList.AllCharacteristics;
            return allCharacteristics.Find(character => character.Type == type);
        }
    }
}
