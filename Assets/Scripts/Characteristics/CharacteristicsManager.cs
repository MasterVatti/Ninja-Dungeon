using System;
using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// управление характеристиками
    /// </summary>
    public class CharacteristicsManager : MonoBehaviour
    {
        [SerializeField]
        private List<Characteristic> _characteristics;

        public void AddToList(Characteristic characteristicToAdd)
        {
            _characteristics.Add(characteristicToAdd);
            InitializeCharacteristic(characteristicToAdd);
        }
            
        public void RemoveFromList(Characteristic characteristicToRemove)
        {
            _characteristics.Remove(characteristicToRemove);
        }

        private void InitializeCharacteristic(Characteristic characteristic)
        {
            var addedCharacteristic =
                Instantiate(characteristic, transform.position, transform.rotation);
        }
    }
}
