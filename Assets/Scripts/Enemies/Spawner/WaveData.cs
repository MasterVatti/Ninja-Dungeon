using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spawner
{
    /// <summary>
    /// Класс представляет волну врагов, хранит соответственно в себе
    /// лист врагов с точками для их спавна, а также кулдаун волны
    /// </summary>
    [Serializable]
    public class WaveData
    {
        public List<SpawnPointData> SpawnPointsData =>
            _spawnPointsData;

        public float CooldownTime;

        [SerializeField]
        private List<SpawnPointData> _spawnPointsData;
    }
}
