using System;
using Characteristics;

namespace ProjectileLauncher
{
    public interface IAttackBehaviour
    {
        public event Action IsAttack;
        bool IsCooldown { get; }

        bool CanAttack(Person person);
        void Attack(Person person);
    }
}