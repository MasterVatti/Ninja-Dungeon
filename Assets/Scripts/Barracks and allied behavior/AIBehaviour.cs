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
        protected PandaBehaviour _panda;
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

        protected void ActivateBehaviorTree()
        {
            _panda.enabled = true;
        }
        
        [Task]
        private bool IsTargetKilled()
        {
            return _target == null;
        }
        
        [Task]
        private void Attack()
        {
            _attackBehaviour.Attack(_target);
        }

        [Task]
        private bool IsAtRequiredDistance(float distance)
        {
            var targetDistance = Vector3.Distance(_target.transform.position, _agent.transform.position);
            return targetDistance <= distance;
        }

        [Task]
        private void Chase()
        {
            _chaseBehavior.Chase(_target);
        }
        
        [Task]
        private void FollowPlayer()
        {
            _followBehavior.FollowPlayer();
        }

        [Task]
        private bool IsTherePlayer()
        {
            return MainManager.Player != null;
        }
    }
}