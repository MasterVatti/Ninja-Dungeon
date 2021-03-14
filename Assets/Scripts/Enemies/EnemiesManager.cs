using System;
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
            EnemyHealth.EnemyDie += OnEnemyDie;
        }

        private void OnDestroy()
        {
            EnemyHealth.EnemyDie += OnEnemyDie;
            //EnemyHealth.EnemyDie -= OnEnemyDie;
        }

        private void OnEnemyDie(GameObject enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
