using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EnemyScripts.Spawner
{
    public class Wave: MonoBehaviour
    {
        public static Action<Wave> OnWaveCleared;
        
        [SerializeField]
        private List<Enemy> _enemies;
        public List<Enemy> Enemies => _enemies;

        private void OnEnemyDie(Enemy enemy)
        {
            // TODO: Обработать смерть врага
            
            if (_enemies.Count == 0)
            {
                OnWaveCleared?.Invoke(this);
            }
        }
    }
}
