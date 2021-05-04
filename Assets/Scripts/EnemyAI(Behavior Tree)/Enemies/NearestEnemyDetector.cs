using Characteristics;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Ищет ближайшего врага по отношению к игроку
    /// </summary>
    public class NearestEnemyDetector : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerTransform;

        public Person GetNearestEnemy()
        {
            var playerPosition = _playerTransform.position;
            var minDistance = float.MaxValue;
            var minIndex = 0;
            var currentIteration = 0;

            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy != null)
                {
                    var distanceToPlayer = Vector3.Distance(enemy.transform.position,
                        playerPosition);
                    
                    if (minDistance > distanceToPlayer)
                    {
                        minDistance = distanceToPlayer;
                        minIndex = currentIteration;    
                    }
                }
                
                currentIteration++;
            }

            return MainManager.EnemiesManager.Enemies[minIndex];
        }
    }
}