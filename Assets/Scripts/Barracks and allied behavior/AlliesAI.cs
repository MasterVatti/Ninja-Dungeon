using Characteristics;
using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за базовое поведение союзников.  определение цели и следование.
    /// </summary>
    public class AlliesAI : MonoBehaviour, ITargetProvider
    {
        public GameObject Target => _target;
            
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private float _aggressionDistance;
        [SerializeField]
        private float _stopFollowingDistance;
        [SerializeField]
        private float _guardsDistance = 3;
        
        private GameObject _target;
        private GameObject _player;

        private void Start()
        {
            _player = MainManager.Player;
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
        
        private bool IsAtRequiredDistance(Person enemy)
        {
            var targetDistance = Vector3.Distance(enemy.transform.position, _agent.transform.position);
            return targetDistance <= _aggressionDistance;
        }

        [Task]
        private bool IsEnemyInSight()
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
        private bool IsTherePlayer()
        {
            return _player != null;
        }
    }
}