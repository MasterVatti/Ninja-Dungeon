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
        public Action AllWavesCleared;

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
            _currentWave.Spawn();
            _nextWaveTime = Time.time + _waveCooldown;
           
            _currentWave.OnWaveCleared += OnWaveCleared;
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
            if (_waves[_waves.Count] == _currentWave)
            {
                AllWavesCleared?.Invoke();
                return;
            }
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
                _currentWave.OnWaveCleared -= OnWaveCleared;
                _currentWave = _waves[nextWaveIndex];
                _currentWave.OnWaveCleared += OnWaveCleared;
                
                _currentWave.Spawn();
                
                _nextWaveTime = Time.time + _waveCooldown;
            }
        }

        private void OnDestroy()
        {
            _currentWave.OnWaveCleared -= OnWaveCleared;
        }
    }
}
