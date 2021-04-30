using Enemies;
using UnityEngine;

namespace _3DWaveShooter.Scripts.Player
{
    [RequireComponent(typeof(HealthBehaviour))]
    public class Player : Singleton<Player>
    {
        public static Player instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}