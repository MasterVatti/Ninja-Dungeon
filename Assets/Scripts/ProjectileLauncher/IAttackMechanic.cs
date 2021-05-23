using UnityEngine;

namespace ProjectileLauncher
{
    public interface IAttackMechanic
    {
        bool IsCooldown { get; }
        bool CanShoot { get; }
        
        void Shoot(Vector3 enemyDirection);
    }
}