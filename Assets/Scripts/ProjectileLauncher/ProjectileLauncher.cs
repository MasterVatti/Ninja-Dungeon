using System;
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
        private Projectile _projectilePrefab;
        [SerializeField]
        private float _projectileSpawnCooldown;
        [SerializeField]
        private NearestEnemyDetector _enemyDetector;
        [SerializeField]
        private float _attackDistance;
        [SerializeField]
        private GameObject _shooter;
        
        private float _currentTime;
        private int _damage;

        private void Start()
        {
            _damage = _shooter.GetComponent<PersonCharacteristics>().AttackDamage;
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
                if (enemy != null && IsAtRequiredDistance(enemy))
                {
                    CreateProjectile(enemy.gameObject);
                }
            }
        }

        private void CreateProjectile(GameObject enemy)
        {
            _currentTime = 0;
            
            var enemyPosition = enemy.transform.position;
            var nearestEnemyDirection = (enemyPosition - transform.position).normalized;
            var projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
            
            _shooter.transform.LookAt(enemy.transform);
            
            projectile.Initialize(nearestEnemyDirection,_damage);
        }

        private bool IsAtRequiredDistance(Person enemy)
        {
            var targetDistance = Vector3.Distance(enemy.transform.position, transform.position);
            return targetDistance <= _attackDistance;
        }
    }
}