using NinjaDungeon.Scripts.AI;
using ProjectileLauncher;
using UnityEngine;

namespace Barracks_and_allied_behavior
{
    /// <summary>
    /// Класс отвечающий за AI Лучника .
    /// </summary>
    [RequireComponent(typeof(AllyTargetProvider))]
    public class AIArcherAlly : AIBehaviour
    {
        [SerializeField]
        private  float _stopFollowingDistance;
        [SerializeField]
        private float _guardsDistance;
    
        private new void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _targetProvider = GetComponent<ITargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistanceMin, _stopChaseDistanceMax);
            _followBehavior = new FollowBehavior(_agent, _stopFollowingDistance, _guardsDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            base.Awake();
        }
    }
}
