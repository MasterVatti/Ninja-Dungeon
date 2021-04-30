using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : Singleton<EnemiesManager>
    {
        public List<Enemy> Enemies => _enemies;
        
        [SerializeField] 
        private List<Enemy> _enemies;
        
        private void Awake()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].HealthSystem.EntityDie += OnEntityDie;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i])
                {
                    _enemies[i].HealthSystem.EntityDie -= OnEntityDie;
                }
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
            enemy.HealthSystem.EntityDie += OnEntityDie; 
        }
        
        private void OnEntityDie(Enemy enemy)
        {
            enemy.HealthSystem.EntityDie -= OnEntityDie;
            Enemies.Remove(enemy);
        }
    }
}
