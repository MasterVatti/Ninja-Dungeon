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
        private float _projectileSpeed;
        [SerializeField] 
        private ProjectileLauncher _projectileLauncher;
        [SerializeField] 
        private Rigidbody _rigidbody;
        [SerializeField] 
        private int _damage;

        private Vector3 _nearestEnemyPosition;

        private int Damage => _damage;
        private void Awake()
        {
            _nearestEnemyPosition = _projectileLauncher.NearestEnemyCoordinates;
            _rigidbody.velocity = _nearestEnemyPosition * _projectileSpeed;
            //_rigidbody.angularVelocity = _nearestEnemy.VectorNormalization();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                DealDamage(collision);
            }
        }
        
        public virtual void DealDamage(Collision collision)
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.ApplyDamage(_damage);
        }
    }
}
