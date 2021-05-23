using Characteristics;
using ProjectileLauncher;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Ищет ближайшего врага по отношению к игроку
    /// </summary>
    public class NearestTargetProvider : MonoBehaviour, ITargetProvider
    {
        public Person GetTarget()
        {
            var playerPosition = transform.position;
            var minDistance = float.MaxValue;
            var minIndex = 0;

            for (var index = 0; index < MainManager.EnemiesManager.Enemies.Count; index++)
            {
                var enemy = MainManager.EnemiesManager.Enemies[index];
                var distanceToPlayer = Vector3.Distance(enemy.transform.position, playerPosition);

                if (minDistance > distanceToPlayer)
                {
                    minDistance = distanceToPlayer;
                    minIndex = index;
                }
            }

            return MainManager.EnemiesManager.Enemies[minIndex];
        }
    }
}