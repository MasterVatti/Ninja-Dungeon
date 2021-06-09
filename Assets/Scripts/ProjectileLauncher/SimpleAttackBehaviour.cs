using System;
using Characteristics;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за стрельбу одиночными снарядами
    /// </summary>
    [RequireComponent(typeof(PersonCharacteristics))]
    public class SimpleAttackBehaviour : MonoBehaviour, IAttackBehaviour
    {
        private const int START_BULLETS_COUNT = 10;
        
        public bool IsCooldown => _lastShotTime + _projectileSpawnCooldown > Time.time;

        [SerializeField]
        private Team _ownerTeam;
        [SerializeField]
        private Projectile _projectilePrefab;
        [SerializeField]
        protected PersonCharacteristics _personCharacteristics;
        
        private float _lastShotTime;
        private float _projectileSpawnCooldown;
        
        // TODO: use MonoBehaviourPool from Roma's branch
        private ObjectPool _bulletsPool;

        protected virtual void Awake()
        {
            _projectileSpawnCooldown = _personCharacteristics.AttackRate;
            _bulletsPool = new ObjectPool(_projectilePrefab.gameObject, START_BULLETS_COUNT);
        }

        public void Attack(Person person)
        {
            _lastShotTime = Time.time;
            var shootDirection = (person.transform.position - transform.position).normalized;
            Shoot(shootDirection);
        }
        
        protected void CreateProjectile(Vector3 position, Vector3 direction, int damage, int reboundNumber = 1)
        {
            var newBullet = _bulletsPool.Get();
            newBullet.transform.position = position;
            newBullet.transform.rotation = transform.rotation;
            
            // TODO: use MonoBehaviourPool from Roma's branch
            if (newBullet.TryGetComponent<Projectile>(out var projectile))
            {
                projectile.Initialize(_ownerTeam, direction, damage, reboundNumber);
            }
            else
            {
                throw new ArgumentNullException("На снаряде нету Projectile");
            }
        }

        public virtual bool CanAttack(Person person)
        {
            return person != null;
        }

        protected virtual void Shoot(Vector3 direction)
        {
            CreateProjectile(transform.position, direction,  _personCharacteristics.AttackDamage);
        }
    }
}