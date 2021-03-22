using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawner
{
    /// <summary>
    /// Спавнер врагов
    /// </summary>
    public class Spawner : Singleton<Spawner>
    {
        public event Action AllWavesCleared;

        [SerializeField]
        private List<Wave> _waves;
        [SerializeField]
        private float _waveCooldown;

        private Wave _currentWave;
        private float _nextWaveTime;

        private void Awake()
        {
            foreach (var wave in _waves)
            {
                wave.Initialize();
                wave.Controller.OnWaveCleared += OnWaveCleared;
            }

            SpawnNextWave();
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
            _currentWave ??= _waves[0];

            var currentWaveIndex =
                _waves.FindIndex(wave => wave == _currentWave);
            var nextWaveIndex = currentWaveIndex + 1;

            if (nextWaveIndex <= _waves.Count - 1)
            {
                _currentWave = _waves[nextWaveIndex];
                _currentWave.Controller.Spawn();
                
                _nextWaveTime = Time.time + _waveCooldown;
            }
        }

        private void OnWaveCleared()
        {
            if (_waves[_waves.Count - 1] == _currentWave)
            {
                AllWavesCleared?.Invoke();
                return;
            }

            SpawnNextWave();
        }
    }
}
