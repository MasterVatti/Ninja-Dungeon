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
        public List<PersonCharacteristics> Enemies => _enemies;
        
        [SerializeField] 
        private List<PersonCharacteristics> _enemies;

        public void AddEnemy(PersonCharacteristics enemy)
        {
            Enemies.Add(enemy);
            enemy.HealthSystem.EnemyDie += OnEnemyDied; 
        }
        
        private void OnEnemyDied(PersonCharacteristics enemy)
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
