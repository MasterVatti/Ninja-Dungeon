using System.Collections.Generic;
using Assets.Scripts;
using Characteristics;
using Enemies;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Отвечает за определение ближайшего союзника (Ally либо Player) и передачу его.
/// </summary>
public class EnemyTargetProvider : MonoBehaviour, ITargetProvider
{
    [SerializeField]
    private float _aggressionDistance;

    private readonly List<Person> _targets = new List<Person>();
    private NearestTargetProvider _nearestTargetProvider;

    private void Awake()
    {
        _nearestTargetProvider = new NearestTargetProvider();
    }

    public Person GetTarget()
    {
        CleanDestroyedTargets();
        return _nearestTargetProvider.GetNearestTarget(_targets, transform.position, _aggressionDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG) ||
            other.CompareTag(GlobalConstants.ALLY_TAG))
        {
            _targets.Add(other.GetComponent<Person>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_TAG) ||
            other.CompareTag(GlobalConstants.ALLY_TAG))
        {
            _targets.Remove(other.GetComponent<Person>());
        }
    }

    private void CleanDestroyedTargets()
    {
        for (var i = 0; i < _targets.Count; i++)
        {
            if (_targets[i] == null)
            {
                _targets.Remove(_targets[i]);
            }
        }
    }
}