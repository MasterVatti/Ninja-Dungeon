using System;
using UnityEngine;
using UnityEngine.AI;

namespace NinjaDungeon.Scripts.AnimationController.Enemy
{
    public abstract class AIAnimationController : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Run = Animator.StringToHash("IsRun");

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
    }
}
