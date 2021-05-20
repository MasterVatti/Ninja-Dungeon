using System;
using Characteristics;
using Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за поворот к цели, авто атаку и создание пуль.
    /// </summary>
    public class ProjectileLauncher : MonoBehaviour
    {
        public event Action IsShoot;

        [SerializeField]
        private Projectile _projectilePrefab;
        [SerializeField]
        private float _projectileSpawnCooldown;
        [SerializeField]
        private NearestEnemyDetector _enemyDetector;
        [SerializeField]
        private float _rotationSpeed = 2;

        private float _currentTime;
        private bool _isAutoFire;


        private void Update()
        {
            var enemy = _enemyDetector.GetNearestEnemy();
            
            if (_isAutoFire)
            {
                TurnToTarget(enemy);
                
                if (_currentTime < _projectileSpawnCooldown)
                {
                    _currentTime += Time.deltaTime;
                }
                else
                {
                    if (enemy != null)
                    {
                        CreateProjectile(enemy.gameObject);
                    }
                }
            }
        }

        private void TurnToTarget(Person enemy)
        {
            var nearestEnemyDirection = enemy.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(nearestEnemyDirection);
            transform.parent.rotation = Quaternion.Lerp(transform.rotation, rotation,
                _rotationSpeed * Time.deltaTime);
        }

        private void CreateProjectile(GameObject enemy)
        {
            _currentTime = 0;

            var enemyPosition = enemy.transform.position;
            var nearestEnemyDirection = (enemyPosition - transform.position).normalized;
            var projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);

            IsShoot?.Invoke();

            projectile.Initialize(nearestEnemyDirection);
        }

        public void StartAutoFire()
        {
            _isAutoFire = true;
        }

        public void StopAutoFire()
        {
            _isAutoFire = false;
        }
    }
}