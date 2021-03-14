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

        [SerializeField] 
        private List<GameObject> _enemies;

        public List<GameObject> Enemies => _enemies;
        
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
                _enemies[i].GetComponent<EnemyHealth>().EnemyDie 
                    -= OnEnemyDie;
            }
        }

        private void OnEnemyDie(GameObject enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
