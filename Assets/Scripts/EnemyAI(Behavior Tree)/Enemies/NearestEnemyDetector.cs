using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// ищет ближайшего врага по отношению к игроку
    /// </summary>
    public class NearestEnemyDetector : MonoBehaviour
    {
        public Enemy GetNearestEnemy()
        {
            var minDistance = float.MaxValue;
            var minIndex = 0;
            var iterationCount = 0;

            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy != null)
                {
                    var distanceToPlayer = Vector3.Distance(enemy.transform.position,
                        gameObject.transform.position);

                    if (minDistance > distanceToPlayer)
                    {
                        minDistance = distanceToPlayer;
                        minIndex = iterationCount;
                    }
                }

                iterationCount++;
            }

            return MainManager.EnemiesManager.Enemies[minIndex];
        }
    }
}