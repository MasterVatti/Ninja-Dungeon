using PlayerScripts.Animation;
using UnityEngine;

namespace PlayerScripts.Movement
{
    /// <summary>
    /// Отвечает за взаимодействие модулей игрока.
    /// </summary>
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerAnimationController _animationController;
        [SerializeField]
        private ProjectileLauncher.ProjectileLauncher _launcher;
        
        private void Awake()
        {
            _launcher.IsShoot += _animationController.AttackAnimation;
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
                _launcher.TurnAutoFire(false);
            }
            else
            {
                _launcher.TurnAutoFire(true);
            }
        }
        
        private void OnDestroy()
        {
            _launcher.IsShoot -= _animationController.AttackAnimation;
        }
    }
}
