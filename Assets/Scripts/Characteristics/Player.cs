using UnityEngine;

namespace Characteristics
{
    public class Player : MonoBehaviour
    {
        public PlayerCharacteristics PlayerCharacteristics => _playerCharacteristics;
        
        [SerializeField]
        private PlayerCharacteristics _playerCharacteristics;
    }
}
