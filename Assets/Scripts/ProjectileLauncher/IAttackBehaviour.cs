using Characteristics;
using UnityEngine;

namespace ProjectileLauncher
{
    public interface IAttackBehaviour
    {
        bool IsCooldown { get; }

        bool CanAttack(Person person);
        void Attack(Person person);
    }
}