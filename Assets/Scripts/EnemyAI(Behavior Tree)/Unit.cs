using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за базовые навыки(Таски) передвежение.
/// </summary>
public class Unit : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private float _stopChaseDistance;
    [SerializeField]
    private float _pointDistanceError = 0.5f;

    private Vector3 _movePoint;
    private ITargetProvider _targetProvider;
    private void Start()
    {
        _targetProvider = GetComponent<ITargetProvider>();
    }

    public void ChangePointMovement(Vector3 movePoint)
    {
        _movePoint = movePoint;
    }

    [Task]
    private void MoveToDestination()
    {
        MoveTo(_movePoint);
        WaitArrival();
    }

    [Task]
    private bool SetDestination(Vector3 movePoint)
    {
        _movePoint = movePoint;
        _agent.destination = _movePoint;

        if (Task.isInspected)
        {
            Task.current.debugInfo = string.Format("({0}, {1})", _movePoint.x, _movePoint.y);
        }

        return true;
    }

    [Task]
    private void MoveTo(Vector3 movePoint)
    {
        SetDestination(movePoint);
        if (Task.current.isStarting)
        {
            _agent.isStopped = false;
        }

        WaitArrival();
    }

    [Task]
    private void WaitArrival()
    {
        var currentTask = Task.current;
        var distance = _agent.remainingDistance;
        if (!currentTask.isStarting && _agent.remainingDistance <= _pointDistanceError)
        {
            currentTask.Succeed();
        }

        if (Task.isInspected)
        {
            currentTask.debugInfo = string.Format("distance-{0:0.00}", distance);
        }
    }

    [Task]
    private void Chase()
    {
        var distance = Vector3.Distance(_targetProvider.Target.transform.position, _agent.transform.position);

        if (distance >= _stopChaseDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_targetProvider.Target.transform.position);
        }
        else
        {
            Task.current.Succeed();
        }
    }

    [Task]
    private void SetTargetPosition()
    {
        _movePoint = _targetProvider.Target.transform.position;
        Task.current.Succeed();
    }

    [Task]
    private bool IsAtRequiredDistance(float distance)
    {
        var targetDistance = Vector3.Distance(_targetProvider.Target.transform.position, _agent.transform.position);
        return targetDistance <= distance;
    }

    [Task]
    private bool IsTargetKilled()
    {
        return _targetProvider.Target == null;
    }
}