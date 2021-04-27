using System;
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
        private Characteristics.EnemyCharacteristics _enemy;
        [SerializeField]
        private Transform _spawnPoint;

        public Characteristics.EnemyCharacteristics Enemy => _enemy;

        public Transform SpawnPoint => _spawnPoint;

        public SpawnPointData(Characteristics.EnemyCharacteristics enemy, Transform spawnPoint)
        {
            _enemy = enemy;
            _spawnPoint = spawnPoint;
        }
    }
}
