using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// ищет ближайшего врага к игроку
    /// </summary>
    public class NearestEnemyDetector : MonoBehaviour
    {
        [SerializeField] 
        private EnemiesManager _enemiesManager;
        [SerializeField] 
        private Transform _playerTransform;

        public Vector3 NearestEnemyCoords { get; private set; }
        private List<GameObject> _enemies { get; set; }

        private void Awake()
        {
            _enemies = _enemiesManager.enemies;
        }

        private void Update()
        {
            if (_enemies.Count > 0)
            {
                NearestEnemyCoords = GetNearestEnemy();
            }
        }

        private Vector3 GetNearestEnemy()
        {
            int minimalIndex = 0;
            float min = float.MaxValue;
            for (int i = 0; i < _enemies.Count; i++)
            {
                var enemy = _enemies[i];
                Vector3 playerPosition = _playerTransform.position;
                float distance = Vector3.Distance(enemy.transform.position,
                    playerPosition);
                if (min > distance)
                {
                    min = distance;
                    minimalIndex = i;
                }
            }

            return _enemies[minimalIndex].transform.position;
        }
    }
}