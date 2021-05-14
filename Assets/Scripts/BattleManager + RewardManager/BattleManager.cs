using System.Collections.Generic;
using Characteristics;
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
        [SerializeField]
        private Spawner _enemiesSpawner;

        private Dictionary<ResourceType, int> _rewardDictionary;
        private Dictionary<ResourceType, int> _bonusDictionary;

        private HealthBehaviour _healthBehaviour;
        private LevelSettings _levelSettings;
        private RoomSettings _roomSettings;

        private int _currentLevelIndex;

        private void Awake()
        {
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;

            DontDestroyOnLoad(gameObject);
        }

        private bool IsLastLevelPassed()
        {
            var lastLevelIndex = _roomSettings.LevelSettingsList.Count - 1;

            if (_currentLevelIndex == lastLevelIndex && MainManager.EnemiesManager.Enemies.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void StartBattle(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            _currentLevelIndex = 0;
            var level = roomSettings.LevelSettingsList[_currentLevelIndex];

            MainManager.LoadingController.StartLoad(level.SceneName);
            MainManager.Player.transform.position = teleportPosition;

            _enemiesSpawner.Initialize();
        }

        public void GoToNextLevel(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            var nextLevel = roomSettings.LevelSettingsList;
            
            Debug.Log(_currentLevelIndex);
            
            var bonus = nextLevel[_currentLevelIndex].BonusReward[_currentLevelIndex];
            var reward = nextLevel[_currentLevelIndex].DefaultReward[_currentLevelIndex];
            
            _rewardDictionary.Add(bonus.Type, (int)bonus.Amount);
            _bonusDictionary.Add(reward.Type, (int)reward.Amount);
            
            _currentLevelIndex++;
            var nextLevelIndex = roomSettings.LevelSettingsList[_currentLevelIndex];

            MainManager.LoadingController.StartLoad(nextLevelIndex.SceneName);
            MainManager.Player.transform.position = teleportPosition;
            
            _enemiesSpawner.Initialize();
            
            if (IsLastLevelPassed())
            {
                GetReward();
                
                //UI выигрыша Алексея

                MainManager.LoadingController.StartLoad("SimpleNaturePack_Demo"); //<-- Или по кнопке Алексея
            }
        }

        private void GetReward()
        {
            foreach (var reward in _rewardDictionary)
            {
                MainManager.ResourceManager.AddResource(reward.Key, (int)reward.Value); //Награда за все уровни
            }

            foreach (var bonus in _bonusDictionary)
            {
                MainManager.ResourceManager.AddResource(bonus.Key, (int)bonus.Value); //Бонус за все уровни
            }
            
            _rewardDictionary.Clear();
            _bonusDictionary.Clear();
        }

        private void PlayerDeath(Person person)
        {
            //UI проигрыша
        }

        private void OnDestroy()
        {
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}