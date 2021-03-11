using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.EnemyScripts.Spawner
{
    public class EnemiesSpawner : MonoBehaviour
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
            _currentWave = _waves[0];
            SpawnWave(_currentWave);

            _nextWaveTime = Time.time + _waveCooldown;
        }

        private void Update()
        {
            if (ShouldSpawnNextWave())
            {
                SpawnNextWave();
            }
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
            
            Debug.Log($"currentWave = {currentWaveIndex}, " +
                      $"nextWaveIndex = {nextWaveIndex}, " +
                      $"count = {_waves.Count}");

            if (nextWaveIndex <= _waves.Count - 1)
            {
                _currentWave = _waves[nextWaveIndex];
                SpawnWave(_currentWave);
            }
            else
            {
                AllWavesSpawned?.Invoke();
                Debug.Log("All waves cleared");
                Destroy(this);
            }
        }

        private void SpawnWave(Wave wave)
        {
            foreach (var enemy in wave.Enemies)
            {
                Instantiate(enemy, GetRandomSpawnPointCoordinates(),
                    Quaternion.identity);
            }
            
            _nextWaveTime = Time.time + _waveCooldown;
        }

        private Vector3 GetRandomSpawnPointCoordinates()
        {
            var random = new Random();
            var randomSpawnPointIndex = random.Next(_spawnPoints.Count);

            var spawnPoint = _spawnPoints[randomSpawnPointIndex];

            return spawnPoint.position;
        }
    }
}
