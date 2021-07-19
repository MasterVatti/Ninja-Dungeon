using Characteristics;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using UnityEngine;

namespace NinjaDungeon.Scripts.Characteristics
{
    public class Enemy : Person
    {
        [SerializeField]
        private AIAnimationController _animationController;

        protected override void Start()
        {
            base.Start();

            HealthBehaviour.OnDead += _animationController.DeathAnimation;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            HealthBehaviour.OnDead -= _animationController.DeathAnimation;
        }
    }
}
