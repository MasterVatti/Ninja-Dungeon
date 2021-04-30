using System;
using System.Security.Cryptography;
using Characteristics;
using Enemies;
using Enemies.Spawner;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.BattleManager
{
    /// <summary>
    /// Менеджер боя
    /// </summary>
    public class BattleManager : Singleton<BattleManager>
    {
        public static BattleManager instance = null;

        private Spawner _enemiesSpawner;
        private HealthBehaviour _healthBehaviour;

        private void Awake()
        {
            var playerStartPosition = new Vector3(-15.5f, 0.5f, 18.75f);

            _healthBehaviour = gameObject.GetComponent<HealthBehaviour>();
            
            MainManager.Player.transform.position = playerStartPosition;
        }
        
        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }

        private void Update()
        {
            if (MainManager.Player.)
        }

        private void InitializeManager()
        {
            _enemiesSpawner.Initialize();
        }
    }
}