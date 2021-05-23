using Assets.Scripts;
using  Enemies;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Баззовое движение каждой конкретной пули к ближайшему противнику
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        [SerializeField] 
        private float _projectileSpeed;
        [SerializeField]
        private Rigidbody _rigidbody;
        
        private int _damage;
        private int _reboundNumber;
        private Team _ownerTeam;

        public void Initialize(Team ownerTeam, Vector3 direction, int damage, int reboundNumber = 1)
        {
            _ownerTeam = ownerTeam;
            _reboundNumber = reboundNumber;
            _damage = damage;
            _rigidbody.velocity = direction * _projectileSpeed;
        }

        private void DealDamage(Collision collision)
        {
            var healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
            healthBehaviour.ApplyDamage(_ownerTeam, _damage);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
            {
                if (_reboundNumber == 0)
                {
                    Destroy(gameObject);
                }

                _reboundNumber--;
            }
        
            if (collision.gameObject.CompareTag(GlobalConstants.PLAYER_TAG) ||
                collision.gameObject.CompareTag(GlobalConstants.ALLY_TAG) || 
                collision.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                DealDamage(collision);
                Destroy(gameObject);
            }
        }

    }
}
