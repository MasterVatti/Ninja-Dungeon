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
            foreach (var enemy in MainManager.EnemiesManager.Enemies)
            {
                if (enemy == null)
                {
                    //UI выигрыша
                }
            }

            //Решить вопрос с лутом
        }

        private void PlayerDeath(Person person)
        {
            //UI проигрыша
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
            Debug.Log("Я начался");
        }

        private void OnDestroy()
        {
            _healthBehaviour.OnDead -= PlayerDeath;
        }
    }
}