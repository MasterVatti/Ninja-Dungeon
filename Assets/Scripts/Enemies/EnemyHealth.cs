using UnityEngine;

/// <summary>
/// Уменьшение здоровья врага при попадании пули
/// </summary>

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ProjectileShell bullet;
    [SerializeField] private EnemiesManager enemiesManager;
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Projectile"))
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health -= bullet.Damage;
            if (health <= 0)
            {
                var enemies = enemiesManager.enemies;
                for (int i = 0;  i< enemies.Count; i++)
                {
                    if (enemies[i] == gameObject)
                    {
                        enemies.RemoveAt(i);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
