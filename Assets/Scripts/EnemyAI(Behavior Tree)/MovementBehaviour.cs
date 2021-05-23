using Panda;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за передвижение.
/// </summary>
public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private float _pointDistanceError = 0.5f;

    private NavMeshPath _navMeshPath;
    private Vector3 _movePoint;
    
    private GameObject _target;

    private void Start()
    {
        _navMeshPath = new NavMeshPath();
    }
    
    public void ChangePointMovement(Vector3 movePoint)
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

    private void MoveToDestination()
    {
        MoveTo(_movePoint);
        WaitArrival();
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

    private void MoveTo(Vector3 movePoint)
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
        if (!currentTask.isStarting && _agent.remainingDistance <= _pointDistanceError)
        {
            currentTask.Succeed();
        }

        if (Task.isInspected)
        {
            currentTask.debugInfo = string.Format("distance-{0:0.00}", distance);
        }
    }
    
    private void SetTargetPosition()
    {
        _movePoint = _target.transform.position;
        Task.current.Succeed();
    }
    
}
