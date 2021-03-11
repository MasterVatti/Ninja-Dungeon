using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EnemyScripts.Spawner
{
    /// <summary>
    /// Спавнер врагов
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        public static Action AllWavesSpawned;

        [SerializeField]
        private List<Wave> _waves;
        [SerializeField]
        private List<Transform> _spawnPoints;
        [SerializeField]
        private float _waveCooldown;

        private Wave _currentWave;
        private float _nextWaveTime;

        private void Awake()
        {
            Wave.OnWaveCleared += OnWaveCleared;

            _currentWave = _waves[0];
            SpawnWave(_currentWave);
        }

        private void Update()
        {
            if (ShouldSpawnNextWave())
            {
                SpawnNextWave();
            }
        }

        private void OnWaveCleared()
        {
            SpawnNextWave();
        }

        private bool ShouldSpawnNextWave()
        {
            if (Time.time >= _nextWaveTime)
            {
                return true;
            }

            return false;
        }

        private void SpawnNextWave()
        {
            var currentWaveIndex =
                _waves.FindIndex(wave => wave == _currentWave);
            var nextWaveIndex = currentWaveIndex + 1;

            if (nextWaveIndex <= _waves.Count - 1)
            {
                _currentWave = _waves[nextWaveIndex];
                SpawnWave(_currentWave);
            }
            else
            {
                AllWavesSpawned?.Invoke();
                Destroy(gameObject);
            }
        }

        private void SpawnWave(Wave wave)
        {
            foreach (var enemyWithSpawnPoint in wave.EnemiesWithSpawnPoints)
            {
                var enemy = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;

                Instantiate(enemy, spawnPoint.position,
                    Quaternion.identity);
            }

            _nextWaveTime = Time.time + _waveCooldown;
        }

        private void OnDestroy()
        {
            Wave.OnWaveCleared -= OnWaveCleared;
        }
    }
}
