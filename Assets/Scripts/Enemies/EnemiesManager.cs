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
        //public static EnemiesManager Singleton { get; private set; }
        public static EnemiesManager Singleton { get; private set; }
        [SerializeField] 
        private List<GameObject> _enemies;

        [SerializeField] private EnemyHealth _enemyHealth;
        public List<GameObject> Enemies => _enemies;
        
        private void Awake()
        {
            Singleton = this;
            EnemyHealth.Singleton.EnemyDie += OnEnemyDie;
        }
        
        private void OnDestroy()
        {
            //_enemyHealth.EnemyDie -= OnEnemyDie;
            EnemyHealth.Singleton.EnemyDie -= OnEnemyDie;
        }
        
        public void OnEnemyDie(GameObject enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
