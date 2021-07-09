using System;
using System.Collections.Generic;
using Characteristics;
using SimpleBus.Extensions;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace NinjaDungeon.Scripts.HealthBarSystem
{
    public class HealthBarsManager : MonoBehaviour
    {
        [SerializeField]
        private PersonHealthBar _healthBarPrefab;

        [SerializeField]
        private RectTransform _container;

        private readonly Dictionary<Person, PersonHealthBar> _personHealthBars = new Dictionary<Person, PersonHealthBar>();
        private MonoBehaviourPool<PersonHealthBar> _healthBarsPool;
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _healthBarsPool = new MonoBehaviourPool<PersonHealthBar>(_healthBarPrefab, _container);

            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<PersonCreatedEvent>(OnPersonCreated),
                EventStreams.UserInterface.Subscribe<PersonDestroyedEvent>(OnPersonDestroyed),
            };

            CreateHealthBarForAlreadyCreatedPersons();
        }

        private void CreateHealthBarForAlreadyCreatedPersons()
        {
            var getAllPersonsEvent = new GetAllPersonsEvent();
            getAllPersonsEvent.Publish(EventStreams.UserInterface);

            foreach (var person in getAllPersonsEvent.Persons)
            {
                CreateHealthBar(person);
            }
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }

        private void OnPersonCreated(PersonCreatedEvent eventData)
        {
            var person = eventData.Person;
            CreateHealthBar(person);
        }

        private void CreateHealthBar(Person person)
        {
            var personHealthBar = _healthBarsPool.Take();
            personHealthBar.Initialize(person);
            _personHealthBars[person] = personHealthBar;
        }

        private void OnPersonDestroyed(PersonDestroyedEvent eventData)
        {
            var person = eventData.Person;
            if (_personHealthBars.ContainsKey(person))
            {
                _healthBarsPool.Release(_personHealthBars[person]);
            }
        }
    }
}