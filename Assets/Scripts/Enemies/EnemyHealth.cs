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
        public static event Func<int,int> DecreaseHealth;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                _health = GetInt(_health, DecreaseHealth);
                if (_health <= 0)
                {
                    EnemyDie?.Invoke(gameObject);
                    Destroy(gameObject);
                }
            }
        }

        private int GetInt(int health, Func<int, int> DecreaseHealth)
        {
            return DecreaseHealth(health);
        }
    }
}