using NinjaDungeon.Scripts.AI;
using Panda;
using ProjectileLauncher;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Класс отвечающий за AI Рыцаря .
    /// </summary>
    [RequireComponent(typeof(AllyTargetProvider))]
    public class AIKnightAlly : AIBehaviour
    {
        [SerializeField]
        private int _accelerateSpeed = 3;
        [SerializeField]
        private  float _stopFollowingDistance;
        [SerializeField]
        private  float _guardsDistance;
        
        private void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _targetProvider = GetComponent<ITargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _followBehavior = new FollowBehavior(_agent, _stopFollowingDistance, _guardsDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
        }

        [Task]
        private void SlowDown()
        {
            _agent.speed = _personCharacteristics.MoveSpeed;
            Task.current.Succeed();
        }
        
        [Task]
        private void IncreaseSpeed()
        {
            _agent.speed = _accelerateSpeed + _personCharacteristics.MoveSpeed;
            Task.current.Succeed();
        }
    }
}
