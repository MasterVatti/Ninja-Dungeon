using Enemies;
using NinjaDungeon.Scripts.HealthBarSystem;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Базовый класс хранящий в себе общие компоненты для мобов
    /// </summary>
    public class Person : MonoBehaviour
    {
        public Transform Chest => _chest != null ? _chest : transform;
        public Rigidbody Rigidbody => _rigidbody;
        public HealthBehaviour HealthBehaviour => _healthBehaviour;
        public PersonCharacteristics PersonCharacteristics => _personCharacteristics;
        
        [SerializeField]
        private PersonCharacteristics _personCharacteristics;
        [SerializeField]
        private HealthBehaviour _healthBehaviour;
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private Transform _chest;

        protected virtual void Start()
        {
            EventStreams.UserInterface.Publish(new PersonCreatedEvent(this));
        }

        protected void OnDestroy()
        {
            EventStreams.UserInterface.Publish(new PersonDestroyedEvent(this));
        }
    }
}
