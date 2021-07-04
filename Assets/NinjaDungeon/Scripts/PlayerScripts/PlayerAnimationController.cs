using Characteristics;
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
        private static readonly int Death = Animator.StringToHash("Death");
        
        public void RunningAnimation(bool state)
        {
            _animator.SetBool(IsWalk, state);
        }

        public void AttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        public void DeathAnimation(Person person)
        {
            _animator.SetTrigger(Death);
        }
    }
}