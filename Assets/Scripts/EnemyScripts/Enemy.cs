using UnityEngine;

namespace Assets.Scripts.EnemyScripts
{
    /// <summary>
    /// Базовое представление врага, хранит статы, компоненты и флаги врага
    ///
    /// P.S. В будущем сюда можно добавить методы атаки, передвижение,
    /// новые компоненты, etc. 
    /// </summary>
    public abstract class Enemy : MonoBehaviour
    {
        [Header("Stats")]
        public int CurrentHP;
        public int MaxHp;
        public float MoveSpeed;

        [Header("Attack")]
        public int AttackDamage;
        public float AttackRate;

        [Header("Bools")]
        public bool CanMove;
        public bool CanAttack;

        [Header("Components")]
        public Rigidbody Rigidbody;
    }
}
