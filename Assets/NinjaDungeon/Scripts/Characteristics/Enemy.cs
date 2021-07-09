using Characteristics;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using UnityEngine;

namespace NinjaDungeon.Scripts.Characteristics
{
    public class Enemy : Person
    {
        [SerializeField]
        private AIAnimationController _animationController;

        private void Start()
        {
            HealthBehaviour.OnDead += _animationController.DeathAnimation;
        }

        private void OnDestroy()
        {
            HealthBehaviour.OnDead -= _animationController.DeathAnimation;
        }
    }
}
