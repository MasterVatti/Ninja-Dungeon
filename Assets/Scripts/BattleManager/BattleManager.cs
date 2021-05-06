using System;
using System.Collections.Generic;
using System.Linq;
using Characteristics;
using Enemies;
using Enemies.Spawner;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Менеджер боя
    /// </summary>
    public class BattleManager : MonoBehaviour
    {
        [SerializeField]
        private Spawner _enemiesSpawner;
        [SerializeField]
        private List<SceneAsset> _battleScenes = new List<SceneAsset>();

        private PlayerCharacteristics _playerCharacteristics;
        private HealthBehaviour _healthBehaviour;
        
        private LevelSettings _levelSettings;
        private RoomSettings _roomSettings;


        private void Awake()
        {
            int CurrentSceneIndex = _levelSettings.SceneName[0];
            _playerCharacteristics = MainManager.Player.GetComponent<PlayerCharacteristics>();
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();

            _healthBehaviour.OnDead += PlayerDeath;
            SceneManager.sceneLoaded += LoadedScene;
        }

        private void Update()
        {
            IsPlayerDie();
            IsLevelLast();
        }

        private bool IsPlayerDie()
        {
            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy != null && _playerCharacteristics.CurrentHp <= 0)
                {
                    //UI проигрыша
                    //Выдать награду за пройденные левелы
                    return true;
                }
            }
            return false;
        }

        private bool IsLevelLast()
        {
            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy == null & _levelSettings.SceneName == "Level10" ) /// туть
                {
                    //UI выигрыша
                    //Выдать награду + бонус + вернуться в верхний мир
                    return true;
                }
            }

            return false;
        }

        private void PlayerDeath(Person person)
        {
        }

        private void LoadedScene(Scene scene, LoadSceneMode loadSceneMode)
        {
            foreach (var battleScene in _battleScenes)
            {
                if (battleScene.name == scene.name)
                {
                    StartBattle();
                }
            }
        }

        private void StartBattle()
        {
            _enemiesSpawner.Initialize();
            Debug.Log("BattleManager начал свои тёмные дела ☻");
        }

        private void OnDestroy()
        {
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}