using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за передвижение.
/// </summary>
public class MovementBehaviour :  IMovementBehavior 
{
    private const float POINT_DISTANCE_ERROR = 1f;
    private readonly NavMeshAgent _agent;
    private readonly NavMeshPath _navMeshPath;
    private Vector3 _movePoint;

    public MovementBehaviour(NavMeshAgent agent)
    {
        _agent = agent;
        _navMeshPath = new NavMeshPath();
    }
    
    public void MoveToDestination()
    {
        MoveTo(_movePoint);
        WaitArrival();
    }
    
    public void SetMoveDestination(Vector3 movePoint)
    {
        if (_agent.CalculatePath(movePoint, _navMeshPath))
        {
            _movePoint = movePoint;
        }
        else
        {
            _movePoint = _agent.transform.position;
        }
    }
    
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
    
    public void MoveTo(Vector3 movePoint)
    {
        SetDestination(movePoint);
        if (Task.current.isStarting)
        {
            _agent.isStopped = false;
        }

        WaitArrival();
    }

    private void WaitArrival()
    {
        var currentTask = Task.current;
        var distance = _agent.remainingDistance;
        if (!currentTask.isStarting && _agent.remainingDistance <= POINT_DISTANCE_ERROR)
        {
            currentTask.Succeed();
        }

        if (Task.isInspected)
        {
            currentTask.debugInfo = string.Format("distance-{0:0.00}", distance);
        }
    }
}
