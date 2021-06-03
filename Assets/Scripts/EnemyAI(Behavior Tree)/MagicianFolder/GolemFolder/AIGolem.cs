using Barracks_and_allied_behavior;
using Characteristics;
using Panda;

namespace MagicianFolder.GolemFolder
{
    public class AIGolem : AIBehaviour
    {
        private void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            MainManager.EnemiesManager.Enemies.Add(GetComponent<Enemy>());
            
            _targetProvider = GetComponent<EnemyTargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            _iMovementBehavior = new MovementBehaviour(_agent);
        }
        
        [Task]
        private void SetTargetPosition()
        {
            _iMovementBehavior.CheckMoveDestination(_target.transform.position);
            
            Task.current.Succeed();
        }
    }
}
