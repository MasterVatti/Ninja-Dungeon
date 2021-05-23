using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за дальние атаки врагов
/// </summary>
[RequireComponent(typeof(ITargetProvider))]
[RequireComponent(typeof(IAttackBehaviour))]
public class AIProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    
    private ITargetProvider _targetProvider;
    private IAttackBehaviour _attackBehaviour;

    private void Awake()
    {
        _targetProvider = GetComponent<ITargetProvider>();
        _attackBehaviour = GetComponent<IAttackBehaviour>();
    }
    
    [Task]
    private void Shooting()
    {
        // TODO:
        // 1. ITargetProvider - эти классы не должны содержать ничего кроме определения цели
        // 2. Написать новый AttackBehaviour, в котором вернуть все проверки на рейкасты внутри 
        // CanAttack
        var target = _targetProvider.GetTarget();
        if (_attackBehaviour.CanAttack(target) && !_attackBehaviour.IsCooldown)
        {
            _agent.isStopped = true;
            _attackBehaviour.Attack(target);
            Task.current.Succeed();
        }
    }
}