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
        private float _attackDistance;

        private float _currentTime;

        private void Update()
        {
            if (MainManager.EnemiesManager.Enemies.Count != 0)
            {
                var enemy = _enemyDetector.GetNearestEnemy();
                if (_currentTime < _projectileSpawnCooldown)
                {
                    _currentTime += Time.deltaTime;
                }
                else
                {
                    if (enemy != null & IsAtRequiredDistance(enemy))
                    {
                        CreateProjectile(enemy.gameObject);
                    }
                }
            }
        }

        private void CreateProjectile(GameObject enemy)
        {
            _currentTime = 0;

            var enemyPosition = enemy.transform.position;
            var nearestEnemyDirection = (enemyPosition - transform.position).normalized;
            var projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);

            transform.parent.LookAt(enemy.transform);

            projectile.Initialize(nearestEnemyDirection);
        }

        private bool IsAtRequiredDistance(Enemy enemy)
        {
            var targetDistance = Vector3.Distance(enemy.transform.position, transform.position);
            return targetDistance <= _attackDistance;
        }
    }
}