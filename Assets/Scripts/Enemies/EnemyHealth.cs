using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Уменьшение здоровья врага при попадании пули
    /// </summary>
    public class EnemyHealth : MonoBehaviour
    {
        public static EnemyHealth Singleton { get; set; }
        [SerializeField] 
        private int _health;


        [SerializeField] 
        private EnemiesManager e;
        
        public delegate void EnemyDieHandler(GameObject enemy);
        public event EnemyDieHandler EnemyDie;

        private void Awake()
        {
            Singleton = this;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health -= ProjectileLauncher.ProjectileLauncher.Singleton.Damage;
                if (_health <= 0)
                {
                    //EnemyDie?.Invoke(gameObject);
                    e.OnEnemyDie(gameObject);
                    Destroy(gameObject);
                }
            }
        }

    }
}