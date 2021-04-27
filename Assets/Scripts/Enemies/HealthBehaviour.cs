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
        public event Action<PersonCharacteristics> OnDead;
        
        private PersonCharacteristics _personCharacteristics;
        
        private void Awake()
        {
            _personCharacteristics = GetComponent<PersonCharacteristics>();
        }

        public void ApplyDamage(int damage)
        {
            _personCharacteristics.CurrentHp -= damage;
            
            if (_personCharacteristics.CurrentHp <= 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
            OnDead?.Invoke(_personCharacteristics);
            Destroy(gameObject);
        }
    }
}