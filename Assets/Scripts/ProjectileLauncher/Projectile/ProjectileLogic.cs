using System;
using Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public class ProjectileLogic : MonoBehaviour
    {
        [SerializeField] 
        private float _bulletSpeed;
        [SerializeField] 
        private ProjectileLauncher _projectileLauncher;
        [SerializeField] 
        private Rigidbody _rigidbody;
        private Vector3 _nearestEnemyPosition;
        
        private void Awake()
        {
            _nearestEnemyPosition = _projectileLauncher.NearestEnemyCoordinates;
            _rigidbody.velocity = _nearestEnemyPosition * _bulletSpeed;
            EnemyHealth.DecreaseHealth += EnemyHit;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            EnemyHealth.DecreaseHealth -= EnemyHit;
        }

        private int EnemyHit(int health)
        {
            health -= _projectileLauncher.Damage;
            return health;
        }
    }
}
