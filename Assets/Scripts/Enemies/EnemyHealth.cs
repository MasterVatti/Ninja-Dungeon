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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health -= ProjectileLauncher.ProjectileLauncher.Singleton.Damage;
                if (_health <= 0)
                {
                    EnemiesManager.Singleton.OnEnemyDie(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}