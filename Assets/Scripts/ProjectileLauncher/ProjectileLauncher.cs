using System.Collections.Generic;
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
        private GameObject _bulletPrefab;
        [SerializeField] 
        private int _damage;
        [SerializeField] 
        private float _bulletsSpawnCooldown;
        [SerializeField] 
        private NearestEnemyDetector _enemyDetector;
        private float _currentTime;
        
        public int Damage => _damage;
        public Vector3 NearestEnemyCoordinates { get; private set; }
        private List<GameObject> Projectiles { get; set; }
        
        private void Awake()
        {
            Projectiles = new List<GameObject>();
            Singleton = this;
        }

        private void Update()
        {
            if (_currentTime < _bulletsSpawnCooldown)
            {
                _currentTime += Time.deltaTime;
            }
            else
            {
                _currentTime = 0;
                ProjectileCreate();
            }
        }

        private void ProjectileCreate()
        {
            if (EnemiesManager.Singleton.Enemies.Count > 0)
            {
                NearestEnemyCoordinates = 
                    _enemyDetector.GetNearestEnemyPositionToPlayer();
                Vector3 projectilePosition = transform.position;
                var spawningBulletPoint = 
                    new Vector3(projectilePosition.x, 
                        projectilePosition.y + 0.75f, transform.position.z);
                Projectiles.Add(Instantiate(_bulletPrefab, spawningBulletPoint, 
                    transform.rotation));
            }
        }
        
        public void ProjectileDestroy(GameObject projectile)
        {
            Projectiles.Remove(projectile);
        }
    }
}