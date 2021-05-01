using Assets.Scripts;
using Enemies;
using UnityEngine;

namespace ProjectileLauncher.Projectile
{
    /// <summary>
    /// Движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        [SerializeField] 
        private float _projectileSpeed;
        [SerializeField]
        private Rigidbody _rigidbody;
        
        private Vector3 _direction;
        private int _reboundNumber;
        private int _damage;
        
        public void Initialize(Vector3 direction, int reboundNumber, int damage)
        {
            _direction = direction;
            _reboundNumber = reboundNumber;
            _damage = damage;
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                gameObject.SetActive(false);
                DealDamage(collision);
            }
            
            if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
            {
                if (_reboundNumber <= 0)
                {
                    gameObject.SetActive(false);
                }
                
                _reboundNumber--;
                
                _direction = collision.contacts[0].normal;
            }
        }

        private void Update()
        {
            _rigidbody.velocity = _direction * _projectileSpeed;
        }

        private void DealDamage(Collision collision)
        {
            var objectHealth = collision.gameObject.GetComponent<HealthBehaviour>();
            objectHealth.ApplyDamage(_damage);
        }
    }
}
