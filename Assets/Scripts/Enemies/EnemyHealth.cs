using System;
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
        
        public static event Action<GameObject> EnemyDie;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health -= ProjectileLauncher.ProjectileLauncher.Singleton.Damage;
                if (_health <= 0)
                {
                    EnemyDie?.Invoke(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}