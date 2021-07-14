using System;
using System.Collections;
using Characteristics;
using UnityEngine;

namespace ExperienceSystem
{
    [RequireComponent(typeof(PlayerCharacteristics))]
    public class ExperienceControllerUpperWorld : ExperienceController
    {
        public event Action<int> OnLevelUp;

        private PlayerCharacteristics _playerCharacteristics;

        private void Awake()
        {
            _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        }
        
        public override void AddExperience(int value)
        {
            var experienceUpperWorld = _playerCharacteristics.ExperienceUpperWorld + value;
            if (experienceUpperWorld >= _playerCharacteristics.MaximumExperienceLevelUpperWorld && !IsLevelMax())
            {
                _playerCharacteristics.ExperienceUpperWorld = experienceUpperWorld;
                LevelUp();
            }
        }

        public override void LevelUp()
        {
            var maximumExperience = _playerCharacteristics.MaximumExperienceLevelUpperWorld;
            
            _playerCharacteristics.LevelUpperWorld++;
            _playerCharacteristics.ExperienceUpperWorld -= maximumExperience;
            _playerCharacteristics.MaximumExperienceLevelUpperWorld += maximumExperience;
            OnLevelUp?.Invoke(_playerCharacteristics.LevelUpperWorld);
            
            HasOverkillExperience();
        }

        private void HasOverkillExperience()
        {
            if (_playerCharacteristics.ExperienceUpperWorld >= _playerCharacteristics.MaximumExperienceLevelUpperWorld)
            {
                LevelUp();
                HasOverkillExperience();
            }
        }

        public override bool IsLevelMax()
        {
            return _playerCharacteristics.LevelMaxUpperWorld == _playerCharacteristics.LevelUpperWorld;
        }
    }
}
