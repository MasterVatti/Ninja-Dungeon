using System;
using Characteristics;
using TMPro;
using UnityEngine;

namespace ExperienceSystem
{
    public class ExperienceViewUpperWorld : ExperienceView
    {
        private Player _player;
        private PlayerCharacteristics _playerCharacteristics;
        
        private void Start()
        {
            _player = MainManager.Player;
            _playerCharacteristics = (PlayerCharacteristics)_player.PersonCharacteristics;

            ShowLevel(_playerCharacteristics.LevelDungeon);
            _player.ExperienceControllerUpperWorld.OnLevelUp += ShowLevel;
        }

        private void Update()
        {
            ShowProgressExperience(_playerCharacteristics.MaximumExperienceLevelUpperWorld, 
                _playerCharacteristics.ExperienceUpperWorld);
        }

        private void OnDestroy()
        {
            _player.ExperienceControllerUpperWorld.OnLevelUp -= ShowLevel;
        }
    }
}