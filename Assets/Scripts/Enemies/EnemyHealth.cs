using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье врага
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        public float CurrentHealth => _health;
        
        [SerializeField] 
        private int _health;
        
        public event Action<GameObject> EnemyDie;
        
        public void ApplyDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                EnemyDie?.Invoke(gameObject);
                Destroy(gameObject);
            }
        }
    }
}