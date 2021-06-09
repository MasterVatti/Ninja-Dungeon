using PlayerScripts.Animation;
using ProjectileLauncher;
using UnityEngine;

namespace PlayerScripts.Movement
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
            _attackBehaviour.IsShoot += _animationController.AttackAnimation;
        }

        private void Update()
        {
            RunningDetector();
        }

        private void RunningDetector()
        {
            var direction = InputController.GetDirection();
            if (direction.x != 0 || direction.z != 0)
            {
                //_attackBehaviour.TurnAutoFire(false);
            }
            else
            {
               // _attackBehaviour.TurnAutoFire(true);
            }
        }
        
        private void OnDestroy()
        {
            _attackBehaviour.IsShoot -= _animationController.AttackAnimation;
        }
    }
}
