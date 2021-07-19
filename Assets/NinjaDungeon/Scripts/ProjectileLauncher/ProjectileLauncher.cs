using Enemies;
using NinjaDungeon.Scripts.ProjectileLauncher;
using PlayerScripts.Animation;
using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Находит ближайшего врага и атакует его
    /// </summary>
    [RequireComponent(typeof(IAttackBehaviour))]
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField]
        private PlayerAnimationController _playerAnimationController;
        
        private IAttackBehaviour _attackBehaviour;
        private NearestTargetProvider _nearestTargetProvider;

        private void Awake()
        {
            _attackBehaviour = GetComponent<IAttackBehaviour>();
            _nearestTargetProvider = new NearestTargetProvider();
        }

        private void Update()
        {
            var enemy = _nearestTargetProvider.GetNearestTarget(MainManager.EnemiesManager.Enemies, transform.position);
            
            if (!_attackBehaviour.IsCooldown && _attackBehaviour.CanAttack(enemy))
            {
                if (_playerAnimationController != null)
                {
                    _playerAnimationController.AttackAnimation();
                    _attackBehaviour.Attack(enemy);
                }
                else
                {
                    _attackBehaviour.Attack(enemy);
                }
            }
        }
    }
}