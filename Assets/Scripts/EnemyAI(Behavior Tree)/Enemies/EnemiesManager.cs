using System.Collections.Generic;
using Characteristics;
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

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            enemy.HealthBehaviour.OnDead += OnEnemyDied; 
        }
        
        private void OnEnemyDied(Person person)
        {
            var enemy = person.GetComponentInChildren<Enemy>();
            _enemies.Remove(enemy);
            enemy.HealthBehaviour.OnDead -= OnEnemyDied;
        }
        
        private void OnDestroy()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i])
                {
                    _enemies[i].HealthBehaviour.OnDead -= OnEnemyDied;
                }
            }
        }
    }
}
