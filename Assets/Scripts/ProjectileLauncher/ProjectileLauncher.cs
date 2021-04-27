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
        private float _currentTime;
        
        private void Update()
        {
            if (_currentTime < _projectileSpawnCooldown)
            {
                _currentTime += Time.deltaTime;
            }
            else
            {
                _currentTime = 0;
                if (MainManager.EnemiesManager.Enemies.Count > 0)
                {
                    CreateProjectile();
                }
            }
        }

        private void CreateProjectile()
        {
                var nearestEnemyPosition = _enemyDetector.GetNearestEnemy().transform.position;
                var nearestEnemyDirection = (nearestEnemyPosition - transform.position).normalized;
                var projectilePosition = transform.position;
                var spawningBulletPoint = new Vector3(projectilePosition.x, projectilePosition.y, 
                    projectilePosition.z);
                transform.LookAt(nearestEnemyPosition);
                
                
                var projectile = Instantiate(_projectilePrefab, spawningBulletPoint, transform.rotation);
                projectile.Initialize(nearestEnemyDirection);
        }
        
    }
}