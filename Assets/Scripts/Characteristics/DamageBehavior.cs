using System;
using UnityEngine;

namespace Characteristics
{
    public sealed class DamageBehavior : Characteristic
    {
        [SerializeField]
        private int _damage;

        protected override void Increase<T>(T increasable)
        {
            _damage += Convert.ToInt32(increasable);
        }

        protected override void Decrease<T>(T decreasable)
        {
            _damage -= Convert.ToInt32(decreasable);
            CheckForNegative();
        }

        private void CheckForNegative()
        {
            if (_damage < 0)
            {
                _damage = 0;
            }
        }
    }
}
