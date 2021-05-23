using Enemies;
using Panda;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Отвечает за аттаки ближнего боя.
/// </summary>
[RequireComponent(typeof(Unit))]
public class MeleeAttackBehavior : MonoBehaviour
{
    private Unit _unit;

    private void Awake()
    {
        _unit = GetComponent<Unit>();
    }
    
    [Task]
    private void Attack()
    {
        var target = _unit.TargetProvider.GetTarget();
        var healthBehaviour = target.GetComponent<HealthBehaviour>();
        healthBehaviour.ApplyDamage(Team.Enemy, _unit.Characteristics.AttackDamage);
            
        Task.current.Succeed();
    }
}
