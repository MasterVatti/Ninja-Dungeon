
using BuffSystem;
using ExperienceSystem;
using UnityEngine;

namespace Characteristics
{
    public class Player : Person
    {
        public BuffManager BuffManager => _buffManager;
        public Person Ally => _ally;

        public ExperienceControllerUpperWorld ExperienceControllerUpperWorld => _experienceControllerUpperWorld;
        public ExperienceControllerDungeon ExperienceControllerDungeon => _experienceControllerDungeon;
        
        [SerializeField] 
        private ExperienceControllerUpperWorld _experienceControllerUpperWorld;
        [SerializeField]
        private ExperienceControllerDungeon _experienceControllerDungeon;
        [SerializeField]
        private BuffManager _buffManager;

        private Person _ally;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void SetAlly(Person ally)
        {
            _ally = ally;
            DontDestroyOnLoad(_ally);
        }

        public void TeleportAlly()
        {
            if (_ally == null)
            {
                return;
            }

            _ally.transform.position = transform.position + Vector3.forward;
        }
        
    }
}
