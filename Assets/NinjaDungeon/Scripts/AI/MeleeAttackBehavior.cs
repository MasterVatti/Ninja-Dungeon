using System;
using Characteristics;
using Enemies;
using JetBrains.Annotations;
using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;

namespace NinjaDungeon.Scripts.AI
{
    /// <summary>
    /// Отвечает за атаки ближнего боя.
    /// </summary>
    public class MeleeAttackBehavior : IAttackBehaviour
    {
        public event Action IsAttack;
        public bool IsCooldown => _lastHitTime + _hitCooldown > Time.time;
    
        private readonly PersonCharacteristics _personCharacteristics;
        private readonly float _hitCooldown;
        private float _lastHitTime;
        private readonly float _attackRange;
        private readonly NavMeshAgent _agent;
        
        public bool CanAttack(Person person)
        {
            var isPersonDead = person == null || person.PersonCharacteristics.IsDeath;
            var canAttack = !_personCharacteristics.CanAttack || _personCharacteristics.IsDeath;
            var targetDistance = Vector3.Distance(person.transform.position, _agent.transform.position);
            var isAttackDistance = targetDistance <= _attackRange;
            return !isPersonDead && !canAttack && isAttackDistance;
        }

        public MeleeAttackBehavior(PersonCharacteristics personCharacteristics, float attackRange, NavMeshAgent agent)
        {
            _personCharacteristics = personCharacteristics;
            _attackRange = attackRange;
            _agent = agent;
            _hitCooldown = personCharacteristics.AttackRate;
            
        }

        public void Attack(Person person)
        {
            _lastHitTime = Time.time;
            IsAttack?.Invoke();
            var healthBehaviour = person.GetComponent<HealthBehaviour>();
            healthBehaviour.ApplyDamage(_personCharacteristics.AttackDamage);
        }
        
    }
}