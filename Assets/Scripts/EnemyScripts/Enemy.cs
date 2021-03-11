using UnityEngine;

namespace Assets.Scripts.EnemyScripts
{
    public abstract class Enemy: MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField]
        private int _currentHp; //Enemy's current health.
        [SerializeField]
        private int _maxHp; //Enemy's maximum health.
        [SerializeField]
        private float _moveSpeed; //Enemy's movement speed in units per second.

        [Header("Attack")]
        [SerializeField]
        private int _attackDamage; //Damage dealt to target.
        [SerializeField]
        private float _attackRate; //Rate at which the enemy attacks their target.

        [Header("Bools")]
        [SerializeField]
        private bool _canMove; //Can the enemy move?
        [SerializeField]
        private bool _canAttack; //Can the enemy attack their target?

        [Header("Components")]
        [SerializeField]
        private Rigidbody _rigidbody; //Enemy's Rigidbody component.
    }
}
