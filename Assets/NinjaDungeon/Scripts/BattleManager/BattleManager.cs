﻿using System;
using Assets.Scripts;
using Assets.Scripts.BattleManager;
using Assets.Scripts.Managers.ScreensManager;
using Characteristics;
using DefaultNamespace;
using Enemies;
using Enemies.Spawner;
using UnityEngine;

namespace NinjaDungeon.Scripts.BattleManager
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

        private RewardManager _rewardManager;
        private HealthBehaviour _healthBehaviour;
        private Spawner _spawner;

        private int _lastLevelIndex;
        private int _currentLevelIndex;

        private void Awake()
        {
            _lastLevelIndex = _roomSettings.LevelSettingsList.Count - 1;
            _rewardManager = new RewardManager();
            
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;
            
            EventBus.Subscribe<ISpawnHandler>(this);
            
            DontDestroyOnLoad(gameObject);
        }
        
        public void EndSpawn()
        {
            HasLevelPassed = true;
            
            IsLevelFinished?.Invoke();
        }
        
        public void SetSpawner(Spawner spawner)
        {
            _spawner = spawner;
            _spawner.Initialize();
            
            HasLevelPassed = false;
        }

        public void StartBattle(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            _currentLevelIndex = 0;
            
            var level = roomSettings.LevelSettingsList[_currentLevelIndex];

            LoadLevel(level, teleportPosition);
        }

        public void GoToNextLevel(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            _rewardManager.LevelRewardAccrual(roomSettings, _currentLevelIndex);
            
            _currentLevelIndex++;
            
            var nextLevelIndex = roomSettings.LevelSettingsList[_currentLevelIndex];
            LoadLevel(nextLevelIndex, teleportPosition);
            
            if (IsLastLevelPassed())
            {
                _rewardManager.GetFinalReward();

                //UI выигрыша Алексея

                EventBus.Publish<ISpawnHandler>(spawner => spawner.EndSpawn());
                MainManager.EnemiesManager.Enemies.Clear();
                
                MainManager.LoadingController.StartLoad(GlobalConstants.MAIN_SCENE_TAG); //<-- Или по кнопке Алексея
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

        private void PlayerDeath(Person person)
        {
            MainManager.ScreenManager.OpenScreen(ScreenType.DeathScreen);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<ISpawnHandler>(this);
            
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}
