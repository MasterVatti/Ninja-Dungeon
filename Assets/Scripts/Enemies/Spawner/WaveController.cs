using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Task = System.Threading.Tasks.Task;

namespace Enemies.Spawner
{
    /// <summary>
    /// Класс управляет волной
    /// </summary>
    public class WaveController
    {
        public event Action OnWaveDied;
        public bool AlreadySpawned;
        public bool IsFinished;

        private readonly WaveData _waveData;
        private int _enemiesCount;

        public WaveController(WaveData waveData)
        {
            _waveData = waveData;
            _enemiesCount = _waveData.SpawnPointsData.Count;
        }

        public async void Start(bool useDelay)
        {
            if (useDelay)
            {
                var delayInMilliseconds = (int) (_waveData.CooldownTime * 1000);
                await Task.Delay(delayInMilliseconds);
            }

            foreach (var enemyWithSpawnPoint in _waveData.SpawnPointsData)
            {
                var enemyPrefab = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;

                var enemy = Object.Instantiate(enemyPrefab,
                    spawnPoint.position,
                    Quaternion.identity);

                enemy.HealthSystem.EnemyDie += OnEnemyDied;

                EnemiesManager.Instance.AddEnemy(enemy);
            }

            AlreadySpawned = true;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            _enemiesCount--;

            if (_enemiesCount == 0)
            {
                IsFinished = true;
                OnWaveDied?.Invoke();
            }
        }
    }
}
