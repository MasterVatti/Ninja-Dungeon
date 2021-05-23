using System.Collections.Generic;
using Assets.Scripts.Managers.ScreensManager;
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
    public class BattleManager : MonoBehaviour
    {
        [SerializeField]
        private Spawner _enemiesSpawner;
        [SerializeField]
        private RoomSettings _roomSettings;

        private Dictionary<ResourceType, List<int>> _rewardDictionary = new Dictionary<ResourceType, List<int>>();
        private Dictionary<ResourceType, List<int>> _bonusDictionary = new Dictionary<ResourceType, List<int>>();
        private HealthBehaviour _healthBehaviour;

        private int _lastLevelIndex;
        private int _currentLevelIndex;

        private void Awake()
        {
            _lastLevelIndex = _roomSettings.LevelSettingsList.Count-1;
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;

            DontDestroyOnLoad(gameObject);
        }

        private bool IsLastLevelPassed()
        {
            if (_currentLevelIndex == _lastLevelIndex && MainManager.EnemiesManager.Enemies.Count == 0)
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
            
            var rewardList = nextLevel[_currentLevelIndex].DefaultReward;
            GetLevelReward(_rewardDictionary, rewardList);
            
            rewardList = nextLevel[_currentLevelIndex].BonusReward;
            GetLevelReward(_rewardDictionary, rewardList);

            _currentLevelIndex++;
            var nextLevelIndex = roomSettings.LevelSettingsList[_currentLevelIndex];

            MainManager.LoadingController.StartLoad(nextLevelIndex.SceneName);
            MainManager.Player.transform.position = teleportPosition;

            _enemiesSpawner.Initialize();

            if (IsLastLevelPassed())
            {
                GetFinalReward();

                //UI выигрыша Алексея

                MainManager.LoadingController.StartLoad(GlobalConstants.MAIN_SCENE_TAG); //<-- Или по кнопке Алексея
            }
        }

        private void GetFinalReward()
        {
            foreach (var reward in _rewardDictionary)
            {
                EarnReward(reward.Key, reward.Value);
            }

            foreach (var bonus in _bonusDictionary)
            {
                EarnReward(bonus.Key, bonus.Value);
            }

            _rewardDictionary.Clear();
            _bonusDictionary.Clear();
        }

        private void EarnReward(ResourceType type, List<int> amount)
        {
            foreach (var reward in amount)
            {
                Debug.Log(type + " " + reward);
                MainManager.ResourceManager.AddResource(type, reward); //<-- Награда за все уровни
            }
        }

        private void GetLevelReward(Dictionary<ResourceType, List<int>> rewardDictionary, List<Resource> rewardList)
        {
            foreach (var reward in rewardList)
            {
                if (rewardDictionary.TryGetValue(reward.Type, out var amountList))
                {
                    amountList.Add((int) reward.Amount);
                }
                else
                {
                    amountList = new List<int>();
                    
                    amountList.Add((int) reward.Amount);
                    rewardDictionary.Add(reward.Type, amountList);
                }
            }
        }

        private void PlayerDeath(Person person)
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.DeathScreen); //Окно смерти Игрока
        }

        private void OnDestroy()
        {
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}