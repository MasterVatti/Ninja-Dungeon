using Assets.Scripts;
using Characteristics;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Отвечает за дальние атаки AI.
/// </summary>
public class RangeAttackBehavior : SimpleAttackBehaviour
{
    public override bool CanAttack(Person person)
    {
        if (!base.CanAttack(person))
        {
            return false;
        }
        
        var directionToTarget = person.transform.position - transform.position;
        if (Physics.Raycast(transform.position, directionToTarget.normalized, out var hit))
        {
            if (hit.collider.CompareTag(GlobalConstants.PLAYER_TAG) || hit.collider.CompareTag(GlobalConstants.ALLY_TAG) 
                                                                    || hit.collider.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                return true;
            }
        }

        return false;
    }

    protected override void Shoot(Vector3 direction)
    {
        CreateProjectile(_muzzle.position, direction,  _personCharacteristics.AttackDamage);
    }
}
