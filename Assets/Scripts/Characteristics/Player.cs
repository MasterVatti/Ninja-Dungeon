using Enemies;
using UnityEngine;

namespace Characteristics
{
    public class Player : MonoBehaviour
    {
        public PlayerCharacteristics PlayerCharacteristics => _playerCharacteristics;
        public Rigidbody Rigidbody => _rigidbody;
        public HealthBehaviour HealthBehaviour => _healthBehaviour;

        [SerializeField]
        private PlayerCharacteristics _playerCharacteristics;
        [SerializeField]
        private HealthBehaviour _healthBehaviour;
        [SerializeField]
        private Rigidbody _rigidbody;
    }
}
