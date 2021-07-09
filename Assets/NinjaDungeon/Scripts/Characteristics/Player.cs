using BuffSystem;
using ExperienceSystem;
using PlayerScripts.Animation;
using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    {
        public BuffManager BuffManager => _buffManager;
        
        public ExperienceControllerUpperWorld ExperienceControllerUpperWorld => _experienceControllerUpperWorld;
        public ExperienceControllerDungeon ExperienceControllerDungeon => _experienceControllerDungeon;
        
        [SerializeField] 
        private ExperienceControllerUpperWorld _experienceControllerUpperWorld;
        [SerializeField]
        private ExperienceControllerDungeon _experienceControllerDungeon;
        [SerializeField]
        private BuffManager _buffManager;
        [SerializeField]
        private PlayerAnimationController _animationController;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void ResetAnimation()
        {
            _animationController.ResetPlayer();
        }
        
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
