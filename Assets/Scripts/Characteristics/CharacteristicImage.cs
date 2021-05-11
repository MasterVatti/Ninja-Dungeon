using System;
using UnityEngine;

namespace Characteristics
{
    [Serializable]
    public class CharacteristicImage
    {
        public CharacteristicType Type => _type;
        public Sprite Sprite => _sprite;
        
        [SerializeField]
        private CharacteristicType _type;
        [SerializeField]
        private Sprite _sprite;
    }
}
