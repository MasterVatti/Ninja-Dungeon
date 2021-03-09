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

        public Vector3 GetNearestEnemyPosition()
        {
            int minimalIndex = 0;
            float min = float.MaxValue;
            for (int i = 0; i < _enemiesManager.Enemies.Count; i++)
            {
                var enemy = _enemiesManager.Enemies[i];
                Vector3 playerPosition = _playerTransform.position;
                float distance = Vector3.Distance(enemy.transform.position,
                    playerPosition);
                if (min > distance)
                {
                    min = distance;
                    minimalIndex = i;
                }
            }

            return _enemiesManager.Enemies[minimalIndex].transform.position;
        }
    }
}