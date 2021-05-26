using Barracks_and_allied_behavior;

namespace MagicianFolder.GolemFolder
{
    public class AIGolem : AIBehaviour
    {
        private void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _targetProvider = GetComponent<EnemyTargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            _iMovementBehavior = new MovementBehaviour(_agent);
            
            ActivateBehaviorTree();
        }
    }
}
