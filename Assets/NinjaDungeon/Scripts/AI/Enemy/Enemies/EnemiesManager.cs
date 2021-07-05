using System;
using System.Collections.Generic;
using Characteristics;
using NinjaDungeon.Scripts.Characteristics;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : MonoBehaviour
    {
        public event Action OnEnemyDead;
        public List<Enemy> Enemies => _enemies;
        
        [SerializeField] 
        private List<Enemy> _enemies = new List<Enemy>();

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            enemy.HealthBehaviour.OnDead += OnEnemyDied; 
        }

        public void ClearEnemies()
        {
            foreach (var enemy in _enemies)
            {
                Destroy(enemy);
            }
            
            _enemies.Clear();
        }
        
        private void OnEnemyDied(Person person)
        {
            var enemy = person.GetComponent<Enemy>();
            
            enemy.HealthBehaviour.OnDead -= OnEnemyDied;
            _enemies.Remove(enemy);
            
            OnEnemyDead?.Invoke();
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
