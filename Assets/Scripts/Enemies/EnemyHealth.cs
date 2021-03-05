using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /// <summary>
    /// Уменьшение здоровья врага при попадании пули
    /// </summary>
    
    [SerializeField] private int health;
    [SerializeField] private ProjectileShell bullet;
    [SerializeField] private EnemiesManager enemiesManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= bullet.damage;
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
