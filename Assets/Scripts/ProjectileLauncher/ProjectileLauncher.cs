using System;
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
        private GameObject _projectilePrefab;
        [SerializeField] 
        private float _projectileSpawnCooldown;
        [SerializeField] 
        private NearestEnemyDetector _enemyDetector;
        private float _currentTime;
        
        private Vector3 NearestEnemyPosition { get; set; }
        
        private void Update()
        {
            if (_currentTime < _projectileSpawnCooldown)
            {
                _currentTime += Time.deltaTime;
            }
            else
            {
                _currentTime = 0;
                CreateProjectile();
            }
        }

        private void CreateProjectile()
        {
            if (EnemiesManager.Singleton.Enemies.Count > 0)
            {
                NearestEnemyPosition = (_enemyDetector.GetNearestEnemy().transform.position
                                       - transform.position).normalized;
                var projectilePosition = transform.position;
                var spawningBulletPoint = new Vector3(projectilePosition.x, projectilePosition.y, 
                    projectilePosition.z);
                var projectile = Instantiate(_projectilePrefab, spawningBulletPoint, transform.rotation);
                projectile.GetComponent<Projectile>().Initialize(NearestEnemyPosition);
            }
        }
    }
}