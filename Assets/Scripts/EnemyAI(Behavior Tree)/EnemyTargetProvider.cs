using System.Collections.Generic;
using Assets.Scripts;
using Characteristics;
using Enemies;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Отвечает за определение ближайшего противника (Ally либо Player) и передачу его.
/// </summary>
public class EnemyTargetProvider : MonoBehaviour, ITargetProvider
{
    private readonly List<Person> _targets = new List<Person>();
    private NearestTargetProvider _nearestTargetProvider;

    private void Awake()
    {
        _nearestTargetProvider = new NearestTargetProvider();
    }

    public Person GetTarget()
    {
        if (_targets != null)
        {
            return _nearestTargetProvider.GetNearestTarget(_targets, transform.position);  
        }

        return null;
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
}
