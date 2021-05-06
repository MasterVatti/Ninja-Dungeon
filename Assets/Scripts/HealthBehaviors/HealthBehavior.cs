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
        [SerializeField] 
        private HealthBehaviorsManager _healthBehaviorsManager;
        
        public event Action<Enemy> EntityDie;

        private void Awake()
        {
            _healthBehaviorsManager.AddToHealthBehaviors(this);
        }

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
            EntityDie?.Invoke(GetComponent<Enemy>());
            _healthBehaviorsManager.RemoveFromHealthBehaviors(this);
            Destroy(gameObject);
        }
    }
}