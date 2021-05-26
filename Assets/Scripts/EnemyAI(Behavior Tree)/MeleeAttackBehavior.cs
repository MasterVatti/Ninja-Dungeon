using Characteristics;
using Enemies;
using ProjectileLauncher;

/// <summary>
/// Отвечает за аттаки ближнего боя.
/// </summary>
public class MeleeAttackBehavior : IAttackBehaviour
{
    public bool IsCooldown { get; }
    
    private readonly PersonCharacteristics _personCharacteristics;

    public bool CanAttack(Person person)
    {
        return true;
    }

    public MeleeAttackBehavior(PersonCharacteristics personCharacteristics)
    {
        _personCharacteristics = personCharacteristics;
    }

    public void Attack(Person person)
    {
        var healthBehaviour = person.GetComponent<HealthBehaviour>();
        healthBehaviour.ApplyDamage(Team.Enemy, _personCharacteristics.AttackDamage);
    }
}