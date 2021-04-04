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

        public GameObject GetNearestEnemy()
        {
            var min = float.MaxValue;
            var minIndex = 0;
            for (int i = 0; i < _enemiesManager.Enemies.Count; i++)
            {
                var enemy = _enemiesManager.Enemies[i];
                var playerPosition = _playerTransform.position;
                if (_enemiesManager.Enemies != null)
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
            return _enemiesManager.Enemies[minIndex];
        }
    }
}