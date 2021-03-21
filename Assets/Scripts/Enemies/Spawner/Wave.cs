using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Assets.Scripts.EnemyScripts.Spawner
{
    /// <summary>
    /// Класс представляет волну врагов, хранит соответственно в себе
    /// лист врагов с точками для их спавна, а также удаляет врага из
    /// этого списка при его смерти
    /// </summary>
    [Serializable]
    public class Wave
    {
        public Action OnWaveCleared;

        [SerializeField]
        private List<EnemyWithSpawnPoint> _enemiesWithSpawnPoints;
        public List<EnemyWithSpawnPoint> EnemiesWithSpawnPoints =>
            _enemiesWithSpawnPoints;

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
