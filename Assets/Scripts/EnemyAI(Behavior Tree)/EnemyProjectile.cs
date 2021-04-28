using Assets.Scripts;
using ProjectileLauncher;
using UnityEngine;

/// <summary>
/// Пуля врагов 
/// </summary>
public class EnemyProjectile : Projectile
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            DealDamage(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(GlobalConstants.ALLY_TAG))
        {
            DealDamage(collision);
            Destroy(gameObject);
        }
    }
    
}
