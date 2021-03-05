using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    /// <summary>
    /// Отвечает за создание пуль
    /// </summary>
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField] 
    private float bulletsSpawnCoolDown;
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
        if (_currentTime < bulletsSpawnCoolDown)
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
