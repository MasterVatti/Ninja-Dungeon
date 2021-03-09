using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за создание пуль
    /// </summary>
    public class ProjectileLauncher : MonoBehaviour
    {
        public static ProjectileLauncher Singleton { get; private set; }
        
        public List<GameObject> Shells;
        
        [SerializeField] 
        private GameObject _bulletPrefab;
        [SerializeField] 
        private int _damage;
        [SerializeField] 
        private float _bulletsSpawnCooldown;
        [SerializeField] 
        private NearestEnemyDetector _nearestEnemy;
        
        private float _currentTime;
        
        public int Damage => _damage;
        public Vector3 NearestEnemyCoordinates { get; private set; }
        
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
                NearestEnemyCoordinates = _nearestEnemy.GetNearestEnemyPosition();
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