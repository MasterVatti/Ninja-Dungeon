using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Enemies.Spawner
{
    /// <summary>
    /// Класс управляет волной
    /// </summary>
    public class WaveController
    {
        public bool IsFinished;
        
        private readonly WaveData _waveData;
        private int _enemiesCount;

        public WaveController(WaveData waveData)
        {
            _waveData = waveData;
            _enemiesCount = _waveData.SpawnPointsData.Count;
        }

        public async void Start()
        {
            var cooldown = (int) (_waveData.Cooldown * 1000);
            await Task.Delay(cooldown);
            
            foreach (var enemyWithSpawnPoint in _waveData.SpawnPointsData)
            {
                var enemyPrefab = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;

                var enemy = Object.Instantiate(enemyPrefab,
                    spawnPoint.position,
                    Quaternion.identity);

                enemy.HealthSystem.EnemyDie += OnEnemyDied;

                MainManager.EnemiesManager.AddEnemy(enemy);
            }
        }
        
        private void OnEnemyDied(Enemy enemy)
        {
            _enemiesCount--;

            if (_enemiesCount == 0)
            {
                IsFinished = true;
            }
        }
    }
}
