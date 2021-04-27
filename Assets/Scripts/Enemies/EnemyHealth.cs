using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье врага
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        public event Action<Characteristics.EnemyCharacteristics> EnemyDie;
        
        public void ApplyDamage(int damage)
        {
            GetComponent<Characteristics.EnemyCharacteristics>().CurrentHp -= damage;
            if (GetComponent<Characteristics.EnemyCharacteristics>().CurrentHp <= 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
            EnemyDie?.Invoke(GetComponent<Characteristics.EnemyCharacteristics>());
            Destroy(gameObject);
        }
    }
}