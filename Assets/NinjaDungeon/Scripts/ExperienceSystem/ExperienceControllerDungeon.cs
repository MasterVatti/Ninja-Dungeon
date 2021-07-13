using System;
using Assets.Scripts.Managers.ScreensManager;
using Characteristics;
using UnityEngine;
//// <summary>
///  класс контроля метода в подземелье
/// </summary>
namespace ExperienceSystem
{
    [RequireComponent(typeof(PlayerCharacteristics))]
    public class ExperienceControllerDungeon : ExperienceController
    {
        public event Action<int> OnLevelUp;

        [Header("For raising the level")]
        [Range(0, 100)]
        [SerializeField]
        private float _percentageRecovery;

        private PlayerCharacteristics _playerCharacteristics;
        
        void Start()
        {
            _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        }
        
        public override void AddExperience(int value)
        {
            _playerCharacteristics.ExperienceDungeon += value;
            
            if (_playerCharacteristics.ExperienceDungeon >= _playerCharacteristics.MaximumExperienceLevelDungeon && !IsLevelMax())
            {
                LevelUp();
            }
        }

        public override void LevelUp()
        {
            var maximumExperience = _playerCharacteristics.MaximumExperienceLevelDungeon;

            _playerCharacteristics.LevelDungeon++;
            _playerCharacteristics.ExperienceDungeon -= maximumExperience;
            _playerCharacteristics.MaximumExperienceLevelDungeon += maximumExperience;
            
            var healAmount = _playerCharacteristics.MaxHp * (_percentageRecovery / 100f);
            MainManager.Player.HealthBehaviour.HealthRecovery((int) healAmount);

            OnLevelUp?.Invoke(_playerCharacteristics.LevelDungeon);
            MainManager.ScreenManager.OpenScreen(ScreenType.BuffScreen);
        }

        public override bool IsLevelMax()
        {
            return _playerCharacteristics.LevelMaxDungeon == _playerCharacteristics.LevelDungeon;
        }
    }
}
