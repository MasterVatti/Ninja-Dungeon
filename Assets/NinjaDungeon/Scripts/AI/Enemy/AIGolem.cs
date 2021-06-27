using Barracks_and_allied_behavior;
using Characteristics;
using NinjaDungeon.Scripts.AI;
using Panda;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    /// Отвечает за AI Голема.
    /// </summary>
    public class AIGolem : AIBehaviour
    {
        private new void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            MainManager.EnemiesManager.AddEnemy(GetComponent<Enemy>());
            
            _targetProvider = GetComponent<EnemyTargetProvider>();            
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistanceMin, _stopChaseDistanceMax);
            _attackBehaviour = new MeleeAttackBehavior(_personCharacteristics);
            _movementBehavior = new MovementBehaviour(_agent);
            base.Awake();
            
            _agent.isStopped = true;
        }
        
        [Task]
        private void SetTargetPosition()
        {
            _movementBehavior.SetMoveDestination(_targetProvider.GetTarget().transform.position);
            
            Task.current.Succeed();
        }
    }
}
