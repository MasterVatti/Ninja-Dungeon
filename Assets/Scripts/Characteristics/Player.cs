using ExperienceSystem;
using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    { 
        [SerializeField] 
        private ExperienceControllerUpperWorld _experienceControllerUpperWorld;
        [SerializeField]
        private ExperienceControllerDungeon _experienceControllerDungeon;
    }
}
