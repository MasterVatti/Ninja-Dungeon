using System;
using Characteristics;
using UnityEngine;

namespace ProjectileLauncher
{
    [RequireComponent(typeof(PersonCharacteristics))]
    public class SimpleAttackMechanic : MonoBehaviour, IAttackMechanic
    {
        private const int START_BULLETS_COUNT = 10;

        public bool IsCooldown => _lastShotTime + _projectileSpawnCooldown > Time.time;
        public virtual bool CanShoot => true;
        
        [SerializeField]
        private Projectile.Projectile _projectilePrefab;
        
        private float _lastShotTime;
        private float _projectileSpawnCooldown;
        
        // TODO: use MonoBehaviourPool from Roma's branch
        private ObjectPool _bulletsPool;
        private PersonCharacteristics _personCharacteristics;

        protected virtual void Awake()
        {
            _personCharacteristics = GetComponent<PersonCharacteristics>();
            _projectileSpawnCooldown = 1 / _personCharacteristics.AttackRate;
            _bulletsPool = new ObjectPool(_projectilePrefab.gameObject, START_BULLETS_COUNT);
        }

        public void Shoot(Vector3 enemyDirection)
        {
            _lastShotTime = Time.time;
            ShootInternal(enemyDirection);
        }
        
        protected void CreateProjectile(Vector3 position, Vector3 direction, int reboundNumber, int damage)
        {
            var newBullet = _bulletsPool.Get();
            newBullet.transform.position = position;
            newBullet.transform.rotation = transform.rotation;
            
            if (newBullet.TryGetComponent<Projectile.Projectile>(out var projectile))
            {
                projectile.Initialize(direction, reboundNumber, damage);
            }
            else
            {
                throw new ArgumentNullException("На снаряде нету Projectile");
            }
        }

        protected virtual void ShootInternal(Vector3 direction)
        {
            CreateProjectile(transform.position, direction, 1, _personCharacteristics.AttackDamage);
        }
    }
}