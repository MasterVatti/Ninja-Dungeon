using System;
using Characteristics;
using NinjaDungeon.Scripts.Characteristics;
using UnityEngine;

namespace Enemies.Spawner
{
    /// <summary>
    /// Представляет из себя объект, который используется для удобной работы
    /// с волнами прямо из инспектора
    /// </summary>
    [Serializable]
    public class SpawnPointData
    {
        [SerializeField]
        private Enemy _enemy;
        [SerializeField]
        private Transform _spawnPoint;

        public Enemy Enemy => _enemy;

        public Transform SpawnPoint => _spawnPoint;

        public SpawnPointData(Enemy enemy, Transform spawnPoint)
        {
            _enemy = enemy;
            _spawnPoint = spawnPoint;
        }
    }
}
