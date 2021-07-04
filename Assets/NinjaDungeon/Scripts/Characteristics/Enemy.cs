
using System;
using Enemies;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Characteristics
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
