using System;
using Assets.Scripts;
using Characteristics;
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
            if (person == null)
            {
                return false;
            }
            var directionToTarget = person.transform.position - transform.position;
            TurnToTarget(directionToTarget); // TODO: Почему не разворачивает игрока? Вроде все ок сделал.(MAX).
            
            if (Physics.Raycast(transform.position, directionToTarget.normalized, out var hit))
            {
                if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG) || hit.collider.CompareTag(GlobalConstants.ALLY_TAG) 
                                                                        || hit.collider.CompareTag(GlobalConstants.ENEMY_TAG))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual void Shoot(Vector3 direction)
        {
            CreateProjectile(_muzzle.position, direction,  _personCharacteristics.AttackDamage);
        }

        private void TurnToTarget(Vector3 direction)
        {
            var rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation,rotation,
                _personCharacteristics.RotationSpeed * Time.deltaTime);
        }
    }
}