using Characteristics;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using UnityEngine;

namespace NinjaDungeon.Scripts.Characteristics
{
    public class Ally : Person 
    {
        [SerializeField]
        private AIAnimationController _animationController;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        
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
