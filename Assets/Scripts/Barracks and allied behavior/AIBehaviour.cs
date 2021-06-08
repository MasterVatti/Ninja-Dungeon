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
        protected IMovementBehavior _movementBehavior;
        
        [Task]
        protected bool GetTarget()
        {
            return false;
        }

        [Task]
        protected void MoveToDestination()
        {
            _movementBehavior.MoveToDestination();
        }
        
        [Task]
        protected bool IsEnemyInSight()
        {
            return  _targetProvider.GetTarget() != null;
        }

        [Task]
        protected void Attack()
        {
            if (_attackBehaviour.CanAttack(_targetProvider.GetTarget()) && !_attackBehaviour.IsCooldown)
            {
                _attackBehaviour.Attack(_targetProvider.GetTarget());
                Task.current.Succeed();
            }
        }

        [Task]
        protected bool IsAtRequiredDistance(float distance)
        {
            var targetDistance = Vector3.Distance(_targetProvider.GetTarget().transform.position, _agent.transform.position);
            return targetDistance <= distance;
        }

        [Task]
        protected void Chase()
        {
            _chaseBehavior.Chase(_targetProvider.GetTarget());
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