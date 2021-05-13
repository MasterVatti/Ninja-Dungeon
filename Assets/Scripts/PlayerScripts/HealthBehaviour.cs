using System;
using Characteristics;
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
        
        private Person _person;
        
        private void Awake()
        {
            _person = GetComponent<Person>();
        }

        public void ApplyDamage(int damage)
        {
            _person.PersonCharacteristics.CurrentHp -= damage;
            
            if (_person.PersonCharacteristics.CurrentHp <= 0)
            {
                OnDead?.Invoke(_person);
            }
        }
    }
}