using System;
using Characteristics;
using UnityEngine;
/// <summary>
/// Доступ к сценам по уровню
/// </summary>
namespace ExperienceSystem
{ 
    [RequireComponent(typeof(PlayerCharacteristics))]
    public class UnlockerByLevel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _teleportScene;
        [SerializeField]
        private int _levelUnlock;
        private PlayerCharacteristics _playerCharacteristics;

        private void Start()
        {
            _playerCharacteristics = (PlayerCharacteristics) MainManager.Player.PersonCharacteristics;
            TryUnlockLevel(_playerCharacteristics.LevelUpperWorld);
            MainManager.Player.ExperienceControllerUpperWorld.OnLevelUp += TryUnlockLevel;
        }

        private void TryUnlockLevel(int level)
        {
            if (_levelUnlock <= level)
            {
                _teleportScene.SetActive(true);
            }
            _teleportScene.SetActive(false);
        }

        private void OnDestroy()
        {
            MainManager.Player.ExperienceControllerUpperWorld.OnLevelUp -= TryUnlockLevel;
        }
    }
}