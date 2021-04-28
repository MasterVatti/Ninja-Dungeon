using Assets.Scripts;
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
            SetProjectileDirection(direction);
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

        private void SetProjectileDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * _projectileSpeed;
        }
        
        public virtual void DealDamage(Collision collision)
        {
            var enemyHealth = collision.gameObject.GetComponent<HealthBehaviour>();
            enemyHealth.ApplyDamage(_damage);
        }
    }
}
