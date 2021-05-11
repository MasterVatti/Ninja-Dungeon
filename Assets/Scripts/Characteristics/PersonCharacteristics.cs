using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Общий класс для всех мобов/игроков в игре
    /// </summary>
    public abstract class PersonCharacteristics : MonoBehaviour
    {
        public List<Characteristic> Characteristics { get; protected set; }

        public Characteristic GetCharacteristic(CharacteristicType type)
        {
            return Characteristics.Find(characteristic => characteristic.Type == type);
        }
    }
}
