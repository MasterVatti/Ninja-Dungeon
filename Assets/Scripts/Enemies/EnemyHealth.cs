using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Уменьшение здоровья врага при попадании пули
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _health;
        [SerializeField] 
        private EnemiesManager _enemiesManager;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health -= ProjectileLauncher.ProjectileShell.Singleton.Damage;
                if (_health <= 0)
                {
                    var enemies = _enemiesManager.enemies;
                    for (int i = 0; i < enemies.Count; i++)
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
}