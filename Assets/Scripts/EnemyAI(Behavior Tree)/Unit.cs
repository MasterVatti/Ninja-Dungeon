using System.Collections.Generic;
using Assets.Scripts;
using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Отвечает за базовые навыки(Таски) Врага
/// передвежение и хп. Должен висеть на всех енеми.
/// </summary>

public class Unit : MonoBehaviour
{
    public GameObject Target => _target;
    
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private float _stopChaseDistance;
    [SerializeField]
    private float _pointDistanceError = 0.5f;
    

    private readonly List<GameObject> _targets = new List<GameObject>();
    private GameObject _target;

    private Vector3 _movePoint;

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
    
    [Task]
    private void SetTargetPosition()
    {
        _movePoint = _target.transform.position;
        Task.current.Succeed();
    }
    
    [Task]
    private bool IsAtRequiredDistance(float distance)
    {
        if (IsThereTarget())
        {
            var targetDistance = Vector3.Distance(_target.transform.position, _agent.transform.position);
            return targetDistance <= distance;
        }

        return false;
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
    private bool IsThereTarget()
    {
       return _target != null;
    }
}