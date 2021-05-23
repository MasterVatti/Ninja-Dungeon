using System;
using Characteristics;
using ProjectileLauncher;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье
    /// </summary>
    [RequireComponent(typeof(PersonCharacteristics))]
    public class HealthBehaviour : MonoBehaviour
    {
        public event Action<Person> OnDead;

        [SerializeField]
        private Team _team;

        private Person _person;

        private void Awake()
        {
            _person = GetComponent<Person>();
        }

        public void ApplyDamage(Team damageDealerTeam, int damage)
        {
            if (damageDealerTeam == _team)
            {
                return;
            }

            _person.PersonCharacteristics.CurrentHp -= damage;
            if (_person.PersonCharacteristics.CurrentHp <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            OnDead?.Invoke(_person);
            Destroy(gameObject);
        }
    }
}