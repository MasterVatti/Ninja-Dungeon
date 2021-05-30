using System;
using Characteristics;
using UnityEngine;

/// Доступ к сценам по уровню

namespace ExperienceSystem
{ 
    [RequireComponent(typeof(PlayerCharacteristics))]
    public class LevelTolerance : MonoBehaviour
    {
        
    
        [SerializeField]
        private GameObject _teleportScene;
        [SerializeField]
        private int _levelUnlock;
        private PlayerCharacteristics _playerCharacteristics;

        private void Start()
        {
            UnlockLevel(_playerCharacteristics.LevelUpperWorld);
            MainManager.Player.ExperienceControllerUpperWorld.OnLevelUp += UnlockLevel;
        }

        private void UnlockLevel(int level)
        {
            if (_levelUnlock <= level)
            {
                _teleportScene.SetActive(true);
            }
            _teleportScene.SetActive(false);
        }

        private void OnDestroy()
        {
            MainManager.Player.ExperienceControllerUpperWorld.OnLevelUp -= UnlockLevel;
        }
    }
}

