using Enemies;
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
        [SerializeField]
        private float _timeToRemove = 5f;
        [SerializeField]
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            Destroy(gameObject, _timeToRemove);
        }

        public void Initialize(Vector3 direction)
        {
            ProjectileMoving(direction);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                Destroy(gameObject);
                DealDamage(collision);
            }
            if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
            {
                Destroy(gameObject);
            }
        }

        private void ProjectileMoving(Vector3 pointToMove)
        {
            _rigidbody.velocity = pointToMove * _projectileSpeed;
        }
        
        public virtual void DealDamage(Collision collision)
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.ApplyDamage(_damage);
        }
    }
}
