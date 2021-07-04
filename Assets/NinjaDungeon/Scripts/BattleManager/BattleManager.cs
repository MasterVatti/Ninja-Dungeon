using System;
using Assets.Scripts;
using Assets.Scripts.BattleManager;
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
        
        private HealthBehaviour _healthBehaviour;

        private RewardManager _rewardManager;
        private Spawner _spawner;

        private int _lastLevelIndex;
        private int _currentLevelIndex;

        private void Awake()
        {
            _lastLevelIndex = _roomSettings.LevelSettingsList.Count - 1;
            _rewardManager = new RewardManager();

            EventBus.Subscribe<ISpawnHandler>(this);
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
            DungeonManager.RewardManager.LevelRewardAccrual(roomSettings, _currentLevelIndex);
            
            _currentLevelIndex++;
            
            var nextLevelIndex = roomSettings.LevelSettingsList[_currentLevelIndex];
            
            if (IsLastLevelPassed())
            {
                var context = new RewardScreenContext(DungeonManager.RewardManager.GetResources());
                MainManager.ScreenManager.OpenScreenWithContext(ScreenType.RewardScreen, context);
                
                DungeonManager.RewardManager.AccrueReward();
                // TODO: Не будет сохранять ресурсы т.к. достаёт из сохраненных данных ресурсы.
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
        }
        
        private bool IsLastLevelPassed()
        {
            return _currentLevelIndex == _lastLevelIndex && HasLevelPassed;
        }
        

        private void OnDestroy()
        {
            EventBus.Unsubscribe<ISpawnHandler>(this);
            
        }
    }
}
