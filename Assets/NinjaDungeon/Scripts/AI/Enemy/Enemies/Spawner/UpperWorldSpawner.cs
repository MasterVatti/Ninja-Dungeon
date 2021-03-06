using System.Collections.Generic;
using Characteristics;
using NinjaDungeon.Scripts.Characteristics;
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
        public float RemainTimeToSpawn  => _nextWaveSpawnTime - Time.time;
        public float CooldownTime => _cooldownTime;

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

        private float _cooldownTime;
        private float _nextWaveSpawnTime;
        private float _currentTime;
        private WaveController _currentWave;
        
        private void Awake()
        {
            StartNextWave();
        }

        private void Update()
        {
            if (Time.time >= _nextWaveSpawnTime)
            {
                StartNextWave();
            }
        }
        
        private void StartNextWave()
        {
            _cooldownTime = Random.Range(_minCooldown, _maxCooldown);
            _nextWaveSpawnTime = Time.time + _cooldownTime;
            
            _currentWave = new WaveController(GetRandomWave(_cooldownTime));
            _currentWave.Start(_delayBetweenSpawns);
        }

        private WaveData GetRandomWave(float cooldownTime)
        {
            var enemiesCount = Random.Range(_minEnemiesCount, _maxEnemiesCount);

            var waveData = new List<SpawnPointData>();
            for (int i = 0; i < enemiesCount; i++)
            {
                var enemy = _possibleEnemies[Random.Range(0, _possibleEnemies.Count)];
                waveData.Add(new SpawnPointData(enemy, transform));
            }

            return new WaveData(cooldownTime, waveData);
        }
    }
}
