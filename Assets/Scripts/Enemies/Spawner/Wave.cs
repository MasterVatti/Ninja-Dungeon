using System;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawner
{
    /// <summary>
    /// Класс представляет волну врагов, хранит соответственно в себе
    /// лист врагов с точками для их спавна, а также удаляет врага из
    /// этого списка при его смерти
    /// </summary>
    [Serializable]
    public class Wave
    {
        [SerializeField]
        private List<EnemyWithSpawnPoint> _enemiesWithSpawnPoints;
        public List<EnemyWithSpawnPoint> EnemiesWithSpawnPoints =>
            _enemiesWithSpawnPoints;

        public WaveController Controller { get; set; }

        public void Initialize()
        {
            Controller = new WaveController(this);
        }
    }
}
