using System;
using Characteristics;
using NinjaDungeon.Scripts.AnimationController.AIAnimatorController;
using NinjaDungeon.Scripts.AnimationController.Enemy;
using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Отвечает за базовые настройки всех AI(базовые таски) и за поля базовых модулей.
    /// </summary>
    public abstract class AIBehaviour : MonoBehaviour
    {
        [SerializeField]
        protected NavMeshAgent _agent;
        [SerializeField]
        protected PersonCharacteristics _personCharacteristics;
        [FormerlySerializedAs("_stopChaseDistance")]
        [SerializeField]
        protected float _stopChaseDistanceMax;
        [SerializeField]
        protected float _stopChaseDistanceMin;
        [SerializeField]
        protected AIAnimationController _animationController;
        [SerializeField]
        protected PandaBehaviour _pandaBehaviour;
        
        protected ITargetProvider _targetProvider;
        protected ChaseBehavior _chaseBehavior;
        protected FollowBehavior _followBehavior;
        protected IAttackBehaviour _attackBehaviour;
        protected IMovementBehavior _movementBehavior;

        protected void Awake()
        {
            _attackBehaviour.IsAttack += _animationController.AttackAnimation;
        }

        protected void Update()
        {
            if (!_personCharacteristics.CanMove)
            {
                _pandaBehaviour.enabled = false;
            }
        }

        private void OnDestroy()
        {
            _attackBehaviour.IsAttack -= _animationController.AttackAnimation;
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
            if (!_attackBehaviour.CanAttack(_targetProvider.GetTarget()) || _attackBehaviour.IsCooldown)
            {
                return;
            }
            
            _attackBehaviour.Attack(_targetProvider.GetTarget());
            Task.current.Succeed();
        }

        [Task]
        protected bool IsAtRequiredDistance(float distance)
        {
            var transformPosition = _targetProvider.GetTarget().transform.position;
            var targetDistance = Vector3.Distance(transformPosition, _agent.transform.position);
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