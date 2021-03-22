using System;
using System.Collections;
using System.Collections.Generic;
using Nodes;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private float _startingHealth;
    [SerializeField]
    private float _lowHealthThreshold;

    [SerializeField]
    private float _spawnGolemRange;
    [SerializeField]
    private float _shootingRange;
    [SerializeField]
    private Transform _playerTransform;
    
    
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _startingHealth;
    }


    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
}
