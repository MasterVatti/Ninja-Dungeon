using Characteristics;
using Door;
using Enemies;
using Enemies.Spawner;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Класс контролирует бой (организует)
    /// </summary>
    public class BattleManager : Singleton<BattleManager>
    {
        [SerializeField] private Spawner _enemiesSpawner;

        private DoorSettings _settings;
        private HealthBehaviour _healthBehaviour;
        private LevelSettings _levelSettings;
        private RoomSettings _roomSettings;

        private int _currentLevel;
        private float _currentReward;

        private void Awake()
        {
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;
            
            DontDestroyOnLoad(gameObject);
        }

        private bool IsLastLevelPassed()
        {
            var _lastLevel = _roomSettings.LevelSettingsList.Count - 1;
            
            if (_currentLevel == _lastLevel && MainManager.EnemiesManager.Enemies.Count == 0)
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

        public void GoToNextLevel(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            if (IsLastLevelPassed())
            {
                //UI выигрыша Алексея
                
                MainManager.ResourceManager.AddResource(ResourceType.Gold, (int) _currentReward); //награда за прохождение всего этапа
                
                //Выдать бонус
                
                MainManager.LoadingController.StartLoad("SimpleNaturePack_Demo"); //<-- Или по кнопке Алексея
            }
            else
            {
                _currentLevel++;
                var level = roomSettings.LevelSettingsList[_currentLevel];
                var reward = _levelSettings.DefaultReward[_currentLevel];
                _currentReward += reward.Amount;

                MainManager.LoadingController.StartLoad(level.SceneName);
                MainManager.Player.transform.position = teleportPosition;
                _enemiesSpawner.Initialize();
            }
        }

        private void PlayerDeath(Person person)
        {
            //UI проигрыша
            //Перечислить выпавшие за все уровни вещи
        }

        private void OnDestroy()
        {
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}