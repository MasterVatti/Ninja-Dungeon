using System.Collections.Generic;
using Assets.Scripts;
using Characteristics;
using Panda;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Отвечает за определение ближайшего противника (Ally либо Player) и передачу его.
/// </summary>
public class EnemyTargetProvider : MonoBehaviour, ITargetProvider
{
    private readonly List<Person> _targets = new List<Person>();
    private Person _target;

    public Person GetTarget()
    {
        return _target;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG) ||
            other.CompareTag(GlobalConstants.ALLY_TAG))
        {
            _targets.Add(other.gameObject.GetComponent<Person>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _targets.Remove(other.gameObject.GetComponent<Person>());
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
    
    [Task]
    private bool IsTargetKilled()
    {
        return _target == null;
    }
}
