using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : MonoBehaviour
    {
        public static EnemiesManager Singleton { get; private set; }

        public List<GameObject> Enemies => _enemies;
        
        [SerializeField] 
        private List<GameObject> _enemies;
        
        private void Awake()
        {
            Singleton = this;
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

        private void OnEnemyDie(GameObject enemy)
        {
            enemy.GetComponent<EnemyHealth>().EnemyDie -= OnEnemyDie;
            Enemies.Remove(enemy);
        }
    }
}
