using UnityEngine;

namespace Barracks_and_allied_behavior
{
    public class AllyHealth : MonoBehaviour
    {
        /// <summary>
        /// Отвечает за здоровье Союзника.
        /// (Есть смысл сделать общий хелсСистем, либо на союзников и игрока)
        /// </summary>
        
        public void ApplyDamage(int damage)
        {
            GetComponent<Ally>().CurrentHp -= damage;
            if (GetComponent<Ally>().CurrentHp <= 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
        
            Destroy(gameObject);
        }
    }
}
