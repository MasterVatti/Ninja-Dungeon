using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LevelTolerance : MonoBehaviour
{
    // Доступ к сценам по уровню
    public int LevelUnlock
    {
        get => _levelUnlock;
        set => _levelUnlock = value;
    }
    
    [SerializeField]
    private GameObject _levelScene;
    [SerializeField]
    private int _levelUnlock;
}
