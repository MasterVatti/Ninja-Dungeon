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
    
    private PlayerCharacteristics _playerCharacteristics;

    public void UnlockLevel()
    {
        if (_levelUnlock <= _playerCharacteristics.LevelUpperWorld)
        {
            _teleportScene.SetActive(true);
        }
        _teleportScene.SetActive(false);
    }
}
