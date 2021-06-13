using PlayerScripts.Movement;
using UnityEngine;

namespace PlayerScripts.Animation
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        
        private static readonly int IsWalk = Animator.StringToHash("isWalk");
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        void Update()
        {
            RunningAnimation();
        }

        private void RunningAnimation()
        {
            var direction = InputController.GetDirection();
            if (direction.x != 0 || direction.z != 0)
            {
                _animator.SetBool(IsWalk,true);
            }
            else
            {
                _animator.SetBool(IsWalk,false);
            }
        }

        public void AttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }
    }
}
