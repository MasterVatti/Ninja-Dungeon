using System;
using HealthBars;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье сущности
    /// </summary>
    public class HealthBehavior : MonoBehaviour
    {
        public int Health => _health;

        [SerializeField]
        private int _health;
        
        public event Action<Enemy> EnemyDie;
        public event Action<int> HealthBarValueDecrease;

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            if (GetComponent<HealthBarOnEnemy>())
            {
                HealthBarValueDecrease?.Invoke(_health);
            }
            if (_health <= 0)
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