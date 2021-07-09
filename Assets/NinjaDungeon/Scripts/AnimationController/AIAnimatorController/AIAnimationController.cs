using Characteristics;
using UnityEngine;
using UnityEngine.AI;

namespace NinjaDungeon.Scripts.AnimationController.AIAnimatorController
{
    public abstract class AIAnimationController : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Run = Animator.StringToHash("IsRun");
        private static readonly int Death = Animator.StringToHash("Death");
        
        private Animator _animator;
        private NavMeshAgent _agent;
        
        protected void Awake()
        {
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        protected void Update()
        {
            _animator.SetBool(Run, !_agent.isStopped);
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
