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

        public delegate void EnemyDieHandler(GameObject enemy);
        public event EnemyDieHandler EnemyDie;
        public List<GameObject> Enemies => _enemies;

        private void Awake()
        {
            Singleton = this;
        }

        public void OnEnemyDie(GameObject enemy)
        {
            EnemyDie?.Invoke(gameObject);
            Enemies.Remove(enemy);
        }
    }
}
