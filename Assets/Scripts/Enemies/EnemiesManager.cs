using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : MonoBehaviour
    {
        public List<Enemy> Enemies => _enemies;
        
        [SerializeField] 
        private List<Enemy> _enemies;
        
        private void Awake()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].HealthSystem.EnemyDie += OnEnemyDie;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i])
                {
                    _enemies[i].HealthSystem.EnemyDie -= OnEnemyDie;
                }
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
            enemy.HealthSystem.EnemyDie += OnEnemyDie; 
        }
        
        private void OnEnemyDie(Enemy enemy)
        {
            enemy.HealthSystem.EnemyDie -= OnEnemyDie;
            Enemies.Remove(enemy);
        }
    }
}
