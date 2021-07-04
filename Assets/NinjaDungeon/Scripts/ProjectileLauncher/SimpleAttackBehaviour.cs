using System;
using Characteristics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за стрельбу одиночными снарядами
    /// </summary>
    [RequireComponent(typeof(PersonCharacteristics))]
    public class SimpleAttackBehaviour : MonoBehaviour, IAttackBehaviour
    {
        public event Action IsAttack;
        private const int START_BULLETS_COUNT = 10;
        private const int ATTACK_ANGLE_THRESHOLD = 5;
        
        public bool IsCooldown => _lastShotTime + _projectileSpawnCooldown > Time.time;

        [SerializeField]
        private Team _ownerTeam;
        [FormerlySerializedAs("_muzzlePosition")]
        [SerializeField]
        protected Transform _muzzle;
        [SerializeField]
        private Projectile _projectilePrefab;
        [SerializeField]
        protected PersonCharacteristics _personCharacteristics;

        private float _lastShotTime;
        private float _projectileSpawnCooldown;
        
        private ObjectPool _bulletsPool;
        protected Person _target;

        protected virtual void Awake()
        {
            _projectileSpawnCooldown = _personCharacteristics.AttackRate;
            _bulletsPool = new ObjectPool(_projectilePrefab.gameObject, START_BULLETS_COUNT);
        }

        public void Attack(Person person)
        {
            _target = person;
            _lastShotTime = Time.time;
            IsAttack?.Invoke();
        }

        protected void CreateProjectile(Vector3 position, Vector3 direction, int damage, int reboundNumber = 1)
        {
            var newBullet = _bulletsPool.Get();
            newBullet.transform.position = position;
            newBullet.transform.rotation = transform.rotation;
            
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
            var isPersonDead = person == null;
            if (isPersonDead && !_personCharacteristics.CanAttack)
            {
                return false;
            }
            
            TurnToTarget(person);
            
            var directionToTarget = (person.transform.position - transform.position).normalized;
            var angle = Vector3.Angle(directionToTarget, transform.forward);
            if (angle < ATTACK_ANGLE_THRESHOLD)
            {
                return true;
            }
            
            return false;
        }

        [UsedImplicitly]
        protected virtual void Shoot()
        {
            var shootDirection = (_target.Chest.position - _muzzle.position).normalized;
            CreateProjectile(_muzzle.position, shootDirection, _personCharacteristics.AttackDamage);
        }

        private void TurnToTarget(Person person)
        {
            var directionToTarget = person.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Lerp(transform.rotation,rotation,
                _personCharacteristics.RotationSpeed * Time.deltaTime);
        }
    }
}