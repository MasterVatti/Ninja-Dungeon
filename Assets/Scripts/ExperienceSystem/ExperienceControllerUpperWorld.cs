using System;
using System.Collections;
using Characteristics;
using UnityEngine;

namespace ExperienceSystem
{
    [RequireComponent(typeof(PlayerCharacteristics))]
    public class ExperienceControllerUpperWorld : MonoBehaviour
    {
        public event Action<int> OnLevelUp;

        private PlayerCharacteristics _playerCharacteristics;
        
        void Start()
        {
            _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        }
        
        public void AddExperience(int value)
        {
            _playerCharacteristics.ExperienceUpperWorld += value;

            if (_playerCharacteristics.ExperienceUpperWorld >= _playerCharacteristics.MaximumExperienceLevelUpperWorld && !IsLevelMax())
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            var maximumExperience = _playerCharacteristics.MaximumExperienceLevelUpperWorld;
            
            _playerCharacteristics.LevelUpperWorld++;
            _playerCharacteristics.ExperienceUpperWorld -= maximumExperience;
            _playerCharacteristics.MaximumExperienceLevelUpperWorld += maximumExperience;

            OnLevelUp?.Invoke(_playerCharacteristics.LevelUpperWorld);
        }

        private bool IsLevelMax()
        {
            return _playerCharacteristics.LevelMaxUpperWorld == _playerCharacteristics.LevelUpperWorld;
        }
    }
}
