using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spawner
{
    /// <summary>
    /// Спавнер врагов
    /// </summary>
    public class Spawner : Singleton<Spawner>
    {
        public event Action AllWavesCleared;

        [SerializeField]
        private List<WaveData> _wavesData;

        private readonly Queue<WaveController> _waves =
            new Queue<WaveController>();
        private WaveController _activeWave;
        private WaveController _nextWave;

        private void Awake()
        {
            foreach (var wave in _wavesData)
            {
                var waveController = new WaveController(wave);
                waveController.OnWaveDied += OnWaveDied;

                _waves.Enqueue(waveController);
            }

            StartNextWave(false);
        }

        private void Update()
        {
            if (_activeWave != null && _activeWave.IsFinished)
            {
                StartNextWave(true);
            }
        }

        private void OnWaveDied()
        {
            StartNextWave(false);
        }

        private void StartNextWave(bool useDelay)
        {
            if (_waves.Count > 1)
            {
                _activeWave = _waves.Dequeue();

                if (!_activeWave.AlreadySpawned)
                {
                    _activeWave?.Start(useDelay);
                }
                else
                {
                    _activeWave = _waves.Dequeue();
                    _activeWave?.Start(useDelay);
                }

                _nextWave = _waves.Dequeue();
                _nextWave?.Start(true);
            }
            else
            {
                AllWavesCleared?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
