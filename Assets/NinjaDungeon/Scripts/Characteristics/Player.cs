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
