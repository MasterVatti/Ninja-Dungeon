using System;
using System.Linq;
using Characteristics;
using Enemies;
using Enemies.Spawner;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Класс контролирует бой (организует)
    /// </summary>
    public class BattleManager : Singleton<BattleManager>
    {
        [SerializeField]
        private Spawner _enemiesSpawner;

        private PlayerCharacteristics _playerCharacteristics;
        private HealthBehaviour _healthBehaviour;

        private LevelSettings _levelSettings;
        private RoomSettings _roomSettings;
        private NextLevelTrigger _nextLevelTrigger;

        private int _currentLevel;
        private int _currentReward;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;
        }

        private void Update()
        {
            if (IsPlayerDead())
            {
                //UI проигрыша
                //Выдать награду за пройденные левелы
            }

            if (IsLastLevel())
            {
                //UI выигрыша
                //Выдать награду + бонус + вернуться в верхний мир
            }

            if (IsNextLevelAvailable())
            {
                _nextLevelTrigger.
            }
        }

        private bool IsNextLevelAvailable()
        {
            if (MainManager.EnemiesManager.Enemies.Count == 0)
            {
                return true;
            }
            return false;
        }
        
        private bool IsPlayerDead()
        {
            if ( _playerCharacteristics.CurrentHp <= 0 && MainManager.EnemiesManager.Enemies.Count > 0)
            {
                return true;
            }
            return false;
        }

        private bool IsLastLevel()
        {
            if ( _currentLevel == 10 && MainManager.EnemiesManager.Enemies.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void StartBattle(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            _currentReward = 0;
            _currentLevel = 0;
            var level = roomSettings.LevelSettingsList[_currentLevel];

            MainManager.LoadingController.StartLoad(level.SceneName);
            MainManager.Player.transform.position = teleportPosition;
            _enemiesSpawner.Initialize();
        }

        public void GoToNextLevel(DungeonDoorContext roomSettings, DungeonDoorContext teleportPosition)
        {
            _currentLevel++;
            var nextLevelTeleportPosition = teleportPosition.TeleportPosition;
            var nextRoomSettings = roomSettings.RoomSettings;
            
            var level = nextRoomSettings.LevelSettingsList[_currentLevel];
            var reward = _levelSettings.Rewards[_currentReward]
            
            MainManager.LoadingController.StartLoad(level.SceneName);
            MainManager.Player.transform.position = nextLevelTeleportPosition;
        }

        private void PlayerDeath(Person person)
        {
        }

        private void OnDestroy()
        {
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}