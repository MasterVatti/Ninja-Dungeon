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
        private float _delaySecondaryProjectiles;
        [SerializeField]
        private float _swivelDiagonalArrows = 45;
        
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
                Debug.Log("Multishot");
                
                CreateProjectile();
                
                yield return new WaitForSeconds(_delaySecondaryProjectiles);
            }
            
            yield return StartCoroutine(DiagonalShells());      
        }

       private IEnumerator DiagonalShells()
       {
           var direction = _nearestEnemyDirection;
           
           for (int i = 0; i < _playerCharacteristics.DiagonalShells; i++)
           {
               Debug.Log("Diagonal"); 
               
               _nearestEnemyDirection = Quaternion.AngleAxis(_swivelDiagonalArrows, Vector3.up) * direction;
               CreateProjectile();
               
               _nearestEnemyDirection = Quaternion.AngleAxis(-_swivelDiagonalArrows, Vector3.up) * direction;
               CreateProjectile();
               
               yield return new WaitForSeconds(_delaySecondaryProjectiles);
           }
       }  
    }
}