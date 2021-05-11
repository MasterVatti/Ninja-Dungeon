using System.Collections.Generic;
using UnityEngine;

namespace Characteristics
{
    public class CharacteristicList : MonoBehaviour
    {
        public List<Characteristic> AllCharacteristics => _allCharacteristics;
        
        [SerializeField]
        private List<Characteristic> _allCharacteristics = new List<Characteristic>();
    }
}
