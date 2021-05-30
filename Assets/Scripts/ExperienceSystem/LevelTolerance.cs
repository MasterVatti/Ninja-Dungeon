using System;
using Characteristics;
using UnityEngine;

public class LevelTolerance : MonoBehaviour
{
    // Доступ к сценам по уровню
    
    [SerializeField]
    private GameObject _teleportScene;
    [SerializeField]
    private int _levelUnlock;
    private Player _player;
    private PlayerCharacteristics _playerCharacteristics;

    private void Start()
    {
        _player.ExperienceControllerUpperWorld.OnLevelUp += UnlockLevel;
    }

    public void UnlockLevel(int level)
    {
        if (_levelUnlock <= level)
        {
            _teleportScene.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        _player.ExperienceControllerUpperWorld.OnLevelUp -= UnlockLevel;
    }
}
