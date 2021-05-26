using Panda;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Cпециальное поведение Рыцаря (Ускорение).
    /// </summary>
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
            
            _targetProvider = new AllyTargetProvider(gameObject);
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _followBehavior = new FollowBehavior(_agent, _stopFollowingDistance, _guardsDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            
            ActivateBehaviorTree();
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
