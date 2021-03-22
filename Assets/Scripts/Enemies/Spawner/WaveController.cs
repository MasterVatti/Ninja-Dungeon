using System;
using Enemies;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Enemies.Spawner
{
    /// <summary>
    /// Класс управляет волной
    /// </summary>
    public class WaveController
    {
        public Action OnWaveCleared;

        private readonly Wave _wave;
        private int _enemiesCount;

        public WaveController(Wave wave)
        {
            _wave = wave;
            _enemiesCount = _wave.EnemiesWithSpawnPoints.Count;
        }

        public void Spawn()
        {
            foreach (var enemyWithSpawnPoint in _wave.EnemiesWithSpawnPoints)
            {
                var enemyPrefab = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;

                var enemy = Object.Instantiate(enemyPrefab,
                    spawnPoint.position,
                    Quaternion.identity);

                enemy.HealthSystem.EnemyDie += OnEnemyDeath;

                EnemiesManager.Instance.AddEnemy(enemy);
            }
        }

        private void OnEnemyDeath(global::Enemies.Enemy enemy)
        {
            _enemiesCount--;

            if (_enemiesCount == 0)
            {
                OnWaveCleared?.Invoke();
            }
        }
    }
}
