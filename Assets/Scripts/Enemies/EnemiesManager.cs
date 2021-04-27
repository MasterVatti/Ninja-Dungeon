using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : MonoBehaviour
    {
        public List<Characteristics.EnemyCharacteristics> Enemies => _enemies;
        
        [SerializeField] 
        private List<Characteristics.EnemyCharacteristics> _enemies;

        public void AddEnemy(Characteristics.EnemyCharacteristics enemy)
        {
            Enemies.Add(enemy);
            enemy.HealthSystem.EnemyDie += OnEnemyDied; 
        }
        
        private void OnEnemyDied(Characteristics.EnemyCharacteristics enemy)
        {
            enemy.HealthSystem.EnemyDie -= OnEnemyDied;
            Enemies.Remove(enemy);
        }
        
        private void OnDestroy()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i])
                {
                    _enemies[i].HealthSystem.EnemyDie -= OnEnemyDied;
                }
            }
        }
    }
}
