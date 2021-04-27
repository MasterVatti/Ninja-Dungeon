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
        public event Action<PersonCharacteristics> EnemyDie;
        
        private PersonCharacteristics _personCharacteristics;
        
        private void Awake()
        {
            _personCharacteristics = GetComponent<PersonCharacteristics>();
        }

        public void ApplyDamage(int damage)
        {
            var currentHp = _personCharacteristics.CurrentHp;
            
            currentHp -= damage;
            
            if (currentHp <= 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
            EnemyDie?.Invoke(_personCharacteristics);
            Destroy(gameObject);
        }
    }
}