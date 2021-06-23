using UnityEngine;

namespace NinjaDungeon.Scripts.AnimationController.Enemy
{
    public class MagicianAnimatorController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        public void AttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }
    }
}
