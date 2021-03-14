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
        
        public event Action<GameObject> EnemyDie;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                if (_health <= 0)
                {
                    EnemyDie?.Invoke(gameObject);
                    Destroy(gameObject);
                }
            }
        }

        public void ApplyDamage(int damage)
        {
            _health -= damage;
        }
    }
}