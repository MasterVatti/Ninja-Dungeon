using Barracks_and_allied_behavior;
using Panda;
using ProjectileLauncher;
using UnityEngine;

namespace MagicianFolder
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) мага (пока спавн голема и отбегание).
    /// </summary>
    [RequireComponent(typeof(EnemyTargetProvider))]
    public class AIMagician : AIBehaviour
    {
        [SerializeField]
        private GameObject _golemPrefab;
        [SerializeField]
        private float _runBackDistance;
        [SerializeField]
        private float _lowHealthThreshold;

        private bool _isGolemCreated;
        
        private void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _targetProvider = GetComponent<EnemyTargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistance);
            _attackBehaviour = new RangeAttackBehavior();
            _iMovementBehavior = new MovementBehaviour(_agent);
            
            ActivateBehaviorTree();
        }
        
        [Task]
        private void GolemSpawn()
        {
            if (!_isGolemCreated)
            {
                Instantiate(_golemPrefab, gameObject.transform.position, Quaternion.identity);
                _isGolemCreated = true;

                Task.current.Succeed();
            }

            Task.current.Fail();
        }

        [Task]
        private void MoveBackPoint()
        {
            _iMovementBehavior.CheckMoveDestination(gameObject.transform.TransformPoint(0, 0, 0 - _runBackDistance));
            Task.current.Succeed();
        }

        [Task]
        private bool IsTimeToSpawnGolem()
        {
            return _personCharacteristics.CurrentHp <= _lowHealthThreshold;
        }
    }
}