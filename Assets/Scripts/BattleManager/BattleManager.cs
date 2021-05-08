using Characteristics;
using Enemies;
using Enemies.Spawner;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Менеджер боя
    /// </summary>
    public class BattleManager : Singleton<BattleManager>
    {
        [SerializeField]
        private Spawner _enemiesSpawner;

        private PlayerCharacteristics _playerCharacteristics;
        private HealthBehaviour _healthBehaviour;

        private LevelSettings _levelSettings;

        private int _currentLevel;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;
        }

        private void Update()
        {
            IsPlayerDie();
            IsLevelLast();
        }

        private bool IsPlayerDie()
        {
            if ( _playerCharacteristics.CurrentHp <= 0 && MainManager.EnemiesManager.Enemies.Count > 0)
            {
                //UI проигрыша
                //Выдать награду за пройденные левелы
                return true;
            }

            return false;
        }

        private bool IsLevelLast()
        {
            if ( _currentLevel == 10 && MainManager.EnemiesManager.Enemies.Count == 0) //получить индекс последней сцены
            {
                //UI выигрыша
                //Выдать награду + бонус + вернуться в верхний мир
                return true;
            }
            return false;
        }

        public void StartBattle(RoomSettings roomSettings, Vector3 teleportPosition)
        {
            _currentLevel = 0;
            var level = roomSettings.LevelSettingsList[_currentLevel];

            MainManager.LoadingController.StartLoad(level.SceneName);
            MainManager.Player.transform.position = teleportPosition;
            Debug.Log("BattleManager начал свою работу!");
            _enemiesSpawner.Initialize();
        }

        public void GoToNextLevel(RoomSettings roomSettings)
        {
            _currentLevel++;
            var level = roomSettings.LevelSettingsList[_currentLevel];
            
            MainManager.LoadingController.StartLoad(level.SceneName);
            Debug.Log($"Level №{_currentLevel}");
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