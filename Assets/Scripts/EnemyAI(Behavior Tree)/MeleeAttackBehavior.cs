using Enemies;
using Panda;
using UnityEngine;

/// <summary>
/// Отвечает за аттаки ближнего боя.
/// </summary>
public class MeleeAttackBehavior : MonoBehaviour
{
    [SerializeField]
    private Unit _unit;
    
    [Task]
    private void Attack()
    {
        _unit.TargetProvider.ProvideTarget().GetComponent<HealthBehaviour>()
            .ApplyDamage(_unit.Characteristics.AttackDamage);
            
        Task.current.Succeed();
    }
}
