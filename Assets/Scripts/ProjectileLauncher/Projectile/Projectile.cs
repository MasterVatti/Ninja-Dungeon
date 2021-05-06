using Enemies;
using HealthBehaviors;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        [SerializeField] 
        private float _projectileSpeed;
        [SerializeField] 
        private int _damage;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Initialize(Vector3 direction)
        {
            ProjectileMoving(direction);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                DealDamage(collision);
            }
        }

        private void ProjectileMoving(Vector3 pointToMove)
        {
            _rigidbody.velocity = pointToMove * _projectileSpeed;
        }
        
        public virtual void DealDamage(Collision collision)
        {
            var enemyHealth = collision.gameObject.GetComponent<HealthBehavior>();
            enemyHealth.ApplyDamage(_damage);
        }
    }
}
