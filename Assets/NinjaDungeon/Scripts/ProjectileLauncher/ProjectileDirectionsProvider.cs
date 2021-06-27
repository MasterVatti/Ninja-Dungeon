using System.Collections.Generic;
using Characteristics;
using UnityEngine;

namespace ProjectileLauncher
{
    public class ProjectileDirectionsProvider
    {
        private int _turnDiagonalArrows = 45;
        private int _sideProjectileAngle = 90;
        
        private PlayerCharacteristics _playerCharacteristics;
        
        private List<ProjectileDirection> _projectileDirections;
        private List<Transform> _positionFrontalShells;

        public ProjectileDirectionsProvider(PlayerCharacteristics playerCharacteristics, List<Transform> positionFrontalShells)
        {
            _playerCharacteristics = playerCharacteristics;
            _positionFrontalShells = positionFrontalShells;
        }
        
        public List<ProjectileDirection> GetFireDirections(Vector3 position, Vector3 nearestEnemyDirection)
        {
            _projectileDirections = new List<ProjectileDirection>();

            GetFrontalProjectileDirections(position, nearestEnemyDirection);
            GetDiagonalProjectileDirections(position, nearestEnemyDirection);
            GetProjectileBackDirections(position, nearestEnemyDirection);
            GetSideShellsDirections(position, nearestEnemyDirection);
            
            return _projectileDirections;
        }

        private void GetFrontalProjectileDirections(Vector3 position, Vector3 nearestEnemyDirection)
        {
            if (_playerCharacteristics.FrontalProjectiles)
            {
                foreach (var positionFrontalShell in _positionFrontalShells)
                {
                    AddProjectileDirections(nearestEnemyDirection, positionFrontalShell.position);
                }
            }
            else
            {
                AddProjectileDirections(nearestEnemyDirection, position);
            }
        }

        private void GetDiagonalProjectileDirections(Vector3 position, Vector3 nearestEnemyDirection)
        {
            if (_playerCharacteristics.DiagonalProjectiles)
            {
                var directionDiagonalArrows =
                    Quaternion.AngleAxis(_turnDiagonalArrows, Vector3.up) * nearestEnemyDirection;
                
                AddProjectileDirections(directionDiagonalArrows, position);

                directionDiagonalArrows =
                    Quaternion.AngleAxis(-_turnDiagonalArrows, Vector3.up) * nearestEnemyDirection;
                
                AddProjectileDirections(directionDiagonalArrows, position);
            }
        }

        private void GetProjectileBackDirections(Vector3 position, Vector3 nearestEnemyDirection)
        {
            if (_playerCharacteristics.ProjectileBack)
            {
                AddProjectileDirections(nearestEnemyDirection * -1.0f, position);
            } 
        }

        private void GetSideShellsDirections(Vector3 position, Vector3 nearestEnemyDirection)
        {
            if (_playerCharacteristics.SideProjectiles)
            {
                var directionSideShells =
                    Quaternion.AngleAxis(_sideProjectileAngle, Vector3.up) * nearestEnemyDirection;
                
                AddProjectileDirections(directionSideShells, position);

                directionSideShells =
                    Quaternion.AngleAxis(-_sideProjectileAngle, Vector3.up) * nearestEnemyDirection;
                
                AddProjectileDirections(directionSideShells, position);
            }
        }
        
        private void AddProjectileDirections(Vector3 direction, Vector3 position)
        {
            var transformProjectile = new ProjectileDirection
            {
                Direction = direction, 
                Position = position
            };
                
            _projectileDirections.Add(transformProjectile);
        }
    }
}
