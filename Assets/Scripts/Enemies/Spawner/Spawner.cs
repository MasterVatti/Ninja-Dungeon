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
        private bool _hasCooldownTime;
        [SerializeField]
        private float _waveCooldown;

        private Wave _currentWave;
        private int _currentWaveIndex;

        private float _nextWaveTime;

        private void Awake()
        {
            _currentWaveIndex = -1;

            foreach (var wave in _waves)
            {
                wave.Initialize();
                wave.Controller.OnWaveDied += OnWaveDied;
            }

            SpawnNextWave();
        }

        private void Update()
        {
            if (ShouldSpawnNextWave() && HasNextWave())
            {
                SpawnNextWave();
            }
        }

        private bool ShouldSpawnNextWave()
        {
            return Time.time >= _nextWaveTime && _hasCooldownTime;
        }

        private bool HasNextWave()
        {
            var nextWaveIndex = _currentWaveIndex + 1;

            return nextWaveIndex <= _waves.Count - 1;
        }

        private void SpawnNextWave()
        {
            var nextWaveIndex = _currentWaveIndex + 1;

            _currentWave = _waves[nextWaveIndex];
            _currentWaveIndex = nextWaveIndex;
            _currentWave.Controller.Spawn();

            _nextWaveTime = Time.time + _waveCooldown;
        }

        private void OnWaveDied(Wave deadWave)
        {
            if (_waves[_waves.Count - 1] == _currentWave)
            {
                AllWavesCleared?.Invoke();
                return;
            }

            if (deadWave == GetPreviousWave())
            {
                SpawnNextWave();
            }
            
            // SpawnNextWave();
        }

        private Wave GetPreviousWave()
        {
            Wave previousWave = _currentWave;
            foreach (var wave in _waves)
            {
                if (wave == _currentWave)
                {
                    break;
                }   
                
                previousWave  = wave;
            }
            Debug.Log($"Кол-во врагов в умершей волне {previousWave.SpawnPointsData.Count}");
            return previousWave;
        }
    }
}
