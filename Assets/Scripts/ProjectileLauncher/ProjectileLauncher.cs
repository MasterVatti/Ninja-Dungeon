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
        
        public List<GameObject> shells;
        private float _currentTime;
        
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
                if (EnemiesManager.Singleton.enemies.Count > 0)
                {
                    shells.Add(Instantiate(_bulletPrefab, transform.position, transform.rotation));
                }
            }
        }
    }
}