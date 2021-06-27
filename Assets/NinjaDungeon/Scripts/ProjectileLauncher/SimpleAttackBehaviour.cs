using System;
using Assets.Scripts;
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

        protected Vector3 _shootDirection;

        private float _lastShotTime;
        private float _projectileSpawnCooldown;
        
        private ObjectPool _bulletsPool;

        protected virtual void Awake()
        {
            _projectileSpawnCooldown = _personCharacteristics.AttackRate;
            _bulletsPool = new ObjectPool(_projectilePrefab.gameObject, START_BULLETS_COUNT);
        }

        public void Attack(Person person)
        {
            _lastShotTime = Time.time;
            _shootDirection = (person.transform.position - transform.position).normalized;
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
            if (person == null)
            {
                return false;
            }
            
            TurnToTarget(person);
            
            if (Physics.Raycast(transform.position, _muzzle.transform.forward, out var hit))
            {
                if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG) || hit.collider.CompareTag(GlobalConstants.ALLY_TAG) 
                                                                        || hit.collider.CompareTag(GlobalConstants.ENEMY_TAG))
                {
                    return true;
                }
            }
            return false;
        }

        [UsedImplicitly]
        protected virtual void Shoot()
        {
            CreateProjectile(_muzzle.position, _shootDirection,  _personCharacteristics.AttackDamage);
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