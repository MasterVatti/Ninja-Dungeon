using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers.ScreensManager;
using Characteristics;
using DefaultNamespace;
using Enemies;
using Enemies.Spawner;
using ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Класс контролирует бой (организует)
    /// </summary>
    public class BattleManager : MonoBehaviour, ISpawnHandler
    {
        public event Action IsLevelFinished;
        public bool HasLevelPassed { get; private set; }

        [SerializeField]
        private RoomSettings _roomSettings;

        private Dictionary<ResourceType, List<int>> _rewardDictionary = new Dictionary<ResourceType, List<int>>();
        private Dictionary<ResourceType, List<int>> _bonusDictionary = new Dictionary<ResourceType, List<int>>();
        private HealthBehaviour _healthBehaviour;
        private Spawner _spawner;

        private int _lastLevelIndex;
        private int _currentLevelIndex;

        private void Awake()
        {
            _lastLevelIndex = _roomSettings.LevelSettingsList.Count - 1;
            
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;
            
            EventBus.Subscribe<ISpawnHandler>(this);
            
            DontDestroyOnLoad(gameObject);
        }
        
        public void EndSpawn()
        {
            HasLevelPassed = true;
            
            IsLevelFinished?.Invoke();
            Debug.Log(HasLevelPassed);
        }
        
        public void SetSpawner(Spawner spawner)
        {
            _spawner = spawner;
            _spawner.Initialize();
            
            HasLevelPassed = false;
            Debug.Log(HasLevelPassed);
        }

        public void StartBattle(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            _currentLevelIndex = 0;
            
            var level = roomSettings.LevelSettingsList[_currentLevelIndex];

            LoadLevel(level, teleportPosition);
        }

        public void GoToNextLevel(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            LevelRewardAccrual(roomSettings);
            
            _currentLevelIndex++;
            
            var nextLevelIndex = roomSettings.LevelSettingsList[_currentLevelIndex];
            LoadLevel(nextLevelIndex, teleportPosition);
            
            if (IsLastLevelPassed())
            {
                GetFinalReward();

                //UI выигрыша Алексея

                MainManager.LoadingController.StartLoad("SimpleNaturePack_Demo"); //<-- Или по кнопке Алексея
            }
        }

        private void LoadLevel(LevelSettings levelSettings, Vector3 teleportPosition)
        {
            MainManager.LoadingController.StartLoad(levelSettings.SceneName);
            MainManager.Player.transform.position = teleportPosition;
            MainManager.Player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        
        private bool IsLastLevelPassed()
        {
            return _currentLevelIndex == _lastLevelIndex && HasLevelPassed;
        }
        
        private void LevelRewardAccrual(RoomSettings roomSettings)
        {
            var nextLevel = roomSettings.LevelSettingsList;
            
            var rewardList = nextLevel[_currentLevelIndex].DefaultReward;
            GetLevelReward(_rewardDictionary, rewardList);
            
            rewardList = nextLevel[_currentLevelIndex].BonusReward;
            GetLevelReward(_rewardDictionary, rewardList);
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
                    amountList = new List<int>
                    {
                        (int) reward.Amount
                    };

                    rewardDictionary.Add(reward.Type, amountList);
                }
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
                MainManager.ResourceManager.AddResource(type, reward); //<-- Награда за все уровни
            }
        }
        
        private void PlayerDeath(Person person)
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.DeathScreen); //Окно смерти Игрока
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<ISpawnHandler>(this);
            
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}