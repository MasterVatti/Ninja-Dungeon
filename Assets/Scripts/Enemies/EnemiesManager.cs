using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// тут хранятся враги
    /// </summary>
    public class EnemiesManager : MonoBehaviour
    {
        public static EnemiesManager Singleton { get; private set; }
        [SerializeField] 
        public List<GameObject> enemies;

        private void Awake()
        {
            Singleton = this;
        }
    }
}
