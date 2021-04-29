using System;
using System.Collections;
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
        private Projectile _projectilePrefab;
        [SerializeField] 
        private float _projectileSpawnCooldown;
        [SerializeField] 
        private NearestEnemyDetector _enemyDetector;

        [Header("Ability parameters")]
        [SerializeField]
        private float _multishotDelay;
        [SerializeField]
        private float _swivelDiagonalArrows;
        
        private float _currentTime;
        private Vector3 _nearestEnemyDirection;
        private ObjectPool _objectPool;

        private void Start()
        {
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
                    DirectionNearestEnemy(enemy.gameObject);
                    
                    CreateProjectile();

                    DiagonalShells();
                    
                    StartCoroutine(Multishot());
                }
            }
        }

        private void DirectionNearestEnemy(GameObject enemy)
        {
            _currentTime = 0;
            
            var enemyPosition = enemy.transform.position;
            _nearestEnemyDirection = (enemyPosition - transform.position).normalized;
            
            transform.parent.LookAt(enemy.transform);
        }

        private void CreateProjectile()
        {
            var gameObject = _objectPool.Get();

            gameObject.transform.position = transform.position;
            gameObject.transform.rotation = transform.rotation;

            if (gameObject.TryGetComponent<Projectile>(out var projectile))
            {
                projectile.Initialize(_nearestEnemyDirection);
            }
        }

        private IEnumerator Multishot()
        {
            for (int i = 0; i < _playerCharacteristics.MultishotShells; i++)
            {
                yield return new WaitForSeconds(_multishotDelay);
                
                CreateProjectile();
            }
        }

        private void DiagonalShells()
        {
            for (int i = 0; i < _playerCharacteristics.DiagonalShells; i++)
            {
                _nearestEnemyDirection += new Vector3(0.25f, 0f, 0.25f);
                CreateProjectile();
                _nearestEnemyDirection -= new Vector3(0.50f, 0f, 0.50f);
                CreateProjectile();
            }
        }  
    }
}