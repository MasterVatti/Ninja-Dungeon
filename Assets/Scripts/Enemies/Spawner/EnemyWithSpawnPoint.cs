using System;
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

        public Enemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        public Transform SpawnPoint
        {
            get => _spawnPoint;
            set => _spawnPoint = value;
        }
    }
}
