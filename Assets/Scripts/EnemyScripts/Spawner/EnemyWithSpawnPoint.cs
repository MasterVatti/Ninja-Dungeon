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
        public Enemy Enemy;
        public Transform SpawnPoint;
    }
}
