using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// ищет ближайшего врага по отношению к игроку
    /// </summary>
    public class NearestEnemyDetector : MonoBehaviour
    {
        [SerializeField] 
        private EnemiesManager _enemiesManager;
        [SerializeField] 
        private Transform _playerTransform;

        public Enemy GetNearestEnemy()
        {
            var playerPosition = _playerTransform.position;
            var min = float.MaxValue;
            var minIndex = 0;
            
            for (int i = 0; i < MainManager.EnemiesManager.Enemies.Count; i++)
            {
                var enemy = MainManager.EnemiesManager.Enemies[i];
                
                if (enemy != null)
                {
                    var distanceToPlayer = Vector3.Distance(enemy.transform.position,
                        playerPosition);
                    if (min > distanceToPlayer)
                    {
                        min = distanceToPlayer;
                        minIndex = i;
                    }
                }
            }
            return MainManager.EnemiesManager.Enemies[minIndex];
        }
    }
}