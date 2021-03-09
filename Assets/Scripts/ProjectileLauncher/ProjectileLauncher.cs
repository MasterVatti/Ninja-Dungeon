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
        [SerializeField] 
        private GameObject _bulletPrefab;
        [SerializeField] 
        private float _bulletsSpawnCooldown;
        [SerializeField] 
        private NearestEnemyDetector _nearestEnemy;
        
        public List<GameObject> shells;
        private float _currentTime;

        public Vector3 NearestEnemyCoordinates { get; private set; }
        
        private void Awake()
        {
            shells = new List<GameObject>();
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
                shells.Add(Instantiate(_bulletPrefab, transform.position, 
                    transform.rotation));
            }
        }
        
        public void OnProjectileDestroy(GameObject projectile)
        {
            shells.Remove(gameObject);
        }
    }
}