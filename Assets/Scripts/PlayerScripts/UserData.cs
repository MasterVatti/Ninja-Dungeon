using System.Collections.Generic;
using Characteristics;
using UnityEngine;

namespace PlayerScripts
{
    public class UserData : MonoBehaviour
    {
        public Dictionary<CharacteristicType, int> Characteristics { get; set; } =
            new Dictionary<CharacteristicType, int>();

        public List<Characteristic> GetCharacteristics()
        {
            var resultList = new List<Characteristic>();
            foreach (var characteristicPair in Characteristics)
            {
                var characteristic = GetCharacteristicFromAll(characteristicPair.Key);
                if (characteristic != null)
                {
                    characteristic.Level = characteristicPair.Value;
                    resultList.Add(characteristic);
                }
            }
            return resultList;
        }

        private static Characteristic GetCharacteristicFromAll(CharacteristicType type)
        {
            var allCharacteristics = MainManager.CharacteristicList.AllCharacteristics;
            return allCharacteristics.Find(character => character.Type == type);
        }
    }
}
