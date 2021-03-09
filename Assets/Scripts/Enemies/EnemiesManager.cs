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
        public delegate void EnemyDieHandler(GameObject enemy);

        public event EnemyDieHandler EnemyDie;
        
        private void Awake()
        {
            Singleton = this;
            EnemyDie += OnEnemyDie;
        }
        
        private void OnDestroy()
        {
            EnemyDie -= OnEnemyDie;
        }
        
        public void OnEnemyDie(GameObject enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
