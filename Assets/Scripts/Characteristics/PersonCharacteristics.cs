using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Общий класс для всех мобов/игроков в игре
    /// </summary>
    public abstract class PersonCharacteristics : MonoBehaviour
    {
        protected List<Characteristic> Characteristics { get; set; }

        public Characteristic GetCharacteristic(CharacteristicType type)
        {
            return Characteristics.Find(characteristic => characteristic.Type == type);
        }

        public List<Characteristic> GetCharacteristics()
        {
            return Characteristics;
        }

        public int GetCharacteristicValue(CharacteristicType type)
        {
            return GetCharacteristic(type).CurrentValue;
        }
        
        public void ImproveCharacteristic(CharacteristicType type, int value = 1)
        {
            var characteristic = GetCharacteristic(type);
            characteristic.Level += value;
        }
    }
}
