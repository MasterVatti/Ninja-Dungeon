using System;
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
            return _enemiesManager.Enemies[minIndex];
        }
    }
}
             // float distance = Mathf.Infinity;
             // Vector3 position = transform.position;
             // foreach (GameObject enemy in _enemiesManager.Enemies)
             // { 
             //     if (enemy != null)
             //     {
             //        Vector3 diff = enemy.transform.position - position;
             //        float curDistance = diff.sqrMagnitude;
             //        if(curDistance< distance)
             //        {
             //            closest = enemy;
             //            distance = curDistance; 
             //        }
             //     }
             // }
             // return closest;