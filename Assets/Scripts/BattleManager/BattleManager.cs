using System.Collections.Generic;
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
        public int Reward
        {
            get { return _reward; }
            set { _reward = value; }
        }

        [SerializeField]
        private Spawner _enemiesSpawner;

        [SerializeField]
        private List<SceneAsset> _battleScenes = new List<SceneAsset>();
        
        private HealthBehaviour _healthBehaviour;
        private int _reward;
        
        private void Awake()
        {
            _healthBehaviour = MainManager.Player.GetComponent<HealthBehaviour>();
            _healthBehaviour.OnDead += PlayerDeath;
            SceneManager.sceneLoaded += LoadedScrene;
            //сделать универсальным для всех сцен
        }

        private void Update()
        {
            var _player = MainManager.Player;
            var _playerCharecteristics = _player.GetComponent<PlayerCharacteristics>();
            
            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy == null)
                {
                    //UI выигрыша: предложение двойной награды или выхода
                }
                else if (enemy != null && _playerCharecteristics.CurrentHp <= 0)
                {
                    //UI проигрыша
                }
            }

            //Решить вопрос с выпадением лута (будет ли он вообще выпадать)
        }

        private void PlayerDeath(Person person)
        {
        }

        private void LoadedScrene(Scene scene, LoadSceneMode loadSceneMode)
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