using UnityEngine;

namespace Characteristics
{
    public class DamageBehavior : Characteristic<int>
    {
        [SerializeField]
        private int _damage;

        protected override void Increase(int increasable)
        {
            _damage += increasable;
        }

        protected override void Decrease(int decreasable)
        {
            _damage -= decreasable;
        }
    }
}
