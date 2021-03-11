using UnityEngine;

namespace Assets.Scripts.EnemyScripts
{
    public abstract class Enemy : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField]
        private int _currentHp;
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

        [Header("Components")]
        [SerializeField]
        private Rigidbody _rigidbody;
    }
}
