using System;
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
        private Rigidbody _rigidbody;
        private Vector3 _forward;

        
        public void Initialize(Vector3 direction)
        {
            _forward = direction;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                gameObject.SetActive(false);
                DealDamage(collision);
            }
            if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
            {
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            _rigidbody.velocity = _forward * _projectileSpeed;
        }


        public virtual void DealDamage(Collision collision)
        {
            var enemyHealth = collision.gameObject.GetComponent<HealthBehaviour>();
            enemyHealth.ApplyDamage(_damage);
        }
    }
}
