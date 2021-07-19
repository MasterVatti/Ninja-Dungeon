using Characteristics;
using PlayerScripts.Animation;
using PlayerScripts.Movement;
using ProjectileLauncher;
using UnityEngine;

namespace NinjaDungeon.Scripts.PlayerScripts.Movement
{
    /// <summary>
    /// Отвечает за взаимодействие модулей игрока.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerAnimationController _animationController;
        [SerializeField]
        private PlayerAttackBehaviour _attackBehaviour;
        
        private void Awake()
        {
            _attackBehaviour.IsAttack += _animationController.AttackAnimation;
        }

        private void Update()
        {
            RunningDetector();
        }

        private void RunningDetector()
        {
            var direction = InputController.GetDirection();
            var isRun = direction.x != 0 || direction.z != 0;
            
            _animationController.RunningAnimation(isRun);
            _attackBehaviour.TurnAutoFire(!isRun);
        }
        
        private void OnDestroy()
        {
            _attackBehaviour.IsAttack -= _animationController.AttackAnimation;
        }
    }
}
