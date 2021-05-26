using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за погоню.
/// </summary>
public class ChaseBehavior 
{
    private float _stopChaseDistance;
    private NavMeshAgent _agent;

    public ChaseBehavior(NavMeshAgent agent, float stopChaseDistance)
    {
        _agent = agent;
        _stopChaseDistance = stopChaseDistance;
    }

    public void Chase(Person target)
    {
        var distance = Vector3.Distance(target.transform.position, _agent.transform.position);

        if (distance >= _stopChaseDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(target.transform.position);
        }
        else
        {
            Task.current.Succeed();
        }
    }
}
