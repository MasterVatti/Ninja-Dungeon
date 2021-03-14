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
        public static Func<int,int> DecreaseHealth;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                if (DecreaseHealth != null)
                {
                    _health = DecreaseHealth(_health);
                }
                if (_health <= 0)
                {
                    EnemyDie?.Invoke(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}