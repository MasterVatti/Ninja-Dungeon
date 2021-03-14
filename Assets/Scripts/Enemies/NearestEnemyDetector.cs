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

        public Vector3 GetNearestEnemyPositionToPlayer()
        {
            var distance = new Vector3();
            var min = float.MaxValue;
            for (int i = 0; i < _enemiesManager.Enemies.Count; i++)
            {
                var enemy = _enemiesManager.Enemies[i];
                var playerPosition = _playerTransform.position;
                var distanceToPlayer = Vector3.Distance(enemy.transform.position,
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