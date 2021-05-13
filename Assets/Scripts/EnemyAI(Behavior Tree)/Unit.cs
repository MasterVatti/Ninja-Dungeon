using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;
using Enemies;

/// <summary>
/// Отвечает за базовые навыки(Таски) Врага
/// передвежение и хп. Должен висеть на всех енеми.
/// </summary>
[RequireComponent(typeof(Enemy))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private float _stopChaseDistance;
    [SerializeField]
    private float _pointDistanceError = 0.5f;
    

    private GameObject _player;
    private Vector3 _movePoint;

    private void Start()
    {
        _player = MainManager.Player;
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
        var distance = Vector3.Distance(_player.transform.position, _agent.transform.position);

        if (distance >= _stopChaseDistance)
        {
            _agent.isStopped = false;
            _agent.SetDestination(_player.transform.position);
        }
        else
        {
            Task.current.Succeed();
        }
    }

    [Task]
    private bool IsAtRequiredDistance(float distance)
    {
        var playerDistance = Vector3.Distance(_player.transform.position, _agent.transform.position);
        return playerDistance <= distance;
    }
}