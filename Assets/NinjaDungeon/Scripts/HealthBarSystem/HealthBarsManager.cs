using System;
using System.Collections.Generic;
using Characteristics;
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

            _subscriptions = new CompositeDisposable()
            {
                EventStreams.UserInterface.Subscribe<PersonCreatedEvent>(OnPersonCreated),
                EventStreams.UserInterface.Subscribe<PersonDestroyedEvent>(OnPersonDestroyed),
            };
        }

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }

        private void OnPersonCreated(PersonCreatedEvent eventData)
        {
            var person = eventData.Person;
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