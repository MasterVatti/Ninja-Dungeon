using System;
using Assets.Scripts.Enemies.Spawner;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Представляет из себя объект, который используется для удобной работы
    /// с волнами прямо из инспектора
    /// </summary>
    [Serializable]
    public class EnemyWithSpawnPoint
    {
        [SerializeField]
        private Enemy _enemy;
        [SerializeField]
        private Transform _spawnPoint;

        public Enemy Enemy => _enemy;

        public Transform SpawnPoint => _spawnPoint;
    }
}
