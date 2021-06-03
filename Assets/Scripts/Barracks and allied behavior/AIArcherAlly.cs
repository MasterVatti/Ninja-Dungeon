using ProjectileLauncher;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    [RequireComponent(typeof(AllyTargetProvider))]
    public class AIArcherAlly : AIBehaviour
    {
        [SerializeField]
        private  float _stopFollowingDistance;
        [SerializeField]
        private float _guardsDistance;
    
        private void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _targetProvider = GetComponent<ITargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _followBehavior = new FollowBehavior(_agent, _stopFollowingDistance, _guardsDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            
        }
    }
}
