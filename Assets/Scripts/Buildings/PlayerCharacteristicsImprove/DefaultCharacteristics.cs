using System.Collections.Generic;
using Characteristics;
using UnityEngine;

namespace Buildings.PlayerCharacteristicsImprove
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DefaultCharacteristics", order = 0)]
    public class DefaultCharacteristics : ScriptableObject
    {
        public List<CharacteristicType> Characteristics => _characteristics;
        
        [SerializeField]
        private List<CharacteristicType> _characteristics;
    }
}
