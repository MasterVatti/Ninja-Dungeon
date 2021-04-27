using Enemies;
using UnityEngine;

namespace Characteristics
{
    public class Enemy : MonoBehaviour
    {
        public EnemyCharacteristics EnemyCharacteristics => _enemyCharacteristics;
        public Rigidbody Rigidbody => _rigidbody;
        public HealthBehaviour HealthBehaviour => _healthBehaviour;
        
        [SerializeField]
        private EnemyCharacteristics _enemyCharacteristics;
        [SerializeField]
        private HealthBehaviour _healthBehaviour;
        [SerializeField]
        private Rigidbody _rigidbody;
    }
}
