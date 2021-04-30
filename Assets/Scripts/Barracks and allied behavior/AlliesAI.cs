using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за базовое поведение союзников. Передвижение, патрулирование, определение цели.
    /// </summary>
    public class AlliesAI : MonoBehaviour
    {
        public GameObject Target => _target;
            
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private float _stopChaseDistance;
        [SerializeField]
        private float _aggressionDistance;
        [SerializeField]
        private float _stopFollowingDistance;
        [SerializeField]
        private float _guardsDistance = 3;

        private Vector3 _movePoint;
        private GameObject _target;
        private GameObject _player;

        private void Start()
        {
            _player = MainManager.Player;
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
                _agent.isStopped = false;
            WaitArrival();
        }

        private void WaitArrival()
        {
            var currentTask = Task.current;
            var distance = _agent.remainingDistance;
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
        private void FollowPlayer()
        {
            var distance = Vector3.Distance(_player.transform.position, _agent.transform.position);

            if (distance >= _stopFollowingDistance)
            {
                _agent.isStopped = false;
                _agent.SetDestination(GetRandomFollowingPoint());
            }
            else
            {
                Task.current.Succeed();
            }
        }

        private Vector3 GetRandomFollowingPoint()
        {
            var offsetX = Random.Range(-_guardsDistance, _guardsDistance);
            return _player.transform.TransformPoint(offsetX, 0, 0 - _guardsDistance);
        }
        
        [Task]
        private bool IsAtRequiredDistance(float distance)
        {
            var targetDistance = Vector3.Distance(_target.transform.position, _agent.transform.position);
            return targetDistance <= distance;
        }   
        
        private bool IsAtRequiredDistance(Person enemy)
        {
            var targetDistance = Vector3.Distance(enemy.transform.position, _agent.transform.position);
            return targetDistance <= _aggressionDistance;
        }

        [Task]
        private bool EnemyInSight()
        {
            if (MainManager.EnemiesManager.Enemies.Count != 0)
            {
                foreach (var enemy in MainManager.EnemiesManager.Enemies)
                {
                    if (enemy != null && IsAtRequiredDistance(enemy))
                    {
                        _target = enemy.gameObject;
                        return true;
                    }
                }

                return false;
            }
            
            return false;
        }

        [Task]
        private bool IsTargetKilled()
        {
            return _target == null;
        }
        
        [Task]
        private bool IsTherePlayer()
        {
            return _player != null;
        }
    }
}