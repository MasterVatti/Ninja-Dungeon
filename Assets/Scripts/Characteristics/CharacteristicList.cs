using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    public class CharacteristicList : MonoBehaviour
    {
        [SerializeField]
        private List<Characteristic> _allCharacteristics = new List<Characteristic>();

        public Characteristic GetCharacteristic(CharacteristicType type)
        {
            return _allCharacteristics.Find(characteristic => characteristic.Type == type);
        }
    }
}
