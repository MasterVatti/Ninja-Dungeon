using System;
using System.Runtime.InteropServices;
using Assets.Scripts.BattleManager;
using Assets.Scripts.Managers.ScreensManager;
using Characteristics;
using Enemies;
using Enemies.Spawner;
using SimpleEventBus.Disposables;
using NinjaDungeon.Scripts.Characteristics;
using UnityEngine;

namespace NinjaDungeon.Scripts.BattleManager
{
    /// <summary>
    /// Класс контролирует бой (организует)
    /// </summary>
    public class BattleManager : MonoBehaviour
    {
        public event Action IsLevelFinished;
        public bool HasLevelPassed { get; private set; }

        [SerializeField]
        private RoomSettings _roomSettings;
        
        private HealthBehaviour _healthBehaviour;
        
        private Spawner _spawner;

        private int _lastLevelIndex;
        private int _currentLevelIndex;
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _lastLevelIndex = _roomSettings.LevelSettingsList.Count - 1;
        
            _subscriptions = new CompositeDisposable()
            {
                EventStreams.UserInterface.Subscribe<EndSpawnEvent>(EndSpawn),
                EventStreams.UserInterface.Subscribe<SetSpawnerEvent>(SetSpawner)
            };
        }

        private void EndSpawn(EndSpawnEvent eventData)
        {
            HasLevelPassed = true;
            
            IsLevelFinished?.Invoke();
        }
        
        private void SetSpawner(SetSpawnerEvent eventData)
        {
            _spawner = eventData.Spawner;
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
            if (IsLastLevelPassed())
            {
                return;
            }

            DungeonManager.RewardManager.LevelRewardAccrual(roomSettings, _currentLevelIndex);
            _currentLevelIndex++;
            var nextLevelIndex = roomSettings.LevelSettingsList[_currentLevelIndex];
            
            if (IsLastLevelPassed())
            {
                var rewardResource = DungeonManager.RewardManager.GetResources();
                var rewardExperience = DungeonManager.RewardManager.ExperienceReward;
                var context = new RewardScreenContext(rewardResource, rewardExperience);
                MainManager.ScreenManager.OpenScreenWithContext(ScreenType.RewardScreen, context);
                
                DungeonManager.RewardManager.AccrueReward();
                MainManager.SaveLoadManager.SaveResources();
                MainManager.SaveLoadManager.SavePlayer();
                return;
            }
            
            LoadLevel(nextLevelIndex, teleportPosition);
        }

        public void ClearLevel()
        {
            _spawner.StopSpawn();
            MainManager.EnemiesManager.ClearEnemies();
        }

        private void LoadLevel(LevelSettings levelSettings, Vector3 teleportPosition)
        {
            MainManager.LoadingController.StartLoad(levelSettings.SceneName);
            MainManager.Player.transform.position = teleportPosition;
            MainManager.Player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            if (MainManager.Ally != null)
            {
                MainManager.Ally.PortingToPlayer();
            }
        }
        
        private bool IsLastLevelPassed()
        {
            return _currentLevelIndex == _lastLevelIndex && HasLevelPassed;
        }
        

        private void OnDestroy()
        {
            _subscriptions?.Dispose();
        }
    }
}
