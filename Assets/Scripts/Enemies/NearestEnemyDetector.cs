using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ищет ближайшего врага к игроку
/// </summary>
 
public class NearestEnemyDetector : MonoBehaviour
{
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private GameObject player;

    private List<GameObject> _enemies;

    public Vector3 NearestEnemyCoords { get; set; }
    private void Awake()
    {
        _enemies = enemiesManager.enemies;
    }

    private void Update()
    {
        if (_enemies.Count > 0)
        {
            NearestEnemyCoords = GetNearestEnemy();
        }
    }

    private Vector3 GetNearestEnemy ()
    {
        int minimalIndex = 0;
        float min = float.MaxValue;
        for (int i = 0; i < _enemies.Count; i++)
        {
            var enemy = _enemies[i];
            Vector3 playerPosition = player.transform.position;
            float distance = Vector3.Distance(enemy.transform.position,
                playerPosition);
            if (min > distance)
            {
                min = distance;
                minimalIndex = i;
            }
        }
        return _enemies[minimalIndex].transform.position;
    }
}
