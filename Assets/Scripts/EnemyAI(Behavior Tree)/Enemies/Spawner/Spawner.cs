using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Enemies.Spawner
{
    /// <summary>
    /// Спавнер врагов
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private List<WaveData> _wavesData;
 
        private Queue<WaveController> _waves = new Queue<WaveController>();
        private WaveController _activeWave;

        private void Awake()
        {
            EventBus.Publish<ISpawnHandler>(spawner => spawner.SetSpawner(this));
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
                _activeWave?.Start();
            }
            else
            {
                Debug.Log("EventBus");
                EventBus.Publish<ISpawnHandler>(spawner => spawner.EndSpawn());
            }
        }

        public void Initialize()
        {
            foreach (WaveData wave in _wavesData)
            {
                var waveController = new WaveController(wave);
                _waves.Enqueue(waveController);
            }
            
            StartNextWave();

        }
    }
}
