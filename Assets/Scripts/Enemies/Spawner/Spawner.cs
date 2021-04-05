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
 
        private Queue<WaveController> _waves = new Queue<WaveController>();
        private WaveController _activeWave;
 
        private void Awake()
        {
            foreach (WaveData wave in _wavesData)
            {
                var waveController = new WaveController(wave);
                _waves.Enqueue(waveController);
            }
 
            StartNextWave();
        }
 
        private void Update()
        {
            if (_activeWave != null && _activeWave.IsFinished)
            {
                StartNextWave();
            }
        }
 
        private void StartNextWave()
        {
            if (_waves.Count > 0)
            {
                _activeWave = _waves.Dequeue();
            
                if (_activeWave == null)
                {
                    AllWavesCleared?.Invoke();
                    return;
                }
            
                _activeWave?.Start();
            }
        }
    }
}
