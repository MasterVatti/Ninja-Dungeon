using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    {
        public PlayerCharacteristics PlayerCharacteristics => _playerCharacteristics;
        
        [SerializeField]
        private PlayerCharacteristics _playerCharacteristics;
    }
}
