using UnityEngine;

namespace ProjectileLauncher
{
    /// <summary>
    /// Находит ближайшего врага и атакует его
    /// </summary>
    [RequireComponent(typeof(ITargetProvider))]
    [RequireComponent(typeof(IAttackBehaviour))]
    public class ProjectileLauncher : MonoBehaviour
    {
        private IAttackBehaviour _attackBehaviour;
        private ITargetProvider _targetProvider;

        private void Awake()
        {
            _targetProvider = GetComponent<ITargetProvider>();
            _attackBehaviour = GetComponent<IAttackBehaviour>();
        }

        private void Update()
        {
            if (_attackBehaviour.IsCooldown)
            {
                return;
            }
            
            var enemy = _targetProvider.GetTarget();
            if (_attackBehaviour.CanAttack(enemy))
            {
                transform.parent.LookAt(enemy.transform);
                _attackBehaviour.Attack(enemy);
            }
        }
    }
}