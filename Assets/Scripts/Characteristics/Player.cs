using ExperienceSystem;
using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    {
        public ExperienceControllerUpperWorld ExperienceControllerUpperWorld => _experienceControllerUpperWorld;
        public ExperienceControllerDungeon ExperienceControllerDungeon => _experienceControllerDungeon;
        
        [SerializeField] 
        private ExperienceControllerUpperWorld _experienceControllerUpperWorld;
        [SerializeField]
        private ExperienceControllerDungeon _experienceControllerDungeon;
    }
}
