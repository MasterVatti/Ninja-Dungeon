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
        public List<GameObject> Shells { get; private set; }
        
        private void Awake()
        {
            Shells = new List<GameObject>();
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
                OnProjectileCreate();
            }
        }

        private void OnProjectileCreate()
        {
            if (EnemiesManager.Singleton.Enemies.Count > 0)
            {
                NearestEnemyCoordinates = 
                    _enemyDetector.GetNearestEnemyPositionToPlayer();
                Shells.Add(Instantiate(_bulletPrefab, transform.position, 
                    transform.rotation));
            }
        }
        
        public void OnProjectileDestroy(GameObject projectile)
        {
            Shells.Remove(projectile);
        }
    }
}