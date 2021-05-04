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
     
        [Header("Degrees")]
        [SerializeField]
        private float _turnDiagonalArrows = 45;

        [Header("Seconds latency")]
        [SerializeField]
        private float _delaySecondaryProjectiles = 0.05f;
        
        [Space]
        [SerializeField]
        private List<Transform> _positionFrontalShells;
        
        private List<TransformProjectile> _transformProjectiles;
        private ObjectPool _objectPool;
        private int _sideProjectileAngle = 90;
        private float _projectileSpawnCooldown;
        private float _currentTime;

        private void Start()
        {
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
            for (int i = 0; i < _playerCharacteristics.ProjectileCount; i++)
            {
                foreach (var transformProjectile in GetTransformProjectiles())
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

        
        private List<TransformProjectile> GetTransformProjectiles()
        {
            _transformProjectiles = new List<TransformProjectile>();

            if (_playerCharacteristics.FrontalityShells)
            {
                foreach (var positionFrontalShell in _positionFrontalShells)
                {
                    AddTransformProjectile(GetNearestEnemyDirection(), positionFrontalShell.position);
                }
            }
            else
            {
                AddTransformProjectile(GetNearestEnemyDirection(), transform.position);
            }

            if (_playerCharacteristics.DiagonalShells)
            {
                var directionDiagonalArrows =
                    Quaternion.AngleAxis(_turnDiagonalArrows, Vector3.up) * GetNearestEnemyDirection();
                
                AddTransformProjectile(directionDiagonalArrows, transform.position);

                directionDiagonalArrows =
                    Quaternion.AngleAxis(-_turnDiagonalArrows, Vector3.up) * GetNearestEnemyDirection();
                
                AddTransformProjectile(directionDiagonalArrows, transform.position);
            }

            if (_playerCharacteristics.ProjectileBack)
            {
                AddTransformProjectile(GetNearestEnemyDirection() * -1.0f, transform.position);
            }

            if (_playerCharacteristics.SideShells)
            {
                var directionSideShells =
                    Quaternion.AngleAxis(_sideProjectileAngle, Vector3.up) * GetNearestEnemyDirection();
                
                AddTransformProjectile(directionSideShells, transform.position);

                directionSideShells =
                    Quaternion.AngleAxis(-_sideProjectileAngle, Vector3.up) * GetNearestEnemyDirection();
                
                AddTransformProjectile(directionSideShells, transform.position);
            }

            return _transformProjectiles;
        }
        
        private void AddTransformProjectile(Vector3 direction, Vector3 position)
        {
            var transformProjectile = new TransformProjectile
            {
                Direction = direction, 
                Position = position
            };
                
            _transformProjectiles.Add(transformProjectile);
        }
    }
}