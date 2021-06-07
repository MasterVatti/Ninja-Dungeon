using Characteristics;
using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    public abstract class AIBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected NavMeshAgent _agent;
        [SerializeField]
        protected PersonCharacteristics _personCharacteristics;
        [SerializeField]
        protected float _stopChaseDistance;

        protected ITargetProvider _targetProvider;
        protected ChaseBehavior _chaseBehavior;
        protected FollowBehavior _followBehavior;
        protected IAttackBehaviour _attackBehaviour;
        protected IMovementBehavior _iMovementBehavior;

        protected Person _target;
        
        [Task]
        protected bool GetTarget()
        {
            _target = _targetProvider.GetTarget();
            return _target != null;
        }

        [Task]
        protected void MoveToDestination()
        {
            _iMovementBehavior.MoveToDestination();
        }
        
        [Task]
        protected bool IsTargetKilled()
        {
            return _target == null;
        }

        [Task]
        protected void Attack()
        {
            if (_attackBehaviour.CanAttack(_target) && !_attackBehaviour.IsCooldown)
            {
                _attackBehaviour.Attack(_target);
                Task.current.Succeed();
            }
        }

        [Task]
        protected bool IsAtRequiredDistance(float distance)
        {
            if (_target == null)
            {
                return false;
            }
            var targetDistance = Vector3.Distance(_target.transform.position, _agent.transform.position);
            return targetDistance <= distance;
        }

        [Task]
        protected void Chase()
        {
            _chaseBehavior.Chase(_target);
        }

        [Task]
        protected void FollowPlayer()
        {
            _followBehavior.FollowPlayer();
        }

        [Task]
        protected bool IsTherePlayer()
        {
            return MainManager.Player != null;
        }
        
    }
}