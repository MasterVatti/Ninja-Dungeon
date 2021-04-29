using System.Threading.Tasks;
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
        private float _distanceBetweenProjectiles;
        
        [Header("Degrees")]
        [SerializeField]
        private float _swivelDiagonalArrows = 45;

        [Header("Milliseconds latency")]
        [SerializeField]
        private int _delaySecondaryProjectiles = 50;
        
        private float _projectileSpawnCooldown;
        private ObjectPool _objectPool;
        private Vector3 _nearestEnemyDirection;
        private float _currentTime;
        private int _reboundNumber;

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
                    DirectionNearestEnemy(enemy.gameObject);

                    CreateProjectile(transform.position);

                    Multishot();
                    
                    DiagonalShells();
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


        private void CreateProjectile(Vector3 position)
        {
            if (_playerCharacteristics.FrontalityShells)
            {
                CreateFrontalShells(position);
            }
            else
            {
                CreateStandardProjectile(position);
            }
        }
        
        private void CreateStandardProjectile(Vector3 position)
        {
            var newBullet = _objectPool.Get();

            newBullet.transform.position = position;
            newBullet.transform.rotation = transform.rotation;

            if (newBullet.TryGetComponent<Projectile.Projectile>(out var projectile))
            {
                projectile.Initialize(_nearestEnemyDirection, _playerCharacteristics.RicochetShells);
            }
        }
        
        private void CreateFrontalShells(Vector3 position)
        {
            CreateStandardProjectile(position + new Vector3(_distanceBetweenProjectiles, 0f, 0f));
            CreateStandardProjectile(position + new Vector3(-_distanceBetweenProjectiles, 0f, 0f));
        }
        
        private async void Multishot()
        {
            for (int i = 0; i < _playerCharacteristics.MultishotShells; i++)
            {
                await Task.Delay(_delaySecondaryProjectiles);
                
                CreateProjectile(transform.position);
            }
        }

       private async void DiagonalShells()
       {
           var direction = _nearestEnemyDirection;
           
           for (int i = 0; i < _playerCharacteristics.DiagonalShells; i++)
           {
               await Task.Delay(_delaySecondaryProjectiles);
               
               _nearestEnemyDirection = Quaternion.AngleAxis(_swivelDiagonalArrows, Vector3.up) * direction;
               CreateStandardProjectile(transform.position);
               
               _nearestEnemyDirection = Quaternion.AngleAxis(-_swivelDiagonalArrows, Vector3.up) * direction;
               CreateStandardProjectile(transform.position);

               _nearestEnemyDirection = direction;
           }
       }  
    }
}