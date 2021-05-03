using System.Collections.Generic;
using Assets.Scripts;
using Characteristics;
using Panda;
using UnityEngine;

public class EnemyAI : MonoBehaviour, ITargetProvider
{
    public GameObject Target => _target;
        
    private readonly List<GameObject> _targets = new List<GameObject>();
    private GameObject _target;
    
    private void Start()
    {
        MainManager.EnemiesManager.Enemies.Add(GetComponent<Enemy>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG) ||
            other.CompareTag(GlobalConstants.ALLY_TAG))
        {
            _targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _targets.Remove(other.gameObject);
    }
    
    [Task]
    private bool DetermineNearestTarget()
    {
        if (_targets.Count != 0)
        {
            var minDistance = float.MaxValue;
            var minIndex = 0;
            var iterationCount = 0;
            
            foreach (var target in _targets)
            {
                if (target != null)
                {
                    var distanceToTarget = Vector3.Distance(target.transform.position,
                        gameObject.transform.position);

                    if (minDistance > distanceToTarget)
                    {
                        minDistance = distanceToTarget;
                        minIndex = iterationCount;
                    }
                
                    iterationCount++;  
                }
            }

            _target = _targets[minIndex];
            return true;
        }
        
        return false;
    }
}
