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
        
        public int CurrentHP { get; private set; }
        
        private Person _person;

        private void Awake()
        {
            _person = GetComponent<Person>();
            CurrentHP = _person.PersonCharacteristics.GetCharacteristicValue(CharacteristicType.MaxHP);
        }

        public void ApplyDamage(int damage)
        {
            CurrentHP -= damage;
            
            if (CurrentHP <= 0)
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