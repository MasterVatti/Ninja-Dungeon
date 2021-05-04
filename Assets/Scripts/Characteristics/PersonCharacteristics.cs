using System;
using Enemies;
using UnityEngine;

namespace Characteristics
{
    /// <summary>
    /// Общий класс для всех мобов/игроков в игре
    /// </summary>
    public abstract class PersonCharacteristics : MonoBehaviour
    {
        public int CurrentHp
        {
            get => _currentHP;
            set
            {
                _currentHP = value;
                _currentHP = Mathf.Clamp(value, 0 , _maxHp);
            }
        }
        public int MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }
        public float MoveSpeed
        {
            get => _moveSpeed;
            set => _moveSpeed = value;
        }
    
        public int AttackDamage
        {
            get => _attackDamage;
            set => _attackDamage = value;
        }
        public float AttackRate
        {
            get => _attackRate;
            set => _attackRate = value;
        }
    
        public bool CanMove
        {
            get => _canMove;
            set => _canMove = value;
        }
        public bool CanAttack
        {
            get => _canAttack;
            set => _canAttack = value;
        }
        
        
        [Header("Stats")]
        [SerializeField]
        private int _currentHP;
        [SerializeField]
        private int _maxHp;
        [SerializeField]
        private float _moveSpeed;
    
        [Header("Attack")]
        [SerializeField]
        private int _attackDamage;
        [SerializeField]
        private float _attackRate;
    
        [Header("Bools")]
        [SerializeField]
        private bool _canMove;
        [SerializeField]
        private bool _canAttack;
        
    }
}
