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
        private int _damage;
        [SerializeField]
        private Rigidbody _rigidbody;
        
        private Vector3 _direction;
        private int _reboundNumber;
        
        public void Initialize(Vector3 direction, int reboundNumber)
        {
            _direction = direction;
            _reboundNumber = reboundNumber;
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
