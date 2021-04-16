using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Spawner
{
    /// <summary>
    /// Спавнер врагов для верхнего мира.
    /// Скрипт вешается на портал (или любое место откуда должны появляться враги)
    /// </summary>
    public class UpperWorldSpawner: MonoBehaviour
    {
        [SerializeField]
        private float _minCooldown;
        [SerializeField]
        private float _maxCooldown;
        [SerializeField]
        private float _delayBetweenSpawns;

        [SerializeField]
        private int _minEnemiesCount;
        [SerializeField]
        private int _maxEnemiesCount;
        [SerializeField]
        private List<Enemy> _possibleEnemies;

        private WaveController _currentWave;
        
        private void Awake()
        {
            StartNextWave();
        }

        private void Update()
        {
            if (_currentWave != null && _currentWave.IsFinished)
            {
                StartNextWave();
            }
        }

        private void StartNextWave()
        {
            _currentWave = new WaveController(GetRandomWave());
            _currentWave.Start(_delayBetweenSpawns);
        }

        private WaveData GetRandomWave()
        {
            var cooldown = Time.time + Random.Range(_minCooldown, _maxCooldown);
            var enemiesCount = Random.Range(_minEnemiesCount, _maxEnemiesCount);

            var waveData = new List<SpawnPointData>();
            for (int i = 0; i < enemiesCount; i++)
            {
                var enemy = _possibleEnemies[Random.Range(0, _possibleEnemies.Count)];
                waveData.Add(new SpawnPointData(enemy, transform));
            }
            
            return new WaveData(cooldown, waveData);
        }
    }
}
