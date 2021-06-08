using Panda;
using ProjectileLauncher;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Отвечает за дальние атаки AI
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
        var target = _targetProvider.GetTarget();
        if (_attackBehaviour.CanAttack(target) && !_attackBehaviour.IsCooldown)
        {
            _agent.isStopped = true;
            transform.LookAt(target.transform);
            
            _attackBehaviour.Attack(target);
            
            Task.current.Succeed();
        }
    }
}