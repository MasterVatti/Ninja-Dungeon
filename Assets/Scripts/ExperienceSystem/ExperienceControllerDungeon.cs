using System;
using System.Collections;
using Characteristics;
using UnityEngine;

namespace ExperienceSystem
{
    [RequireComponent(typeof(PlayerCharacteristics))]
    public class ExperienceControllerDungeon : MonoBehaviour
    {
        public event Action<int> OnLevelUp;
        
        private PlayerCharacteristics _playerCharacteristics;
        
        void Start()
        {
            _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        }
        
        public void AddExperience(int value)
        {
            _playerCharacteristics.ExperienceDungeon += value;
            
            if (_playerCharacteristics.ExperienceDungeon >= _playerCharacteristics.MaximumExperienceLevelDungeon && !IsLevelMax())
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            var maximumExperience = _playerCharacteristics.MaximumExperienceLevelDungeon;
            
            _playerCharacteristics.LevelDungeon++;
            _playerCharacteristics.ExperienceDungeon -= maximumExperience;
            _playerCharacteristics.MaximumExperienceLevelDungeon += maximumExperience;
            
            OnLevelUp?.Invoke(_playerCharacteristics.LevelDungeon);
        }

        private bool IsLevelMax()
        {
            return _playerCharacteristics.LevelMaxDungeon == _playerCharacteristics.LevelDungeon;
        }
    }
}
