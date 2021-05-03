using  Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Баззовое движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] 
        private float _projectileSpeed;
        [SerializeField]
        private float _timeToRemove;
        [SerializeField]
        private Rigidbody _rigidbody;
        
        private int _damage;
        
        protected void Awake()
        {
            Destroy(gameObject, _timeToRemove);
        }

        public void Initialize(Vector3 direction, int damage)
        {
            SetProjectileDirection(direction);
            _damage = damage;
        }
        
        private void SetProjectileDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * _projectileSpeed;
        }

        protected  void DealDamage(Collision collision)
        {
            var enemyHealth = collision.gameObject.GetComponent<HealthBehaviour>();
            enemyHealth.ApplyDamage(_damage);
        }
    }
}
