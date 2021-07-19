using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Characteristics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за стрельбу игрока 
    /// </summary>
    public class PlayerAttackBehaviour : SimpleAttackBehaviour
    {
        [FormerlySerializedAs("_muzzlesPositions")]
        [SerializeField]
        private List<Transform> _frontalBuffMuzzles;
        
        [Header("Latency between projectiles in seconds")]
        [SerializeField]
        private float _delayBetweenProjectiles = 0.05f;

        private ProjectileDirectionsProvider _projectileDirectionsProvider;
        private PlayerCharacteristics _playerCharacteristics;
        private Vector3 _direction;
        private bool _isActiveFire;
        
        protected override void Awake()
        {
            base.Awake();

            Assert.IsNotNull(_muzzle);

            _playerCharacteristics = _personCharacteristics as PlayerCharacteristics;
            Assert.IsNotNull(_playerCharacteristics);
            
            _projectileDirectionsProvider = new ProjectileDirectionsProvider(_playerCharacteristics, _frontalBuffMuzzles);
        }

        public override bool CanAttack(Person person)
        {
            return _isActiveFire && base.CanAttack(person);
        }
        
        [UsedImplicitly]
        protected override void Shoot()
        {
            var isTargetDead = _target == null;
            if (isTargetDead)
            {
                return;
            }
            
            StartCoroutine(ShootInAllDirections());
        }

        private IEnumerator ShootInAllDirections()
        {
            var muzzlePosition = _muzzle.position;
            var shootDirection = (_target.Chest.position - muzzlePosition).normalized;
            var fireDirections = _projectileDirectionsProvider.GetFireDirections(muzzlePosition, shootDirection);
            for (int i = 0; i < _playerCharacteristics.ProjectileCount; i++)
            {
                foreach (var transformProjectile in fireDirections)
                {
                    CreateProjectile(transformProjectile.Position, transformProjectile.Direction, 
                        _playerCharacteristics.AttackDamage, _playerCharacteristics.RicochetProjectiles);
                }
                
                yield return new WaitForSeconds(_delayBetweenProjectiles);
            }
        }

        public void TurnAutoFire(bool state)
        {
            _isActiveFire = state;
        }
    }
}