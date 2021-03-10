using System;
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

        public Vector3 GetNearestEnemyPositionToPlayer()
        {
            Vector3 distance = new Vector3();
            float min = float.MaxValue;
            for (int i = 0; i < _enemiesManager.Enemies.Count; i++)
            {
                var enemy = _enemiesManager.Enemies[i];
                Vector3 playerPosition = _playerTransform.position;
                float distanceToPlayer = Vector3.Distance(enemy.transform.position,
                    playerPosition);
                if (min > distanceToPlayer)
                {
                    min = distanceToPlayer;
                    distance = _enemiesManager.Enemies[i].transform.position 
                               - _playerTransform.position;
                }
            }
            return distance;
        }
    }
}