using System;
using Panda;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за базовое поведение союзников. Передвижение, патрулирование, определение цели.
    /// </summary>
    
    public class AllyBehavior : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private float _stopChaseDistance;
        [SerializeField]
        private Transform[] _patrolPoints;
        
        private Vector3 _movePoint;
        private GameObject _target;
        
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
                Task.current.debugInfo = string.Format("({0}, {1})", _movePoint.x, _movePoint.y);
            return true;
        }
        
        [Task]
        private void MoveTo(Vector3 movePoint)
        {
            SetDestination(movePoint);
            if (Task.current.isStarting)
                _agent.isStopped = false;
            WaitArrival();
        }
        
        private void WaitArrival()
        {
            var currentTask = Task.current;
            float distance = _agent.remainingDistance;
            if (!currentTask.isStarting && _agent.remainingDistance <= 0.5f)
            {
                currentTask.Succeed();
            }

            if (Task.isInspected)
                currentTask.debugInfo = string.Format("distance-{0:0.00}", distance);
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
        private bool IsRequiredDistance(float distance)
        {
            var playerDistance = Vector3.Distance(_target.transform.position, _agent.transform.position);
            return playerDistance <= distance;
        }
        
        [Task]
        private void SetRandomPatrolPoint()
        {
            var pointIndex = Random.Range(0, _patrolPoints.Length);
            _movePoint = _patrolPoints[pointIndex].position;
        }
        
    }
}
