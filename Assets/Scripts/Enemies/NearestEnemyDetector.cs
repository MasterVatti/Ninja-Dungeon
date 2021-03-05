using System.Collections.Generic;
using UnityEngine;

public class NearestEnemyDetector : MonoBehaviour
{
    /// <summary>
    /// ищет ближайшего врага к игроку
    /// </summary>
    //[SerializeField] public List<GameObject> enemies;
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private GameObject player;
    
    public Vector3 nearestEnemyCoords;
    private List<GameObject> _enemies;
    private void Awake()
    {
        _enemies = enemiesManager.enemies;
    }

    private void Update()
    {
        if (_enemies.Count > 0)
        {
            nearestEnemyCoords = NearestEnemy();
        }
    }

    private Vector3 NearestEnemy()
    {
        List<float> distances = new List<float>();
        foreach (var enemy in _enemies)
        {
            Vector3 playerPosition = player.transform.position;
            distances.Add(Vector3.Distance(enemy.transform.position,
                playerPosition));
        }

        int minimalIndex = MinimalElement(distances);
        return _enemies[minimalIndex].transform.position;
    }

    private int MinimalElement(List<float> distances)
    {
        float min = distances[0];
        int minimalIndex = 0;
        for (int i = 0; i < distances.Count; i++)
        {
            if (min > distances[i])
            {
                min = distances[i];
                minimalIndex = i;
            }
        }
        return minimalIndex;
    }
}
