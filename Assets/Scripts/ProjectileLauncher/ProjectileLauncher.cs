using Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за создание пуль
    /// </summary>
    public class ProjectileLauncher : MonoBehaviour
    {
        public static ProjectileLauncher Singleton { get; private set; }
        
        [SerializeField] 
        private GameObject _projectilePrefab;
        
        [SerializeField] 
        private float _projectileSpawnCooldown;
        [SerializeField] 
        private NearestEnemyDetector _enemyDetector;
        private float _currentTime;
        
        public Vector3 NearestEnemyCoordinates { get; private set; }
        
        private void Awake()
        {
            Singleton = this;
        }

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
                NearestEnemyCoordinates = _enemyDetector.GetNearestEnemyPositionToPlayer();
                Vector3 projectilePosition = transform.position;
                var spawningBulletPoint = new Vector3(projectilePosition.x, 
                        projectilePosition.y, transform.position.z);
                var projectile = Instantiate(_projectilePrefab, spawningBulletPoint, transform.rotation);
                //projectile.Initialize(projectile);
            }
        }
    }
}