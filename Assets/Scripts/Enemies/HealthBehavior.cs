using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье сущности
    /// </summary>
    public class HealthBehavior : MonoBehaviour
    {
        [SerializeField]
        private int _health;
        [SerializeField]
        private HealthBarsManager _healthBarsManager;
        
        public event Action<Enemy> EnemyDie;

        private HealthBar _healthBar;
        
        private void Awake()
        {
            _healthBar = _healthBarsManager.CreateHealthBar();
            _healthBar.SetMaximalHealth(_health);
        }

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            _healthBar.SetHealthBarValue(_health);
            if (_health <= 0)
            {
                Death();
                _healthBar.Destroy();
            }
        }
        
        private void Death()
        {
            EnemyDie?.Invoke(GetComponent<Enemy>());
            Destroy(gameObject);
        }
    }
}