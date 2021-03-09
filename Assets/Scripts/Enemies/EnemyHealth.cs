using System;
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
        private EnemiesManager e;
        
        public event EnemiesManager.EnemyDieHandler EnemyDie;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health -= ProjectileLauncher.ProjectileShell.Singleton.Damage;
                if (_health <= 0)
                {
                    //.EnemyDie?.Invoke(gameObject);
                    //e.EnemyDie += enemy => 
                    //EnemyDie?.Invoke(gameObject);
                    e.OnEnemyDie(gameObject);
                    Destroy(gameObject);
                }
            }
        }

    }
}