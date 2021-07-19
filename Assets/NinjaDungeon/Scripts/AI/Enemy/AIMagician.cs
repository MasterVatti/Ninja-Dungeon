 using System;
 using Barracks_and_allied_behavior;
 using Characteristics;
 using NinjaDungeon.Scripts.AnimationController.Enemy;
 using Panda;
using ProjectileLauncher;
using UnityEngine;

namespace MagicianFolder
{
    /// <summary>
    /// Отвечает за AI  мага.
    /// </summary>
    [RequireComponent(typeof(EnemyTargetProvider))]
    public class AIMagician : AIBehaviour
    {
        [SerializeField]
        private GameObject _golemPrefab;
        [SerializeField]
        private float _runBackDistance;
        [Header("Between")]
        [SerializeField]
        private float _lowHealthThresholdFrom = 10;
        [SerializeField]
        private float _lowHealthThresholdTo = 30;
        
        private bool _isGolemCreated;
        
        private new void Awake()
        {
            _personCharacteristics.CurrentHp = _personCharacteristics.MaxHp;
            
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _targetProvider = GetComponent<EnemyTargetProvider>();
            _chaseBehavior = new ChaseBehavior(_agent, _stopChaseDistanceMin, _stopChaseDistanceMax);
            _movementBehavior = new MovementBehaviour(_agent);
            
            base.Awake();
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
        private void SetBackPoint()
        {
            _movementBehavior.SetMoveDestination(transform.TransformPoint(0, 0, 0 - _runBackDistance));
            
            Task.current.Succeed();
        }

        [Task]
        private bool IsTimeToSpawnGolem()
        {
            return _personCharacteristics.CurrentHp <= _lowHealthThresholdTo && _personCharacteristics.CurrentHp >= _lowHealthThresholdFrom;
        }
        
    }
}