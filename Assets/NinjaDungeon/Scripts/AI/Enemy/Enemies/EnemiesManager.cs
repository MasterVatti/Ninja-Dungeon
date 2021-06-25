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
        private List<Enemy> _enemies = new List<Enemy>();

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            enemy.HealthBehaviour.OnDead += OnEnemyDied; 
        }
        
        private void OnEnemyDied(Person person)
        {
            var enemy = person.GetComponent<Enemy>();
            
            enemy.HealthBehaviour.OnDead -= OnEnemyDied;
            _enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
        
        private void OnDestroy()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy)
                {
                    enemy.HealthBehaviour.OnDead -= OnEnemyDied;
                }
            }
        }
    }
}
