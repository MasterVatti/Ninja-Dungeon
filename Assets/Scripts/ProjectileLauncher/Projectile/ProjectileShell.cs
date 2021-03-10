using System;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public class ProjectileShell : MonoBehaviour
    {
        [SerializeField] 
        private float _bulletSpeed;
        [SerializeField] 
        private ProjectileLauncher _projectileLauncher;

        [SerializeField] private Rigidbody rb;
        private Vector3 _nearestEnemyPosition;
        private Transform _startPosition;
        

        private void Awake()
        {
            _nearestEnemyPosition = _projectileLauncher.NearestEnemyCoordinates;
            _startPosition = transform;
            rb.velocity = _nearestEnemyPosition * _bulletSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _projectileLauncher.OnProjectileDestroy(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
