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
        public event Action<Wave> OnWaveDied;

        private readonly Wave _wave;
        private int _enemiesCount;

        public WaveController(Wave wave)
        {
            _wave = wave;
            _enemiesCount = _wave.SpawnPointsData.Count;
        }

        public void Spawn()
        {
            foreach (var enemyWithSpawnPoint in _wave.SpawnPointsData)
            {
                var enemyPrefab = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;

                var enemy = Object.Instantiate(enemyPrefab,
                    spawnPoint.position,
                    Quaternion.identity);

                enemy.HealthSystem.EnemyDie += OnEnemyDied;

                EnemiesManager.Instance.AddEnemy(enemy);
            }
        }

        private void OnEnemyDied(global::Enemies.Enemy enemy)
        {
            _enemiesCount--;

            if (_enemiesCount == 0)
            {
                OnWaveDied?.Invoke(_wave);
            }
        }
    }
}
