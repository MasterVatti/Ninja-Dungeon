using System;
using UnityEngine;

namespace Assets.Scripts.EnemyScripts.Spawner
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
        private Transform _spawnpoint;

        public Enemy Enemy
        {
            get => _enemy;
            set => _enemy = value;
        }

        public Transform SpawnPoint
        {
            get => _spawnpoint;
            set => _spawnpoint = value;
        }
    }
}
