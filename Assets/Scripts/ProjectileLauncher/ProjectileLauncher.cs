using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отвечает за создание пуль
/// </summary>

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField] 
    private float bulletsSpawnCooldown;
    [SerializeField] 
    private EnemiesManager enemiesManager;
    
    private float _currentTime;
    private List<GameObject> _bullets;

    private void Awake()
    {
        _bullets = new List<GameObject>();
    }

    private void Update()
    {
        if (_currentTime < bulletsSpawnCooldown)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            _currentTime = 0;
            if (enemiesManager.enemies.Count > 0)
            {
                _bullets.Add(Instantiate(bulletPrefab, transform.position, transform.rotation)); 
            }
        }
    }
}
