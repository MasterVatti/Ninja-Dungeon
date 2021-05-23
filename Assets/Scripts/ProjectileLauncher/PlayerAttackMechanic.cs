using System.Collections;
using System.Collections.Generic;
using Characteristics;
using UnityEngine;

namespace ProjectileLauncher
{
    public class PlayerAttackMechanic : SimpleAttackMechanic
    {
        [SerializeField]
        private PlayerCharacteristics _playerCharacteristics;
        [SerializeField]
        private List<Transform> _muzzlesPositions;
        
        [Header("Latency between projectiles in seconds")]
        [SerializeField]
        private float _delayBetweenProjectiles = 0.05f;

        private ProjectileDirectionsProvider _projectileDirectionsProvider;

        protected override void Awake()
        {
            base.Awake();
            _projectileDirectionsProvider = new ProjectileDirectionsProvider(_playerCharacteristics, _muzzlesPositions);
        }

        protected override void ShootInternal(Vector3 direction)
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
                        _playerCharacteristics.RicochetProjectiles, _playerCharacteristics.AttackDamage);
                }
                
                yield return new WaitForSeconds(_delayBetweenProjectiles);
            }
        }
    }
}