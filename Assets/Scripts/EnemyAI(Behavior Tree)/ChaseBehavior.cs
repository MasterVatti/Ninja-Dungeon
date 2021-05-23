using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за погоню.
/// </summary>
public class ChaseBehavior : MonoBehaviour
{
    [SerializeField]
    private Unit _unit;
    [SerializeField]
    private float _stopChaseDistance;
    [SerializeField]
    private NavMeshAgent _agent;
    
    private GameObject _target;
    
    [Task]
    private void GetTarget()
    {
        _target = _unit.TargetProvider.ProvideTarget();
        Task.current.Succeed();
    }
    
    [Task]
    private bool IsAtRequiredDistance(float distance)
    {
        var targetDistance = Vector3.Distance(_target.transform.position, _agent.transform.position);
        return targetDistance <= distance;
    }
    
    [Task]
    private void Chase()
    {
        var distance = Vector3.Distance(_target.transform.position, _agent.transform.position);

        if (distance >= _stopChaseDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_target.transform.position);
        }
        else
        {
            Task.current.Succeed();
        }
    }
}
