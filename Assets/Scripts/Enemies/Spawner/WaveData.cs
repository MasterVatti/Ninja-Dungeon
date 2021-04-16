using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spawner
{
    /// <summary>
    /// Класс представляет волну врагов, хранит соответственно в себе
    /// лист врагов с точками для их спавна, а также удаляет врага из
    /// этого списка при его смерти
    /// </summary>
    [Serializable]
    public class WaveData
    {
        public float Cooldown => _cooldown;
        public List<SpawnPointData> SpawnPointsData =>
            _spawnPointsData;
        
        [SerializeField]
        private float _cooldown;
        [SerializeField]
        private List<SpawnPointData> _spawnPointsData;
    }
}
