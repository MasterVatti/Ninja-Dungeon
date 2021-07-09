using Enemies;
using NinjaDungeon.Scripts.HealthBarSystem;
using SimpleEventBus.Disposables;
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

        private CompositeDisposable _subscriptions;

        protected virtual void Start()
        {
            _subscriptions = new CompositeDisposable()
            {
                EventStreams.UserInterface.Subscribe<GetAllPersonsEvent>(GetAllPersonsHandler)
            };
            EventStreams.UserInterface.Publish(new PersonCreatedEvent(this));
        }

        private void GetAllPersonsHandler(GetAllPersonsEvent eventData)
        {
            eventData.Persons.Add(this);
        }

        protected void OnDestroy()
        {
            _subscriptions?.Dispose();
            EventStreams.UserInterface.Publish(new PersonDestroyedEvent(this));
        }
    }
}
