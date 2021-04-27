using Enemies;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Базовый класс хранящий в себе общие компоненты для мобов
    /// </summary>
    public class Person : MonoBehaviour
    {
        public Rigidbody Rigidbody => _rigidbody;
        public HealthBehaviour HealthBehaviour => _healthBehaviour;
    
        [SerializeField]
        private HealthBehaviour _healthBehaviour;
        [SerializeField]
        private Rigidbody _rigidbody;
    }
}
