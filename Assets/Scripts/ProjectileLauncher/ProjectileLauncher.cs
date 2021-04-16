using Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за создание пуль
    /// </summary>
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField]
        private Projectile _projectilePrefab;

        [SerializeField]
        private float _projectileSpawnCooldown;

        [SerializeField]
        private NearestEnemyDetector _enemyDetector;

        [SerializeField]
        private GameObject _player;
        
        //private Transform projectileSpawnPoint;
        private float _currentTime; //0

        private void Update()
        {
            var enemy = _enemyDetector.GetNearestEnemy();
            if (_currentTime < _projectileSpawnCooldown)
            {
                _currentTime += Time.deltaTime;
            }
            else
            {
                if (enemy != null)
                {
                    CreateProjectile(enemy);
                }
            }
        }

        protected virtual void CreateProjectile(GameObject enemy)
        {
            _currentTime = 0;
            
            var enemyPosition = enemy.transform.position;
            var nearestEnemyDirection = (enemyPosition - transform.position).normalized;
            var projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
            
            _player.transform.LookAt(enemy.transform);
            
            projectile.Initialize(nearestEnemyDirection);
        }
    }
}