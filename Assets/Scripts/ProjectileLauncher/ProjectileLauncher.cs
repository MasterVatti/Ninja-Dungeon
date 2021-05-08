using System;
using System.Collections;
using System.Collections.Generic;
using Characteristics;
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
        private PlayerCharacteristics _playerCharacteristics;
        [SerializeField]
        private Projectile.Projectile _projectilePrefab;
        [SerializeField]
        private NearestEnemyDetector _enemyDetector;
        
        [SerializeField]
        private List<Transform> _positionFrontalShells;
        
        [Header("Seconds latency")]
        [SerializeField]
        private float _delaySecondaryProjectiles = 0.05f;
        
        private ObjectPool _objectPool;
        private float _projectileSpawnCooldown;
        private float _currentTime;
        private ProjectileDirectionsProvider _projectileDirectionsProvider;

        private void Start()
        {
            _projectileDirectionsProvider =
                new ProjectileDirectionsProvider(_playerCharacteristics, _positionFrontalShells);
            _projectileSpawnCooldown = _playerCharacteristics.AttackRate;
            _objectPool = new ObjectPool(_projectilePrefab.gameObject, 10);
        }

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
                    StartCoroutine(Shoot());
                    
                    _currentTime = 0;
                }
                else
                {
                    StopCoroutine(Shoot());
                }
            }
        }

        private Vector3 GetNearestEnemyDirection()
        {
            var enemy = _enemyDetector.GetNearestEnemy();
            
            if (enemy != null)
            {
                var enemyPosition = enemy.transform.position;

                transform.parent.LookAt(enemy.transform);

                return (enemyPosition - transform.position).normalized;
            }
            
            return Vector3.forward;
        }
        
        private IEnumerator Shoot()
        {
            var enemyDirection = GetNearestEnemyDirection();
            var fireDirections = _projectileDirectionsProvider.GetFireDirections(transform.position, enemyDirection);
            for (int i = 0; i < _playerCharacteristics.ProjectileCount; i++)
            {
               foreach (var transformProjectile in fireDirections)
               {
                   CreateProjectile(transformProjectile.Position, transformProjectile.Direction);
               }
                
               yield return new WaitForSeconds(_delaySecondaryProjectiles);
            }
        }

        private void CreateProjectile(Vector3 position, Vector3 direction)
        {
            var newBullet = _objectPool.Get();

            newBullet.transform.position = position;
            newBullet.transform.rotation = transform.rotation;
            
            if (newBullet.TryGetComponent<Projectile.Projectile>(out var projectile))
            {
                var player = _playerCharacteristics;

                projectile.Initialize(direction, player.RicochetShells, player.AttackDamage);
            }
            else
            {
                throw new ArgumentNullException("На снаряде нету Projectile");
            }
        }
    }
}