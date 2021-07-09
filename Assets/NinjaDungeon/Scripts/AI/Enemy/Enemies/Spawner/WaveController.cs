using System.Threading.Tasks;
using Characteristics;
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

        public WaveController(WaveData waveData)
        {
            MainManager.EnemiesManager.OnEnemyDead += OnEnemyDied;
            _waveData = waveData;
        }

        /// <summary>
        /// Перегрузка для того, чтобы использовать задержку
        /// между спавнами каждого отдельного врага
        /// </summary>
        /// <param name="delayBetweenSpawns">Задержка в секундах</param>
        public async void Start(float delayBetweenSpawns = 0f)
        {
            var cooldown = (int) (_waveData.Cooldown * 1000);
            await Task.Delay(cooldown);

            foreach (var enemyWithSpawnPoint in _waveData.SpawnPointsData)
            {
                var enemyPrefab = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;
                var enemy = Object.Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                
                MainManager.EnemiesManager.AddEnemy(enemy);

                await Task.Delay((int) (delayBetweenSpawns * 1000));
            }
        }

        private void OnEnemyDied()
        {
            if (MainManager.EnemiesManager.Enemies.Count == 0)
            {
                IsFinished = true;
                MainManager.EnemiesManager.OnEnemyDead -= OnEnemyDied;
            }
        }
    }
}