using System;
using Characteristics;
using Enemies;
using Panda;
using UnityEngine;

namespace MagicianFolder.GolemFolder
{
    /// <summary>
    /// Отвечает за базовые навыки(Таски) голема (пока спавн голема и отбегание).
    /// </summary>
    public class GolemAI : MonoBehaviour
    {
        [SerializeField]
        private EnemyAI _enemyAI;

        private int _damage;
        
        private void Start()
        {
            _damage = gameObject.GetComponent<PersonCharacteristics>().AttackDamage;
        }

        [Task]
        private void Attack()
        {
            _enemyAI.Target.GetComponent<HealthBehaviour>().ApplyDamage(_damage);
            Task.current.Succeed();
        }
    }
}
