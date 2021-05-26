using UnityEngine;
using UnityEngine.AI;

namespace Barracks_and_allied_behavior
{
    public class AIArcherAlly : AIBehaviour
    {
        [SerializeField]
        private  float _stopFollowingDistance;
        [SerializeField]
        private float _guardsDistance;
    
        private void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _targetProvider = new AllyTargetProvider(gameObject);
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _followBehavior = new FollowBehavior(_agent, _stopFollowingDistance, _guardsDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            
            ActivateBehaviorTree();
        }
    }
}
