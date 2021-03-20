using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : Singleton<EnemiesManager>
    {
        public List<GameObject> Enemies => _enemies;
        
        [SerializeField] 
        private List<GameObject> _enemies;
        
        private void Awake()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].GetComponent<EnemyHealth>().EnemyDie 
                    += OnEnemyDie;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i])
                {
                    _enemies[i].GetComponent<EnemyHealth>().EnemyDie 
                        -= OnEnemyDie;
                }
            }
        }

        public void AddEnemy(GameObject enemy)
        {
            Enemies.Add(enemy);
        }
        
        private void OnEnemyDie(GameObject enemy)
        {
            enemy.GetComponent<EnemyHealth>().EnemyDie -= OnEnemyDie;
            Enemies.Remove(enemy);
        }
    }
}
