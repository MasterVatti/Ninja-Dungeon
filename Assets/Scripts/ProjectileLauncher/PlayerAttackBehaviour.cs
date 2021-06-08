using System.Collections;
using System.Collections.Generic;
using Characteristics;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectileLauncher
{
    /// <summary>
    /// Отвечает за стрельбу игрока 
    /// </summary>
    public class PlayerAttackBehaviour : SimpleAttackBehaviour
    {
        [SerializeField]
        private List<Transform> _muzzlesPositions;
        
        [Header("Latency between projectiles in seconds")]
        [SerializeField]
        private float _delayBetweenProjectiles = 0.05f;

        private ProjectileDirectionsProvider _projectileDirectionsProvider;
        private PlayerCharacteristics _playerCharacteristics;

        protected override void Awake()
        {
            base.Awake();
            
            _playerCharacteristics = _personCharacteristics as PlayerCharacteristics;
            Assert.IsNotNull(_playerCharacteristics);
            _projectileDirectionsProvider = new ProjectileDirectionsProvider(_playerCharacteristics, _muzzlesPositions);
        }

        protected override void Shoot(Vector3 direction)
        {
            StartCoroutine(ShootInAllDirections(direction));
        }

        private IEnumerator ShootInAllDirections(Vector3 direction)
        {
            var fireDirections = _projectileDirectionsProvider.GetFireDirections(transform.position, direction);
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
    }
}