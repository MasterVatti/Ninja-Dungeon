using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EnemyScripts.Spawner
{
    /// <summary>
    /// Класс представляет волну врагов, хранит соответственно в себе
    /// лист врагов с точками для их спавна, а также удаляет врага из
    /// этого списка при его смерти
    /// </summary>
    public class Wave : MonoBehaviour
    {
        public Action OnWaveCleared;

        [SerializeField]
        private List<EnemyWithSpawnPoint> _enemiesWithSpawnPoints;
        public List<EnemyWithSpawnPoint> EnemiesWithSpawnPoints =>
            _enemiesWithSpawnPoints;

        public void Spawn()
        {
            foreach (var enemyWithSpawnPoint in EnemiesWithSpawnPoints)
            {
                var enemy = enemyWithSpawnPoint.Enemy;
                var spawnPoint = enemyWithSpawnPoint.SpawnPoint;

                Instantiate(enemy, spawnPoint.position,
                    Quaternion.identity);
            }
        }
        
        private void OnEnemyDie(Enemy enemy)
        {
            // TODO: Обработать смерть врага удалением его из списка

            if (_enemiesWithSpawnPoints.Count == 0)
            {
                OnWaveCleared?.Invoke();
            }
        }
    }
}
