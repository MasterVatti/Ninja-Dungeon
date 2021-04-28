using Assets.Scripts;
using ProjectileLauncher;
using UnityEngine;


public class PlayerProjectile : Projectile
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            DealDamage(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(GlobalConstants.WALL_TAG))
        {
            Destroy(gameObject);
        }
    }
}
