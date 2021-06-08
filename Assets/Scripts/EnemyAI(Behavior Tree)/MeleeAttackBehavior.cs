using Characteristics;
using Enemies;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Отвечает за атаки ближнего боя.
/// </summary>
public class MeleeAttackBehavior : IAttackBehaviour
{
    public bool IsCooldown => _lastHitTime + _hitCooldown > Time.time;
    
    private readonly PersonCharacteristics _personCharacteristics;
    private readonly float _hitCooldown;
    private float _lastHitTime;
    
    
    public bool CanAttack(Person person)
    {
        return true;
    }

    public MeleeAttackBehavior(PersonCharacteristics personCharacteristics)
    {
        _personCharacteristics = personCharacteristics;
        _hitCooldown = personCharacteristics.AttackRate;
    }

    public void Attack(Person person)
    {
        _lastHitTime = Time.time;
        var healthBehaviour = person.GetComponent<HealthBehaviour>();
        healthBehaviour.ApplyDamage(_personCharacteristics.AttackDamage);
    }
}