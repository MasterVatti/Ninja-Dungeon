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
            _healthBar.NormalizePosition(transform.position);
        }

        private void Update()
        {
            _healthBar.NormalizePosition(transform.position);
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