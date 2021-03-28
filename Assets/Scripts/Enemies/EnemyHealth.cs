using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье врага
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        public event Action<Enemy> EnemyDie;
        
        public void ApplyDamage(int damage)
        {
            GetComponent<Enemy>().CurrentHp -= damage;
            if (GetComponent<Enemy>().CurrentHp <= 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
            EnemyDie?.Invoke(GetComponent<Enemy>());
            Destroy(gameObject);
        }
    }
}