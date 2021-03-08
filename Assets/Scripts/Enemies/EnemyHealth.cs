using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Уменьшение здоровья врага при попадании пули
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _health;
        [SerializeField] 
        private EnemiesManager _enemiesManager;
        
        public delegate void EnemyDieHandler(GameObject enemy);
        public static event EnemyDieHandler EnemyDie;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health -= ProjectileLauncher.ProjectileShell.Singleton.Damage;
                if (_health <= 0)
                {
                    var enemies = _enemiesManager.enemies;
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i] == gameObject)
                        {
                            EnemyDie += _enemiesManager.OnEnemyDie;
                            EnemyDie?.Invoke(_enemiesManager.enemies[i]);
                        }
                    }
                    Destroy(gameObject);
                }
            }
        }

        private void OnDestroy()
        {
            EnemyDie -= _enemiesManager.OnEnemyDie;
        }
    }

    
}