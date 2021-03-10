using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Отвечает за здоровье врага
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _health;
        
        public delegate void EventHandler(GameObject enemy);
        public static event EventHandler EnemyDie;
        
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