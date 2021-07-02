using Characteristics;

namespace ExperienceSystem
{
    public class ExperienceViewDungeon : ExperienceView
    {
        private Player _player;
        private PlayerCharacteristics _playerCharacteristics;
        
        private void Start()
        {
            _player = MainManager.Player;
            _playerCharacteristics = (PlayerCharacteristics)_player.PersonCharacteristics;

            ShowLevel(_playerCharacteristics.LevelDungeon);
            _player.ExperienceControllerDungeon.OnLevelUp += ShowLevel;
        }

        private void Update()
        {
            ShowProgressExperience(_playerCharacteristics.MaximumExperienceLevelDungeon, 
                _playerCharacteristics.ExperienceDungeon);
        }

        private void OnDestroy()
        {
            _player.ExperienceControllerDungeon.OnLevelUp -= ShowLevel;
        }
    }
}